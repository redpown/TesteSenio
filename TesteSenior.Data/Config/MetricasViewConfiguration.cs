using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using testesenior.Domain.Entity;

namespace TesteSenior.Data.Config
{
    public class MetricasViewConfiguration : IEntityTypeConfiguration<Metrica>
    {
        public void Configure(EntityTypeBuilder<Metrica> builder)
        {

            builder.HasKey(e => e.ID)
                .HasName("Metricas_ID");

            builder.Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .HasMaxLength(50)
                .HasColumnName("Metricas_ID");

            builder.ToView("Metricas");

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
