using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using testesenior.domain.Interface;
using testesenior.Domain.Mapper;
using TesteSenior.Data.Context;
using TesteSenior.Data.Repositories;

namespace TesteSenior.web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //Configure Cors
            services.AddCors(o => o.AddPolicy("Cors", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //Configure SQL Server
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<TesteSeniorConext>(options =>
                             options
                             .UseLazyLoadingProxies()
                             .UseSqlServer(Configuration["ConnectionStrings:WebTeste"]));

            services.AddHangfire(configuration => configuration
           .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
           .UseSimpleAssemblyNameTypeSerializer()
           .UseRecommendedSerializerSettings()
           .UseSqlServerStorage(Configuration.GetConnectionString("WebTeste"), new SqlServerStorageOptions
           {
               QueuePollInterval = TimeSpan.Zero,
               UseRecommendedIsolationLevel = false,
               UsePageLocksOnDequeue = false,
               DisableGlobalLocks = false
           }));

            services.AddAutoMapper(typeof(EntityDtoProfile), typeof(DtoEntityProfile));

            services.AddScoped<ITabelaCidadeRepository, TabelaCidadeRepository>();
            services.AddScoped<ITabelaApartamentoRepository, TabelaApartamentoRepository>();
            services.AddScoped<ITabelaEdificioRepository, TabelaEdificioRepository>();
            services.AddScoped<ITabelaPagamentosCondominioRepository, TabelaPagamentosCondominioRepository>();
            services.AddScoped<ISPRankingCondominioRepository, SPRankingCondominioRepository>();

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            //Configure Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "teste", Version = "v1" });
            });

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebSockets();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseCors("Cors");

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "teste");
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "  {controller}/{action=Index}/{id?}");
            });



            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
            app.UseWebSockets();
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            //Execute Automatic Migrations
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<TesteSeniorConext>().Database.Migrate();
            }
        }
    }
}
