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

            builder.HasData(

                  new{ tabelaEdificio = 1, metragem = 100, andar =  1,numeroQuartos = 2},
                  new{ tabelaEdificio = 2, metragem =  98, andar =  3,numeroQuartos = 3},
                  new{ tabelaEdificio = 2, metragem = 120, andar =  2,numeroQuartos = 4},
                  new{ tabelaEdificio = 2, metragem = 120, andar =  4,numeroQuartos = 4},
                  new{ tabelaEdificio = 3, metragem = 100, andar =  1,numeroQuartos = 3},
                  new{ tabelaEdificio = 5, metragem =  90, andar =  3,numeroQuartos = 2},
                  new{ tabelaEdificio = 6, metragem = 150, andar =  5,numeroQuartos = 4},
                  new{ tabelaEdificio = 7, metragem = 200, andar = 14, numeroQuarto = 3}

                );
        }
    }
}
