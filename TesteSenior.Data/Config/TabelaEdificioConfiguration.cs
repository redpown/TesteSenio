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
    public class TabelaEdificioConfiguration : IEntityTypeConfiguration<TabelaEdificio>
    {
        public void Configure(EntityTypeBuilder<TabelaEdificio> builder)
        {
            builder.ToTable("TABELA_EDIFICIO");

            builder.HasKey(tabelaEdificio => tabelaEdificio.codigoEdificio);

            builder.Property(tabelaEdificio => tabelaEdificio.andares)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(tabelaEdificio => tabelaEdificio.numeroAptoAndar)
                .IsRequired()
                .HasMaxLength(12);

            builder.HasOne(b => b.tabelaCidade)
           .WithMany()
           .IsRequired()
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(

                new { nomeEdificio = "Edifício Esplanada", andares = 5, tabelaCidade = 1, numeroAptoAndar = 4 },
                new { nomeEdificio = "Edifício Vera", andares = 10, tabelaCidade = 2, numeroAptoAndar = 3 },
                new { nomeEdificio = "Edifício Sônia", andares = 5, tabelaCidade = 1, numeroAptoAndar = 4 },
                new { nomeEdificio = "Edifício Tavares", andares = 7, tabelaCidade = 3, numeroAptoAndar = 4 },
                new { nomeEdificio = "Edifício Renata", andares = 12, tabelaCidade = 3, numeroAptoAndar = 2 },
                new { nomeEdificio = "Edifício Tiago", andares = 14, tabelaCidade = 1, numeroAptoAndar = 4 },
                new { nomeEdificio = "Edifício Sol", andares = 15, tabelaCidade = 1, numeroAptoAndar = 2 }

               );

        }
    }
}
