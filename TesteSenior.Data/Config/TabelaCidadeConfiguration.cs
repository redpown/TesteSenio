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

            builder.HasKey(tabelaCidade => tabelaCidade.codigoCidade).HasName("CODIGO_CIDADE_ID");

            builder.Property(tabelaCidade => tabelaCidade.codigoCidade)
               .ValueGeneratedOnAdd()
               .HasMaxLength(50)
               .HasColumnName("CODIGO_CIDADE");

            builder.Property(tabelaCidade => tabelaCidade.nomeCidade)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnName("NOME_CIDADE");
            
            builder.Property(tabelaCidade => tabelaCidade.estado)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnName("ESTADO");
            
            builder.HasData(
                  
                  new { codigoCidade = 1,nomeCidade = "Campinas", estado = "SP" },
                  new { codigoCidade = 2,nomeCidade = "Rio de Janeiro", estado = "RJ" },
                  new { codigoCidade = 3,nomeCidade = "São Paulo", estado = "SP" },
                  new { codigoCidade = 4,nomeCidade = "Sorocaba", estado = "SP" },
                  new { codigoCidade = 5,nomeCidade = "Jundiaí", estado = "SP" },
                  new { codigoCidade = 6,nomeCidade = "Hortolândia", estado = "SP" }

                );


        }
    }
}
