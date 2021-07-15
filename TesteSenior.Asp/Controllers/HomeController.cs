using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.domain.Interface;
using testesenior.Domain.DTO;
using TesteSenior.Asp.Models;
using TesteSenior.Data.Context;
using TesteSenior.Data.Repositories;
using TesteSenior.Service.Service;

namespace TesteSenior.Asp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly TabelaCidadeService db;



        public HomeController(ILogger<HomeController> logger, TabelaCidadeService indb)
        {
            _logger = logger;
            db = indb;


        }

        public IActionResult Index()
        {

            IEnumerable<TabelaCidadeDTO> lista = db.GetAllFromDto();



            return View(lista);
        }

        public IActionResult Privacy() 
        {
            return View();
        }
        /*
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        */
    }
}
