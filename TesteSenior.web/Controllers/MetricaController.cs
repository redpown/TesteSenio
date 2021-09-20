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
        [HttpGet("GetAllCreatinina")]
        public IEnumerable<ViewMetrica> GetAllCreatinina()
        {
            try
            {
                return _qMetricas.GetViewAllCreatinina();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
         
        }

        [HttpGet("GetAllHemograma")]
        public IEnumerable<ViewMetrica> GetAllHemograma()
        {
            try
            {
                return _qMetricas.GetViewAllHemograma();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

        [HttpGet("GetAllAcidoUrico")]
        public IEnumerable<ViewMetrica> GetAllAcidoUrico()
        {
            try
            {
                return _qMetricas.GetViewAllAcidoUrico();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

        [HttpGet("GetAllHIV")]
        public IEnumerable<ViewMetrica> GetAllHIV()
        {
            try
            {
                return _qMetricas.GetViewAllHIV();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

        [HttpGet("GetAllUrina1")]
        public IEnumerable<ViewMetrica> GetAllUrina1()
        {
            try
            {
                return _qMetricas.GetViewAllUrina1();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

        [HttpGet("GetAllUreia")]
        public IEnumerable<ViewMetrica> GetAllUreia()
        {
            try
            {
                return _qMetricas.GetViewAllUreia();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

        [HttpGet("GetAllLDH")]
        public IEnumerable<ViewMetrica> GetAllLDH()
        {
            try
            {
                return _qMetricas.GetViewAllLDH();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

        

        // GET api/<MetricaController>/5
        [HttpGet("{id}")]
        public ViewMetrica Get(int id)
        {
            return _qMetricas.Select(id);
;        }

        // POST api/<MetricaController>
        [HttpPost]
        public void Post([FromBody] ViewMetrica value)
        {
            _qMetricas.Insert(value);
        }

        // PUT api/<MetricaController>/5
        [HttpPut]
        public void Put([FromBody] ViewMetrica value)
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
