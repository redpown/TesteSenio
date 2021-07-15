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
    public class CidadeController : Controller
    {
        private readonly ILogger<CidadeController> _logger;

        private readonly TabelaCidadeService db;



        public CidadeController(ILogger<CidadeController> logger, TabelaCidadeService indb)
        {
            _logger = logger;
            db = indb;


        }

        public IActionResult Index()
        {

            IEnumerable<TabelaCidadeDTO> lista = db.GetAllFromDto();



            return View(lista);
        }

        [HttpGet]
        public IActionResult Cidade(int? id)
        {
            TabelaCidade objVM = new TabelaCidade();
           
            if (id != null)
            {
                objVM = db.Select((int)id);
            }
            return View(objVM);
        }

        [HttpPost]
        public IActionResult Cadastrar(TabelaCidade objVM)
        {
            if (ModelState.IsValid)
            {
                    db.Insert(objVM);
                }
            else
            {
                return View(objVM);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Excluir(int id)
        {
            db.DeleteId(id);
            return RedirectToAction("index");
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
