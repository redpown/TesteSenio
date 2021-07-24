using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.domain.Interface;
using testesenior.Domain.DTO;
using TesteSenior.Data.Context;
using TesteSenior.Data.Repositorios;
using TesteSenior.Data.StoreProcedure;

namespace TesteSenior.Data.Repositories
{
    public class SPRankingCondominioRepository : BaseRepository<SPRankingCondominio>, ISPRankingCondominioRepository
    {
        public SPRankingCondominioRepository(TesteSeniorConext testeSeniorConext, IMapper mapper) : base(testeSeniorConext, mapper)
        {
            testeSeniorConext.Database.ExecuteSqlRaw(StoreProceduresSPRankingCondominio.STORE_PROCEDURE_SP_RANKING_CONDOMINIO);
        }
              
    }
}
