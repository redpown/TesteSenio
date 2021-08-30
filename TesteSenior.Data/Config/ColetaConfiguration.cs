using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using testesenior.Domain.Entity;

namespace TesteSenior.Data.Config
{
    public class ColetaConfiguration : IEntityTypeConfiguration<Coleta>
    {
        public void Configure(EntityTypeBuilder<Coleta> builder)
        {
            builder.ToTable("TABELA_COLETA");

            builder.HasKey(tabelaCOLETA => tabelaCOLETA.id)
                .HasName("COLETA_IDS");

            builder.Property(tabelaCOLETA => tabelaCOLETA.id)
                .ValueGeneratedOnAdd()
                .HasColumnName("COLETAS_ID");


            builder.Property(tabelaCOLETA => tabelaCOLETA.descricao)
                .HasMaxLength(50)
                .HasColumnName("COLETA_DESCRICAO");

            builder.HasMany(b => b.qmId)
              .WithOne()
              .HasForeignKey(x => x.qmColetaId);

            builder.HasData(

                new Coleta
                {
                    id = 1,
                    descricao = "Recebido"

                },
                new Coleta
                {
                    id = 2,
                    descricao = "Recoleta"

                },
                new Coleta
                {
                    id = 3,
                    descricao = "Não Coletado"

                }
                               );
        }
    }
}
