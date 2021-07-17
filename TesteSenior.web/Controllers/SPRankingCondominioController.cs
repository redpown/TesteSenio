/*******************************************************************************
 |                               ***Andre Marques***
 |
 |Classe    : SPRankingCondominioController.cs
 |Data      : 07/16/2021
 |Descrição : Classe de controller para o endpoint SPRankingCondominio
 |Autor     : Andre Marques
 |
 |Ataualizações:
 |Autor    :    
 |Data     :
 |Linha    :
 |Descrição:
 ********************************************************************************/
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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteSenior.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPRankingCondominioController : ControllerBase
    {

        private readonly TabelaSPRankingCondominioService _ISPRankingCondominioRepository;

        public SPRankingCondominioController(TabelaSPRankingCondominioService iSPRankingCondominioRepository)
        {
            _ISPRankingCondominioRepository = iSPRankingCondominioRepository;
        }


        /*******************************************************************************
	     |Método    : Get
	     |Data      : 07/16/2021
	     |Descrição : Retorna Procedure SPRankingCondominio
         |GET       : api/SPRankingCondominio
         |Autor     : Andre Marques
	     ********************************************************************************/
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

    }
}
