using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using testesenior.Domain.Entity;

namespace TesteSenior.Data.Config
{
    public class MetricasTipoMesConfiguration : IEntityTypeConfiguration<MetricasTipoMes>
    {
        public void Configure(EntityTypeBuilder<MetricasTipoMes> builder)
        {

            builder.HasKey(e => e.ID)
                .HasName("Metricas_Tipo_Mes_ID");

            builder.Property(e => e.ID)
                .ValueGeneratedOnAdd()
                .HasMaxLength(50)
                .HasColumnName("Metricas_Tipo_Mes_ID");

            builder.ToView("Metricas_Tipo_Mes");

            builder.Property(e => e.Mes)
                    .HasMaxLength(9)
                    .IsUnicode(false);

            builder.Property(e => e.Tipo).HasMaxLength(50);


        }
    }
}
