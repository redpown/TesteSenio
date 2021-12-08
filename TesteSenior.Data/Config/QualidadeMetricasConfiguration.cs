using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using testesenior.Domain.Entity;

namespace TesteSenior.Data.Config
{
    public class QualidadeMetricasConfiguration : IEntityTypeConfiguration<QualidadeMetricas>
    {
        public void Configure(EntityTypeBuilder<QualidadeMetricas> builder)
        {
            builder.ToTable("TABELA_QUALIDADEMETRICAS");

            builder.HasKey(tabelaQUALIDADEMETRICAS => tabelaQUALIDADEMETRICAS.qmId)
                .HasName("QUALIDADEMETRICAS_IDS");

            builder.Property(tabelaQUALIDADEMETRICAS => tabelaQUALIDADEMETRICAS.qmId)
                .ValueGeneratedOnAdd()
                .HasMaxLength(50)
                .HasColumnName("QM_ID");


            builder.Property(tabelaQUALIDADEMETRICAS => tabelaQUALIDADEMETRICAS.qmColetaId)
                .HasMaxLength(50)
                .HasColumnName("QM_COLETA_ID");

            builder.Property(tabelaQUALIDADEMETRICAS => tabelaQUALIDADEMETRICAS.qmExameId)
                .HasMaxLength(50)
                .HasColumnName("QM_EXAME_ID");

            builder.Property(tabelaQUALIDADEMETRICAS => tabelaQUALIDADEMETRICAS.qmExameStatusId)
                .HasMaxLength(256)
                .HasColumnName("QM_EXAME_STATUS_ID");

            builder.Property(tabelaQUALIDADEMETRICAS => tabelaQUALIDADEMETRICAS.qmQuantidade)
              .HasMaxLength(256)
              .HasColumnName("QM_QUANTIDADE");

            builder.Property(tabelaQUALIDADEMETRICAS => tabelaQUALIDADEMETRICAS.qmTipoExame)
             .HasMaxLength(256)
             .HasColumnName("QM_TIPO");

            builder.Property(tabelaQUALIDADEMETRICAS => tabelaQUALIDADEMETRICAS.qmTotal)
             .HasMaxLength(256)
             .HasColumnName("QM_TOTAL");

            builder.Property(tabelaQUALIDADEMETRICAS => tabelaQUALIDADEMETRICAS.qmData)
             .HasMaxLength(256)
             .HasColumnType("date")
             .HasColumnName("QM_DATA");
            
            builder.HasData(

                new QualidadeMetricas
                {
                    qmId = 1,
                    qmColetaId = 1,
                    qmExameId = 1,
                    qmQuantidade = 1,
                    qmTipoExame = 1,
                    qmExameStatusId =1,
                    qmTotal = 1,
                    qmData = DateTime.ParseExact("2011-10-10", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None)
                },
                new QualidadeMetricas
                {
                    qmId = 2,
                    qmColetaId = 2,
                    qmExameId = 2,
                    qmQuantidade = 2,
                    qmTipoExame = 2,
                    qmExameStatusId = 2,
                    qmTotal = 2,
                    qmData = DateTime.ParseExact("2015-10-31", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None)
                }



               );
            
        }
    }
}

