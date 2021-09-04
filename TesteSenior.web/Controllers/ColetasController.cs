using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testesenior.Domain.Entity;
using TesteSenior.Service.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteSenior.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColetasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ColetasService _Coletas;

        public ColetasController(ColetasService coletas, IMapper mapper)
        {
            _Coletas = coletas;
            _mapper = mapper;
        }
        // GET: api/<QualidadeMetricasController>
        [HttpGet]
        public IEnumerable<Coleta> Get()
        {
            return _Coletas.GetAll();
        }

        // GET api/<QualidadeMetricasController>/5
        [HttpGet("{id}")]
        public Coleta Get(int id)
        {
            return _Coletas.Select(id);
;        }

        // POST api/<QualidadeMetricasController>
        [HttpPost]
        public void Post([FromBody] Coleta value)
        {
            _Coletas.Insert(value);
        }

        // PUT api/<QualidadeMetricasController>/5
        [HttpPut]
        public void Put([FromBody] Coleta value)
        {
            _Coletas.Update(value);
        }

        // DELETE api/<QualidadeMetricasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           // _Coletas.DeleteId(id);
        }
    }
}
