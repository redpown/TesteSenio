using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesenior.domain.Entity;
using testesenior.Domain.DTO;

namespace TesteSenior.Data.Config
{
    public class SPRankingCondominioConfiguration : IEntityTypeConfiguration<SPRankingCondominio>
    {
        public void Configure(EntityTypeBuilder<SPRankingCondominio> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.codigoApartamento).HasColumnName("CODIGO_APARTAMENTO");
            builder.Property(e => e.codigoEdificio).HasColumnName("CODIGO_EDIFICIO");
            builder.Property(e => e.nomeEdificio).HasColumnName("NOME_EDIFICIO");
            builder.Property(e => e.metragem).HasColumnName("METRAGEM");
            builder.Property(e => e.andar).HasColumnName("ANDAR");
            builder.Property(e => e.nomeCidade).HasColumnName("NOME_CIDADE");
            builder.Property(e => e.estado).HasColumnName("ESTADO");
            builder.Property(e => e.codigoApartamento).HasColumnName("CODIGO_APARTAMENTO");
            builder.Property(e => e.valorPagamento).HasColumnName("VALOR_PAGAMENTO");
            builder.Property(e => e.numeroQuartos).HasColumnName("NUMERO_QUARTOS");

        }
    }
}
