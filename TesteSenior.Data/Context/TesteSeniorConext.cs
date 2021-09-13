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

        public DbSet<TabelaApartamento> TabelaApartamentos { get; set; }

        public DbSet<TabelaCidade> TabelaCidades { get; set; }

        public DbSet<TabelaEdificio> TabelaEdificios { get; set; }

        public DbSet<TabelaPagamentosCondominio> TabelaPagamentosCondominios { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<QualidadeMetricas> QualidadeMetricas { get; set; }
        public DbSet<Exames> Exames { get; set; }
        public DbSet<ExameStatus> ExameStatus { get; set; }
        public DbSet<TipoExame> TipoExames { get; set; }
        public DbSet<Coleta> Coleta { get; set; }
        public virtual DbSet<Metrica> Metricas { get; set; }
        public virtual DbSet<MetricasTipoMes> MetricaTipoMes { get; set; }

        public DbSet<SPRankingCondominio> SpRankingCondominio { get; set; }

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
            modelBuilder.ApplyConfiguration(new QualidadeMetricasConfiguration());
            modelBuilder.ApplyConfiguration(new ExameConfiguration());
            modelBuilder.ApplyConfiguration(new ExameStatusConfiguration());
            modelBuilder.ApplyConfiguration(new TipoExameConfiguration());
            modelBuilder.ApplyConfiguration(new ColetaConfiguration());
            modelBuilder.ApplyConfiguration(new SPRankingCondominioConfiguration());

        }
    }
}
