using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testesenior.domain.Interface;
using testesenior.Domain.Mapper;
using TesteSenior.Data.Context;
using TesteSenior.Data.Repositories;
using TesteSenior.Service.Service;

namespace TesteSenior.Asp
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

            //Configure Views
            services.AddControllersWithViews();

            //Configure SQL Server
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<TesteSeniorConext>(options =>
                             options
                             .UseLazyLoadingProxies()
                             .UseSqlServer(Configuration["ConnectionStrings:WebTeste"]));

            //Configure Mapper
            services.AddAutoMapper(typeof(EntityDtoProfile), typeof(DtoEntityProfile));

            //Configure Services
            services.AddScoped<TabelaCidadeService>();
           // services.AddScoped<ITabelaCidadeRepository, TabelaCidadeRepository>();
            services.AddScoped<TabelaApartamentoService>();
            services.AddScoped<TabelaEdificioService>();
            //services.AddScoped<ITabelaEdificioRepository, TabelaEdificioRepository>();
            services.AddScoped<ITabelaPagamentosCondominioRepository, TabelaPagamentosCondominioRepository>();
            services.AddScoped<ISPRankingCondominioRepository, SPRankingCondominioRepository>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
