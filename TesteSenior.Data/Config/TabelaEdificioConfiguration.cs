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
            
            builder.HasKey(tabelaEdificio => tabelaEdificio.codigoEdificio);

            builder.Property(tabelaEdificio => tabelaEdificio.andares)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(tabelaEdificio => tabelaEdificio.numeroAptoAndar)
                .IsRequired()
                .HasMaxLength(12);
                                   
        }
    }
}
