using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.domain.Interface;
using testesenior.Domain.DTO;
using TesteSenior.Data.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteSenior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPRankingCondominioController : ControllerBase
    {

        private readonly ISPRankingCondominioRepository _ISPRankingCondominioRepository;

        public SPRankingCondominioController(ISPRankingCondominioRepository iSPRankingCondominioRepository)
        {
            _ISPRankingCondominioRepository = iSPRankingCondominioRepository;
        }

        // GET: api/<SPRankingCondominioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ISPRankingCondominioRepository.GetProcedure());
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.ToString());
            }
        }

        /*

        // GET api/<SPRankingCondominioController>/5
        [HttpGet("{id}")]
        public SPRankingCondominio Get(int id)
        {
            return _ISPRankingCondominioRepository.Select(id);
        }

        // POST api/<SPRankingCondominioController>
        [HttpPost]
        public IActionResult Post([FromBody] SPRankingCondominio value)
        {
            try
            {
                var valueInsert = _ISPRankingCondominioRepository.Select(value.codigoCidade);

                if (valueInsert != null)
                {
                    return BadRequest("Usuario já cadastrado no sistema");
                }
                else
                {
                    _ISPRankingCondominioRepository.Insert(value);
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // PUT api/<SPRankingCondominioController>/5
        [HttpPut]
        public IActionResult Put([FromBody] SPRankingCondominio value)
        {
            try
            {
                _ISPRankingCondominioRepository.Update(value);
                 return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
}

        // DELETE api/<SPRankingCondominioController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] SPRankingCondominio value)
        {
            try
            {
                _ISPRankingCondominioRepository.Delete(value);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        */
    }
}
