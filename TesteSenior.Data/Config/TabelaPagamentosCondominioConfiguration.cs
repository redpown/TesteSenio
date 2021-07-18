using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesenior.domain.Entity;

namespace TesteSenior.Data.Config
{
    public class TabelaPagamentosCondominioConfiguration : IEntityTypeConfiguration<TabelaPagamentosCondominio>
    {
        public void Configure(EntityTypeBuilder<TabelaPagamentosCondominio> builder)
        {
            builder.ToTable("TABELA_PAGAMENTOS_CONDOMINIO");

            builder.HasKey(tabelaPagamentosCondominio => tabelaPagamentosCondominio.codigoPagamentoCondominio);

            builder.Property(tabelaPagamentosCondominio => tabelaPagamentosCondominio.dataPagamento)
                .IsRequired();
            
            builder.Property(tabelaApartamento => tabelaApartamento.valorPagamento)
                .IsRequired()
                .HasMaxLength(400);

            builder.HasOne(b => b.tabelaApartamento)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(

                new { dataPagamento = "10/10/2011", valorPagamento = 450.00, tabelaApartamento = 1 },
                new { dataPagamento = "10/11/2011", valorPagamento = 330.00, tabelaApartamento = 2 },
                new { dataPagamento = "10/04/2011", valorPagamento = 250.00, tabelaApartamento = 2 },
                new { dataPagamento = "10/08/2011", valorPagamento = 110.00, tabelaApartamento = 3 },
                new { dataPagamento = "10/06/2011", valorPagamento = 220.00, tabelaApartamento = 4 },
                new { dataPagamento = "10/02/2011", valorPagamento = 540.00, tabelaApartamento = 5 },
                new { dataPagamento = "10/01/2011", valorPagamento = 450.00, tabelaApartamento = 2 },
                new { dataPagamento = "10/03/2012", valorPagamento = 340.00, tabelaApartamento = 3 },
                new { dataPagamento = "10/04/2012", valorPagamento = 220.00, tabelaApartamento = 4 }

               );
        }
    }
}
