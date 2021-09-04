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
    public class ExamesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ExamesService _Exames;

        public ExamesController(ExamesService exames, IMapper mapper)
        {
            _Exames = exames;
            _mapper = mapper;
        }
        // GET: api/<QualidadeMetricasController>
        [HttpGet]
        public IEnumerable<Exames> Get()
        {
            return _Exames.GetAll();
        }

        // GET api/<QualidadeMetricasController>/5
        [HttpGet("{id}")]
        public Exames Get(int id)
        {
            return _Exames.Select(id);
;        }

        // POST api/<QualidadeMetricasController>
        [HttpPost]
        public void Post([FromBody] Exames value)
        {
            _Exames.Insert(value);
        }

        // PUT api/<QualidadeMetricasController>/5
        [HttpPut]
        public void Put([FromBody] Exames value)
        {
            _Exames.Update(value);
        }

        // DELETE api/<QualidadeMetricasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           // _Coletas.DeleteId(id);
        }
    }
}
