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
            
            builder.HasKey(tabelaPagamentosCondominio => tabelaPagamentosCondominio.codigoPagamentoCondominio);

            builder.Property(tabelaPagamentosCondominio => tabelaPagamentosCondominio.dataPagamento)
                .IsRequired();
                


            builder.Property(tabelaApartamento => tabelaApartamento.valorPagamento)
                .IsRequired()
                .HasMaxLength(400);
                                  
        }
    }
}
