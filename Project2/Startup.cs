using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using testesenior.domain.Interface;
using testesenior.Domain.Mapper;
using TesteSenior.Data.Context;
using TesteSenior.Data.Repositories;

namespace Project2
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
            //Configure Cors
            services.AddCors(o => o.AddPolicy("Cors", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddAutoMapper(typeof(EntityDtoProfile), typeof(DtoEntityProfile));

            services.AddScoped<ITabelaCidadeRepository, TabelaCidadeRepository>();
            services.AddScoped<ITabelaApartamentoRepository, TabelaApartamentoRepository>();
            services.AddScoped<ITabelaEdificioRepository, TabelaEdificioRepository>();
            services.AddScoped<ITabelaPagamentosCondominioRepository, TabelaPagamentosCondominioRepository>();
            services.AddScoped<ISPRankingCondominioRepository, SPRankingCondominioRepository>();

            //Configure SQL Server
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<TesteSeniorConext>(options =>
                             options
                             .UseLazyLoadingProxies()
                             .UseSqlServer(Configuration["ConnectionStrings:WebTeste"]));
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
          
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501
                
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.UseProxyToSpaDevelopmentServer("https://localhost:44324/");
                    spa.UseAngularCliServer(npmScript: "start");
                    app.UseWebSockets();
                }
            });
        }
    }
}
