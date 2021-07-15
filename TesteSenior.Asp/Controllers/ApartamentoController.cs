using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testesenior.Domain.DTO;
using TesteSenior.Service.Service;

namespace TesteSenior.Asp.Controllers
{
    public class ApartamentoController : Controller
    {
        private readonly ILogger<ApartamentoController> _logger;
        private readonly TabelaApartamentoService _db;

        public ApartamentoController(ILogger<ApartamentoController> logger, TabelaApartamentoService indb)
        {
            _logger = logger;
            _db = indb;


        }
        // GET: ApartamentoController
        public ActionResult Index()
        {
            return View(_db.GetAllFromDto());
        }

        // GET: ApartamentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApartamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApartamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApartamentoController/Edit/5
        [HttpGet]
        public ActionResult Apartamento(int id)
        {
            return View(_db.SelectDTO(id));
        }

        // POST: ApartamentoController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, NovoTabelaApartamentoDTO collection)
        {
            try
            {
                _db.UpdateByDTO(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: ApartamentoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(NovoTabelaApartamentoDTO collection)
        {
            try
            {
                _db.InsertDTO(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApartamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApartamentoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collect)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
