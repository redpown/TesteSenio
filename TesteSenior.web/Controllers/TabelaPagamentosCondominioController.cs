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
using TesteSenior.Service.Service;

namespace TesteSenior.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaPagamentosCondominioController : ControllerBase
    {

        private readonly TabelaPagamentoService _ITabelaPagamentosCondominioRepository;

        public TesteSeniorConext _TesteSeniorConext = new TesteSeniorConext();

        public TabelaPagamentosCondominioController(TabelaPagamentoService iTabelaPagamentosCondominioRepository)
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
        public NovoTabelaPagamentosCondominioDTO Get(int id)
        {
            return _ITabelaPagamentosCondominioRepository.SelectDTO(id);
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
        public IActionResult Put([FromBody] TabelaPagamentosCondominioDTO value)
        {
            try
            {
                _ITabelaPagamentosCondominioRepository.UpdateByDTO(value);
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
