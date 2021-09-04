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
    public class TipoExameController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly TipoExameService _TipoExame;

        public TipoExameController(TipoExameService tipoExame, IMapper mapper)
        {
            _TipoExame = tipoExame;
            _mapper = mapper;
        }
        // GET: api/<QualidadeMetricasController>
        [HttpGet]
        public IEnumerable<TipoExame> Get()
        {
            return _TipoExame.GetAll();
        }

        // GET api/<QualidadeMetricasController>/5
        [HttpGet("{id}")]
        public TipoExame Get(int id)
        {
            return _TipoExame.Select(id);
;        }

        // POST api/<QualidadeMetricasController>
        [HttpPost]
        public void Post([FromBody] TipoExame value)
        {
            _TipoExame.Insert(value);
        }

        // PUT api/<QualidadeMetricasController>/5
        [HttpPut]
        public void Put([FromBody] TipoExame value)
        {
            _TipoExame.Update(value);
        }

        // DELETE api/<QualidadeMetricasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           // _Coletas.DeleteId(id);
        }
    }
}
