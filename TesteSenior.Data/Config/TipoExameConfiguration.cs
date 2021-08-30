using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using testesenior.Domain.Entity;

namespace TesteSenior.Data.Config
{
    public class TipoExameConfiguration : IEntityTypeConfiguration<TipoExame>
    {
        public void Configure(EntityTypeBuilder<TipoExame> builder)
        {
            builder.ToTable("TABELA_TIPO_EXAME");

            builder.HasKey(tabelaExame => tabelaExame.id)
                .HasName("TIPO_EXAME_IDS");

            builder.Property(tabelaExame => tabelaExame.id)
                .ValueGeneratedOnAdd()
                .HasMaxLength(50)
                .HasColumnName("TIPO_EXAMES_ID");
               

            builder.Property(tabelaExame => tabelaExame.descricao)
                .HasMaxLength(50)
                .HasColumnName("TIPO_EXAME_DESCRICAO");

            builder.HasMany(b => b.qmId)
            .WithOne()
            .HasForeignKey(x=>x.qmTipoExame);

            builder.HasData(

               new Coleta
               {
                   id = 1,
                   descricao = "Interno"

               },
               new Coleta
               {
                   id = 2,
                   descricao = "Externo"

               }

               );


        }
    }
}
