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

            builder.HasKey(tabelaExame => tabelaExame.ID)
                .HasName("EXAMES_STATUS_IDS");

            builder.Property(tabelaExame => tabelaExame.ID)
                .ValueGeneratedOnAdd()
                .HasMaxLength(50)
                .HasColumnName("EXAMES_STATUS_ID");
               

            builder.Property(tabelaExame => tabelaExame.Descricao)
                .HasMaxLength(50)
                .HasColumnName("EXAMES_STATUS_DESCRICAO");

          builder.HasMany(b => b.QmID)
          .WithOne()
          .HasForeignKey(x => x.qmExameStatusId);

            builder.HasData(

                new ExameStatus
                {
                    ID = 1,
                    Descricao = "Aguardando Liberação"

                },
                new ExameStatus
                {
                    ID = 2,
                    Descricao = "Liberado"

                },
                new ExameStatus
                {
                    ID = 3,
                    Descricao = "Enviado"

                }
                               );

        }
    }
}
