using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteSenior.web
{
    public class Program
    {
        //Update-database
        //add-migration
        //comando para desenvolver apartir de uma base de dados existentes
        /*
        I had to install these packages in my class library:

        Microsoft.EntityFrameworkCore.SqlServer
        Microsoft.EntityFrameworkCore.Design
        Microsoft.EntityFrameworkCore.Tools
        */
        //Scaffold-DbContext Name=ConnectionStrings:WebTeste Microsoft.EntityFrameworkCore.SqlServer -OutputDir "BackendProject" -ContextDir "DbContexts" -Force

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
