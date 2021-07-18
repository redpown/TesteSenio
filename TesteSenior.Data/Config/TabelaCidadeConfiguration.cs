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
    public class TabelaCidadeConfiguration : IEntityTypeConfiguration<TabelaCidade>
    {
        public void Configure(EntityTypeBuilder<TabelaCidade> builder)
        {
            builder.ToTable("TABELA_CIDADE");

            builder.HasKey(tabelaCidade => tabelaCidade.codigoCidade);

            builder.Property(tabelaCidade => tabelaCidade.nomeCidade)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(tabelaCidade => tabelaCidade.estado)
                .IsRequired()
                .HasMaxLength(2);

            builder.HasData(
                  
                  new { nomeCidade = "Campinas", estado = "SP" },
                  new { nomeCidade = "Rio de Janeiro", estado = "RJ" },
                  new { nomeCidade = "São Paulo", estado = "SP" },
                  new { nomeCidade = "Sorocaba", estado = "SP" },
                  new { nomeCidade = "Jundiaí", estado = "SP" },
                  new { nomeCidade = "Hortolândia", estado = "SP" }

                );


        }
    }
}
