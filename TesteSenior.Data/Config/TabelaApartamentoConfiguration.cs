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
    public class TabelaApartamentoConfiguration : IEntityTypeConfiguration<TabelaApartamento>
    {
        public void Configure(EntityTypeBuilder<TabelaApartamento> builder)
        {
            builder.HasKey(tabelaApartamento => tabelaApartamento.codigoApartamento);

            builder.Property(tabelaApartamento => tabelaApartamento.andar)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(tabelaApartamento => tabelaApartamento.metragem)
                .IsRequired()
                .HasMaxLength(400);


            builder.Property(tabelaApartamento => tabelaApartamento.numeroQuartos)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
