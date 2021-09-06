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
    public class QualidadeMetricasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly QualidadeMetricasService _qMetricas;

        public QualidadeMetricasController(QualidadeMetricasService qMetricas, IMapper mapper)
        {
            _qMetricas = qMetricas;
            _mapper = mapper;
        }
        // GET: api/<QualidadeMetricasController>
        [HttpGet]
        public IEnumerable<QualidadeMetricas> Get()
        {
            try
            {
                return _qMetricas.GetAll();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
         
        }

        // GET api/<QualidadeMetricasController>/5
        [HttpGet("{id}")]
        public QualidadeMetricas Get(int id)
        {
            return _qMetricas.Select(id);
;        }

        // POST api/<QualidadeMetricasController>
        [HttpPost]
        public void Post([FromBody] QualidadeMetricas value)
        {
            _qMetricas.Insert(value);
        }

        // PUT api/<QualidadeMetricasController>/5
        [HttpPut]
        public void Put([FromBody] QualidadeMetricas value)
        {
            _qMetricas.Update(value);
        }

        // DELETE api/<QualidadeMetricasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _qMetricas.DeleteId(id);
        }

        // POST api/<QualidadeMetricasController>
        [HttpPost("AmostraDedados")]
        public void AmostraDedados()
        {
            _qMetricas.GerarDados();
        }
    }
}
