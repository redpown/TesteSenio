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

namespace TesteSenior.Data.Repositories
{
    public class TabelaPagamentosCondominioRepository : BaseRepository<TabelaPagamentosCondominio>, ITabelaPagamentosCondominioRepository
    {
        public TabelaPagamentosCondominioRepository(TesteSeniorConext testeSeniorConext, IMapper mapper) : base(testeSeniorConext, mapper)
        {
        }
        
    }
}
