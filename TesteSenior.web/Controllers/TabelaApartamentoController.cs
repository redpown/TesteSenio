/*******************************************************************************
 |                               ***Andre Marques***
 |
 |Classe    : TabelaApartamentoController.cs
 |Data      : 07/16/2021
 |Descrição : Classe de controller para o endpoint TabelaApartamento
 |Autor     : Andre Marques
 |
 |Ataualizações:
 |Autor    :    
 |Data     :
 |Linha    :
 |Descrição:
 ********************************************************************************/
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
using TesteSenior.Service.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteSenior.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaApartamentoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly TabelaApartamentoService _ITabelaApartamentoRepository;
        
        public TabelaApartamentoController(TabelaApartamentoService iTabelaApartamentoRepository, IMapper mapper)
        {
            _ITabelaApartamentoRepository = iTabelaApartamentoRepository;
            _mapper = mapper;
        }

        /*******************************************************************************
	     |Método    : Get()
	     |Data      : 07/16/2021
	     |Descrição : Retorna todo DTO da entidade Tabela apartamento
         |GET       : api/TabelaApartamento
         |Autor     : Andre Marques
	     ********************************************************************************/


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

        /*******************************************************************************
	     |Método    : Get(int id)
	     |Data      : 07/16/2021
	     |Descrição : Retorna um DTO da entidade Tabela apartamento
         |GET       : api/TabelaApartamento/id
         |Autor     : Andre Marques
	     ********************************************************************************/
       
        [HttpGet("{id}")]
        public NovoTabelaApartamentoDTO Get(int id)
        {
            return _ITabelaApartamentoRepository.SelectDTO(id);
        }

        /*******************************************************************************
	     |Método    : Post()
	     |Data      : 07/16/2021
	     |Descrição : cria na base se o id for null
         |POST      : api/TabelaApartamento
         |Autor     : Andre Marques
	     ********************************************************************************/
       
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

        /*******************************************************************************
        |Método    : Put()
        |Data      : 07/16/2021
        |Descrição : Atualiza pelo novo valor passado atraves do DTO da entidade
        |Put       : api/TabelaApartamento
        |Autor     : Andre Marques
        ********************************************************************************/
 
        [HttpPut]
        public IActionResult Put([FromBody] NovoTabelaApartamentoDTO value)
        {
            try
            {
                _ITabelaApartamentoRepository.UpdateByDTO(value);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /*******************************************************************************
        |Método    : Delete(id)
        |Data      : 07/16/2021
        |Descrição : Deleta da base o id passado
        |Delete    : api/TabelaApartamento/id
        |Autor     : Andre Marques
        ********************************************************************************/

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
