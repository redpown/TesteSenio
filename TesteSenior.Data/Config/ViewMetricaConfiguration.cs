using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using testesenior.Domain.Entity;

namespace TesteSenior.Data.Config
{
    public class ViewMetricaConfiguration : IEntityTypeConfiguration<ViewMetrica>
    {
        public void Configure(EntityTypeBuilder<ViewMetrica> builder)
        {

            builder.HasNoKey();

            builder.ToView("vw_Metricas");

            builder.Property(e => e.Coleta).HasMaxLength(50);

            builder.Property(e => e.Exame).HasMaxLength(50);

            builder.Property(e => e.Mes)
                    .HasMaxLength(9)
                    .IsUnicode(false);

            builder.Property(e => e.Status).HasMaxLength(50);

            builder.Property(e => e.Tipo).HasMaxLength(50);
          
            

        }
    }
}
