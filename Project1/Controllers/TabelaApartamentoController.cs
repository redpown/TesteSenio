using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.domain.Interface;
using testesenior.Domain.DTO;
using TesteSenior.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteSenior.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaApartamentoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITabelaApartamentoRepository _ITabelaApartamentoRepository;
        
        public TabelaApartamentoController(ITabelaApartamentoRepository iTabelaApartamentoRepository, IMapper mapper)
        {
            _ITabelaApartamentoRepository = iTabelaApartamentoRepository;
            _mapper = mapper;
        }

        // GET: api/<TabelaApartamentoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                
                return Ok(_ITabelaApartamentoRepository.GetAllFromDto());
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex.ToString());
            }
        }

        // GET api/<TabelaApartamentoController>/5
        [HttpGet("{id}")]
        public TabelaApartamento Get(int id)
        {
            return _ITabelaApartamentoRepository.Select(id);
        }

        // POST api/<TabelaApartamentoController>
        [HttpPost]
        public IActionResult Post([FromBody] NovoTabelaApartamentoDTO value)
        {
            try
            {
 
                   

                var valueInsert = _ITabelaApartamentoRepository.Select(value.codigoApartamento);

                if (valueInsert != null)
                {
                    return BadRequest("Usuario já cadastrado no sistema");
                }
                else
                {
                    _ITabelaApartamentoRepository.InsertDTO(value);
                }


                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // PUT api/<TabelaApartamentoController>/5
        [HttpPut]
        public IActionResult Put([FromBody] NovoTabelaApartamentoDTO value)
        {
            try
            {

                var valueInsert = _ITabelaApartamentoRepository.Select(value.codigoApartamento);

                if (valueInsert != null)
                {
                    return BadRequest("Usuario já cadastrado no sistema");
                }
                else
                {
                    _ITabelaApartamentoRepository.InsertDTO(value);
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
}

        // DELETE api/<TabelaApartamentoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ITabelaApartamentoRepository.DeleteId(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
