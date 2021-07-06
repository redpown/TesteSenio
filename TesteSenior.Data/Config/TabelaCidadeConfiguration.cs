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
            //builder.ToTable("teste");
            builder.HasKey(tabelaCidade => tabelaCidade.codigoCidade);

            builder.Property(tabelaCidade => tabelaCidade.nomeCidade)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(tabelaCidade => tabelaCidade.estado)
                .IsRequired()
                .HasMaxLength(2);
                      
            
        }
    }
}
