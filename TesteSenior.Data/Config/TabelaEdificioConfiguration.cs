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

            builder.HasKey(tabelaEdificio => tabelaEdificio.codigoEdificio).HasName("CODIGO_EDIFICIO_ID");

            builder.Property(tabelaEdificio => tabelaEdificio.codigoEdificio)
                .ValueGeneratedOnAdd()
                .HasMaxLength(50)
                .HasColumnName("CODIGO_EDIFICIO");

            builder.Property(tabelaEdificio => tabelaEdificio.tabelaCidadeId)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("CODIGO_CIDADE");

            builder.Property(tabelaEdificio => tabelaEdificio.nomeEdificio)
               .HasMaxLength(50)
               .HasColumnName("NOME_EDIFICIO");

            builder.Property(tabelaEdificio => tabelaEdificio.andares)
                .HasMaxLength(50)
                .HasColumnName("ANDARES");

            builder.Property(tabelaEdificio => tabelaEdificio.numeroAptoAndar)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnName("NUMERO__APTO_ANDAR");

            builder.HasOne(b => b.tabelaCidade)
             .WithMany()
             .HasForeignKey(x => x.tabelaCidadeId)
             .IsRequired()
             .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasData(

                new { codigoEdificio = 1, nomeEdificio = "Edifício Esplanada", andares = 5, tabelaCidadeId = 1, numeroAptoAndar = 4 },
                new { codigoEdificio = 2, nomeEdificio = "Edifício Vera", andares = 10, tabelaCidadeId = 2, numeroAptoAndar = 3 },
                new { codigoEdificio = 3, nomeEdificio = "Edifício Sônia", andares = 5, tabelaCidadeId = 1, numeroAptoAndar = 4 },
                new { codigoEdificio = 4, nomeEdificio = "Edifício Tavares", andares = 7, tabelaCidadeId = 3, numeroAptoAndar = 4 },
                new { codigoEdificio = 5, nomeEdificio = "Edifício Renata", andares = 12, tabelaCidadeId = 3, numeroAptoAndar = 2 },
                new { codigoEdificio = 6, nomeEdificio = "Edifício Tiago", andares = 14, tabelaCidadeId = 1, numeroAptoAndar = 4 },
                new { codigoEdificio = 7, nomeEdificio = "Edifício Sol", andares = 15, tabelaCidadeId = 1, numeroAptoAndar = 2 }

               );
            
            




        }
    }
}
