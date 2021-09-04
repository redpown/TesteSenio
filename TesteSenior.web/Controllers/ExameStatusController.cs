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
    public class ExameStatusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ExameStatusService _ExamesStatus;

        public ExameStatusController(ExameStatusService examesStatus, IMapper mapper)
        {
            _ExamesStatus= examesStatus;
            _mapper = mapper;
        }
        // GET: api/<QualidadeMetricasController>
        [HttpGet]
        public IEnumerable<ExameStatus> Get()
        {
            return _ExamesStatus.GetAll();
        }

        // GET api/<QualidadeMetricasController>/5
        [HttpGet("{id}")]
        public ExameStatus Get(int id)
        {
            return _ExamesStatus.Select(id);
;        }

        // POST api/<QualidadeMetricasController>
        [HttpPost]
        public void Post([FromBody] ExameStatus value)
        {
            _ExamesStatus.Insert(value);
        }

        // PUT api/<QualidadeMetricasController>/5
        [HttpPut]
        public void Put([FromBody] ExameStatus value)
        {
            _ExamesStatus.Update(value);
        }

        // DELETE api/<QualidadeMetricasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           // _Coletas.DeleteId(id);
        }
    }
}
