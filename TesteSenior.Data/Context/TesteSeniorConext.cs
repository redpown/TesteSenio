using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.Domain.DTO;
using testesenior.Domain.Entity;
using TesteSenior.Data.Config;
using TesteSenior.Data.StoreProcedure;

namespace TesteSenior.Data.Context
{
    public class TesteSeniorConext : DbContext
    {
        //public StoreProcedures procedure;

        public DbSet<TabelaApartamento> tabelaApartamentos { get; set; }

        public DbSet<TabelaCidade> tabelaCidades { get; set; }

        public DbSet<TabelaEdificio> tabelaEdificios { get; set; }

        public DbSet<TabelaPagamentosCondominio> tabelaPagamentosCondominios { get; set; }

        public DbSet<Usuario> usuarios { get; set; }

        public DbSet<SPRankingCondominio> spRankingCondominio { get; set; }

        public TesteSeniorConext(DbContextOptions options) : base(options)
        {
            //base.Database.ExecuteSqlRaw(StoreProceduresSPRankingCondominio.STORE_PROCEDURE_SP_RANKING_CONDOMINIO);
        }
        public TesteSeniorConext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new TabelaApartamentoConfiguration());
            modelBuilder.ApplyConfiguration(new TabelaCidadeConfiguration());
            modelBuilder.ApplyConfiguration(new TabelaEdificioConfiguration());
            modelBuilder.ApplyConfiguration(new TabelaPagamentosCondominioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new SPRankingCondominioConfiguration());
           
        }
    }
}
