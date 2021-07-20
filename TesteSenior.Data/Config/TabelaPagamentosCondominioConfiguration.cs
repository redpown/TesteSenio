using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            builder.HasKey(tabelaPagamentosCondominio => tabelaPagamentosCondominio.codigoPagamentoCondominio)
                .HasName("CODIGO_PAGAMENTOS_CONDOMINIO_ID");

            builder.Property(tabelaPagamentosCondominio => tabelaPagamentosCondominio.codigoPagamentoCondominio)
                .ValueGeneratedOnAdd()
                .HasMaxLength(50)
                .HasColumnName("CODIGO_PAGAMENTOS_CONDOMINIO");

            builder.Property(tabelaPagamentosCondominio => tabelaPagamentosCondominio.tabelaApartamentoID)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("CODIGO_APARTAMENTO");

            builder.Property(tabelaPagamentosCondominio => tabelaPagamentosCondominio.dataPagamento)
                .IsRequired()
                .HasColumnType("date")
                //.HasConversion(v => v, v => DateTime.ParseExact(v.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None))
                .HasColumnName("DATA_PAGAMENTO");

            builder.Property(tabelaPagamentosCondominio => tabelaPagamentosCondominio.valorPagamento)
                .IsRequired()
                .HasMaxLength(400)
                .HasColumnName("VALOR_PAGAMENTO");

            builder.HasOne(b => b.tabelaApartamento)
                .WithMany()
                .HasForeignKey(d => d.tabelaApartamentoID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
           
            builder.HasData(
                
                new { codigoPagamentoCondominio = 1,dataPagamento = DateTime.ParseExact("2011-10-10", "yyyy-MM-dd", CultureInfo.InvariantCulture,DateTimeStyles.None), valorPagamento = 450.00, tabelaApartamentoID = 1 },
                new { codigoPagamentoCondominio = 2,dataPagamento = DateTime.ParseExact("2011-11-10", "yyyy-MM-dd", CultureInfo.InvariantCulture,DateTimeStyles.None), valorPagamento = 330.00, tabelaApartamentoID = 2 },
                new { codigoPagamentoCondominio = 3,dataPagamento = DateTime.ParseExact("2011-04-10", "yyyy-MM-dd", CultureInfo.InvariantCulture,DateTimeStyles.None), valorPagamento = 250.00, tabelaApartamentoID = 2 },
                new { codigoPagamentoCondominio = 4,dataPagamento = DateTime.ParseExact("2011-08-10", "yyyy-MM-dd", CultureInfo.InvariantCulture,DateTimeStyles.None), valorPagamento = 110.00, tabelaApartamentoID = 3 },
                new { codigoPagamentoCondominio = 5,dataPagamento = DateTime.ParseExact("2011-06-10", "yyyy-MM-dd", CultureInfo.InvariantCulture,DateTimeStyles.None), valorPagamento = 220.00, tabelaApartamentoID = 4 },
                new { codigoPagamentoCondominio = 6,dataPagamento = DateTime.ParseExact("2011-02-10", "yyyy-MM-dd", CultureInfo.InvariantCulture,DateTimeStyles.None), valorPagamento = 540.00, tabelaApartamentoID = 5 },
                new { codigoPagamentoCondominio = 7,dataPagamento = DateTime.ParseExact("2011-01-10", "yyyy-MM-dd", CultureInfo.InvariantCulture,DateTimeStyles.None), valorPagamento = 450.00, tabelaApartamentoID = 2 },
                new { codigoPagamentoCondominio = 8,dataPagamento = DateTime.ParseExact("2011-03-10", "yyyy-MM-dd", CultureInfo.InvariantCulture,DateTimeStyles.None), valorPagamento = 340.00, tabelaApartamentoID = 3 },
                new { codigoPagamentoCondominio = 9,dataPagamento = DateTime.ParseExact("2011-04-10", "yyyy-MM-dd", CultureInfo.InvariantCulture,DateTimeStyles.None), valorPagamento = 220.00, tabelaApartamentoID = 4 }

               );
        }
    }
}
