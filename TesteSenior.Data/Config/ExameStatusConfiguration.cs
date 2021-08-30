using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using testesenior.Domain.Entity;

namespace TesteSenior.Data.Config
{
    public class ExameStatusConfiguration : IEntityTypeConfiguration<ExameStatus>
    {
        public void Configure(EntityTypeBuilder<ExameStatus> builder)
        {
            builder.ToTable("TABELA_EXAMES_STATUS");

            builder.HasKey(tabelaExame => tabelaExame.id)
                .HasName("EXAMES_STATUS_IDS");

            builder.Property(tabelaExame => tabelaExame.id)
                .ValueGeneratedOnAdd()
                .HasMaxLength(50)
                .HasColumnName("EXAMES_STATUS_ID");
               

            builder.Property(tabelaExame => tabelaExame.descricao)
                .HasMaxLength(50)
                .HasColumnName("EXAMES_STATUS_DESCRICAO");

          builder.HasMany(b => b.qmId)
          .WithOne()
          .HasForeignKey(x => x.qmExameStatusId);

            builder.HasData(

                new Coleta
                {
                    id = 1,
                    descricao = "Aguaradando Liberação"

                },
                new Coleta
                {
                    id = 2,
                    descricao = "Liberado"

                },
                new Coleta
                {
                    id = 3,
                    descricao = "Enviado"

                }
                               );

        }
    }
}
