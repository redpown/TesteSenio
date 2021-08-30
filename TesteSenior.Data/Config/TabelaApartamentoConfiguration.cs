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
            builder.ToTable("TABELA_APARTAMENTO");

            builder.HasKey(tabelaApartamento => tabelaApartamento.codigoApartamento).HasName("CODIGO_APARTAMENTO_ID");

            builder.Property(tabelaApartamento => tabelaApartamento.codigoApartamento)
                       .ValueGeneratedOnAdd()
                       .HasMaxLength(50)
                       .HasColumnName("CODIGO_APARTAMENTO");

            builder.Property(tabelaApartamento => tabelaApartamento.tabelaEdificioID)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CODIGO_EDIFICIO");


            builder.Property(tabelaApartamento => tabelaApartamento.andar)
                    .HasMaxLength(50)
                    .HasColumnName("ANDAR");

            builder.Property(tabelaApartamento => tabelaApartamento.metragem)
                    .HasMaxLength(400)
                    .HasColumnName("METRAGEM");


            builder.Property(tabelaApartamento => tabelaApartamento.numeroQuartos)
                .HasMaxLength(50)
                .HasColumnName("NUMERO_QUARTOS");

            builder.HasData(

                  new TabelaApartamento { codigoApartamento = 1, tabelaEdificioID = 1, metragem = 100, andar = 1, numeroQuartos = 2 },
                  new TabelaApartamento { codigoApartamento = 2, tabelaEdificioID = 1, metragem = 98, andar = 3, numeroQuartos = 3 },
                  new TabelaApartamento { codigoApartamento = 3, tabelaEdificioID = 1, metragem = 120, andar = 2, numeroQuartos = 4 },
                  new TabelaApartamento { codigoApartamento = 4, tabelaEdificioID = 1, metragem = 120, andar = 4, numeroQuartos = 4 },
                  new TabelaApartamento { codigoApartamento = 5, tabelaEdificioID = 1, metragem = 100, andar = 1, numeroQuartos = 3 },
                  new TabelaApartamento { codigoApartamento = 6, tabelaEdificioID = 1, metragem = 90, andar = 3, numeroQuartos = 2 },
                  new TabelaApartamento { codigoApartamento = 7, tabelaEdificioID = 1, metragem = 150, andar = 5, numeroQuartos = 4 },
                  new TabelaApartamento { codigoApartamento = 8, tabelaEdificioID = 1, metragem = 200, andar = 14, numeroQuartos = 3 }

                );

        }
    }
}
