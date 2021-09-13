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
    public class MetricasTipoMesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly MetricasTipoMesService _qMetricas;

        public MetricasTipoMesController(MetricasTipoMesService qMetricas, IMapper mapper)
        {
            _qMetricas = qMetricas;
            _mapper = mapper;
        }
        // GET: api/<MetricasTipoMesController>
        [HttpGet]
        public IEnumerable<MetricasTipoMes> Get()
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

        // GET api/<MetricasTipoMesController>/5
        [HttpGet("{id}")]
        public MetricasTipoMes Get(int id)
        {
            return _qMetricas.Select(id);
;        }

        // POST api/<MetricasTipoMesController>
        [HttpPost]
        public void Post([FromBody] MetricasTipoMes value)
        {
            _qMetricas.Insert(value);
        }

        // PUT api/<MetricasTipoMesController>/5
        [HttpPut]
        public void Put([FromBody] MetricasTipoMes value)
        {
            _qMetricas.Update(value);
        }

        // DELETE api/<MetricasTipoMesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _qMetricas.DeleteId(id);
        }

        // POST api/<MetricasTipoMesController>
        [HttpPost("AmostraDedados")]
        public void AmostraDedados()
        {
           // _qMetricas.GerarDados();
        }
    }
}
