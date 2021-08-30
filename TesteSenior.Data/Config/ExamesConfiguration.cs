using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using testesenior.Domain.Entity;

namespace TesteSenior.Data.Config
{
    public class ExameConfiguration : IEntityTypeConfiguration<Exames>
    {
        public void Configure(EntityTypeBuilder<Exames> builder)
        {
            builder.ToTable("TABELA_EXAMES");

            builder.HasKey(tabelaExame => tabelaExame.id)
                .HasName("EXAMES_IDS");

            builder.Property(tabelaExame => tabelaExame.id)
                .ValueGeneratedOnAdd()
                .HasMaxLength(50)
                .HasColumnName("EXAMES_ID");
               

            builder.Property(tabelaExame => tabelaExame.descricao)
                .HasMaxLength(50)
                .HasColumnName("EXAME_DESCRICAO");

            builder.HasMany(b => b.qmId)
            .WithOne()
            .HasForeignKey(x => x.qmExameId);

            builder.HasData(

                new Coleta
                {
                    id = 1,
                    descricao = "Ureia"

                },
                new Coleta
                {
                    id = 2,
                    descricao = "Creatinina"

                },
                new Coleta
                {
                    id = 3,
                    descricao = "Urina 1"

                },
                new Coleta
                {
                    id = 4,
                    descricao = "Hemograma"

                },
                new Coleta
                {
                    id = 5,
                    descricao = "LDH"

                },
                new Coleta
                {
                    id = 6,
                    descricao = "Ácido Úrico"

                },
                new Coleta
                {
                    id = 7,
                    descricao = "HIV"

                },
                new Coleta
                {
                    id = 8,
                    descricao = "HBSAG"

                }
                               );

        }
    }
}
