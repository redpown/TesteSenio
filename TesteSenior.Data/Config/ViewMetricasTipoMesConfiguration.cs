using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using testesenior.Domain.Entity;

namespace TesteSenior.Data.Config
{
    public class ViewMetricasTipoMesConfiguration : IEntityTypeConfiguration<ViewMetricasTipoMes>
    {
        public void Configure(EntityTypeBuilder<ViewMetricasTipoMes> builder)
        {

            builder.HasNoKey();
            
            builder.ToView("vw_Metricas_Tipo_Mes");

            builder.Property(e => e.Mes)
                    .HasMaxLength(9)
                    .IsUnicode(false);

            builder.Property(e => e.Tipo).HasMaxLength(50);

        }
    }
}
