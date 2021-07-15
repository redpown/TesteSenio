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
using TesteSenior.Data.Repositories;
using TesteSenior.Data.Repositorios;

namespace TesteSenior.Service.Service
{
    public class TabelaSPRankingCondominioService : TabelaPagamentosCondominioRepository
    {
        public TabelaSPRankingCondominioService(TesteSeniorConext testeSeniorConext, IMapper mapper) : base(testeSeniorConext, mapper)
        {
        }

        public IEnumerable<SPRankingCondominio> GetProcedure()
        {
            return _TesteSeniorConext.Set<SPRankingCondominio>()
                 .FromSqlRaw("EXEC  [dbo].[sp_ranking_condominio] @dt_inicio = '10-02-2011', @dt_termino = '10-06-2011';")
                 .ToList();
        }

    }
}
