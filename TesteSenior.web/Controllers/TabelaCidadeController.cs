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
    public class TabelaCidadeController : ControllerBase
    {

        private readonly TabelaCidadeService _ITabelaCidadeRepository;

        public TabelaCidadeController(TabelaCidadeService iTabelaCidadeRepository)
        {
            _ITabelaCidadeRepository = iTabelaCidadeRepository;
        }

        // GET: api/<TabelaCidadeController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ITabelaCidadeRepository.GetAllFromDto());
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.ToString());
            }
        }

        // GET api/<TabelaCidadeController>/5
        [HttpGet("{id}")]
        public TabelaCidade Get(int id)
        {
            return _ITabelaCidadeRepository.Select(id);
        }

        // POST api/<TabelaCidadeController>
        [HttpPost]
        public IActionResult Post([FromBody] TabelaCidadeDTO value)
        {
            try
            {
                var valueInsert = _ITabelaCidadeRepository.Select(0);

                if (valueInsert != null)
                {
                    return BadRequest("Usuario já cadastrado no sistema");
                }
                else
                {
                    _ITabelaCidadeRepository.InsertDTO(value);
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // PUT api/<TabelaCidadeController>/5
        [HttpPut]
        public IActionResult Put([FromBody] TabelaCidadeDTO value)
        {
            try
            {

                _ITabelaCidadeRepository.UpdateByDTO(value);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // DELETE api/<TabelaCidadeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ITabelaCidadeRepository.DeleteId(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
