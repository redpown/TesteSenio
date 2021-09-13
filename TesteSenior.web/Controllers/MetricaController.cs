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
    public class MetricaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MetricaService _qMetricas;

        public MetricaController(MetricaService qMetricas, IMapper mapper)
        {
            _qMetricas = qMetricas;
            _mapper = mapper;
        }
        // GET: api/<MetricaController>
        [HttpGet]
        public IEnumerable<Metrica> Get()
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

        // GET api/<MetricaController>/5
        [HttpGet("{id}")]
        public Metrica Get(int id)
        {
            return _qMetricas.Select(id);
;        }

        // POST api/<MetricaController>
        [HttpPost]
        public void Post([FromBody] Metrica value)
        {
            _qMetricas.Insert(value);
        }

        // PUT api/<MetricaController>/5
        [HttpPut]
        public void Put([FromBody] Metrica value)
        {
            _qMetricas.Update(value);
        }

        // DELETE api/<MetricaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _qMetricas.DeleteId(id);
        }

        // POST api/<MetricaController>
        [HttpPost("AmostraDedados")]
        public void AmostraDedados()
        {
            //_qMetricas.GerarDados();
        }
    }
}
