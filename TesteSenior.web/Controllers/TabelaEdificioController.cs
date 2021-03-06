using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.domain.Interface;
using testesenior.Domain.DTO;
using TesteSenior.Service.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteSenior.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaEdificioController : ControllerBase
    {

        private readonly TabelaEdificioService _ITabelaEdificioRepository;
        
        public TabelaEdificioController(TabelaEdificioService iTabelaEdificioRepository)
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
        public NovoTabelaEdificioDTO Get(int id)
        {
            return _ITabelaEdificioRepository.SelectDTO(id);
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
        [HttpPut]
        public IActionResult Put([FromBody] TabelaEdificioDTO value)
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
