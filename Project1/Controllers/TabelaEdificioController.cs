using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.domain.Interface;
using testesenior.Domain.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteSenior.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaEdificioController : ControllerBase
    {

        private readonly ITabelaEdificioRepository _ITabelaEdificioRepository;
        
        public TabelaEdificioController(ITabelaEdificioRepository iTabelaEdificioRepository)
        {
            _ITabelaEdificioRepository = iTabelaEdificioRepository;
        }

        // GET: api/<TabelaEdificioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ITabelaEdificioRepository.GetAllFromDto());
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.ToString());
            }
        }

        // GET api/<TabelaEdificioController>/5
        [HttpGet("{id}")]
        public TabelaEdificio Get(int id)
        {
            return _ITabelaEdificioRepository.Select(id);
        }

        // POST api/<TabelaEdificioController>
        [HttpPost]
        public IActionResult Post([FromBody] NovoTabelaEdificioDTO value)
        {
            
            try
            {
                var valueInsert = _ITabelaEdificioRepository.Select(value.codigoEdificio);

                if (valueInsert != null)
                {
                    return BadRequest("Usuario já cadastrado no sistema");
                }
                else
                {
                    _ITabelaEdificioRepository.InsertDTO(value);
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // PUT api/<TabelaEdificioController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] TabelaEdificioDTO value, int id)
        {
            try
            {
                _ITabelaEdificioRepository.UpdateByDTO(value);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
}

        // DELETE api/<TabelaEdificioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ITabelaEdificioRepository.DeleteId(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
