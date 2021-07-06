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

namespace TesteSenior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaPagamentosCondominioController : ControllerBase
    {

        private readonly ITabelaPagamentosCondominioRepository _ITabelaPagamentosCondominioRepository;

        public TesteSeniorConext _TesteSeniorConext = new TesteSeniorConext();
        public TabelaPagamentosCondominioController(ITabelaPagamentosCondominioRepository iTabelaPagamentosCondominioRepository)
        {
            _ITabelaPagamentosCondominioRepository = iTabelaPagamentosCondominioRepository;
           
        }

        // GET: api/<TabelaPagamentosCondominioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ITabelaPagamentosCondominioRepository.GetAll());
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.ToString());
            }
        }

        // GET api/<TabelaPagamentosCondominioController>/5
        [HttpGet("{id}")]
        public TabelaPagamentosCondominio Get(int id)
        {
            return _ITabelaPagamentosCondominioRepository.Select(id);
        }

        // POST api/<TabelaPagamentosCondominioController>
        [HttpPost]
        public IActionResult Post([FromBody] NovoTabelaPagamentosCondominioDTO value)
        {
            try
            {
                
                    _ITabelaPagamentosCondominioRepository.InsertDTO(value);
                       return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // PUT api/<TabelaPagamentosCondominioController>/5
        [HttpPut]
        public IActionResult Put([FromBody] TabelaPagamentosCondominio value)
        {
            try
            {
                _ITabelaPagamentosCondominioRepository.Update(value);
                 return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
}

        // DELETE api/<TabelaPagamentosCondominioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ITabelaPagamentosCondominioRepository.DeleteId(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        


    }
}
