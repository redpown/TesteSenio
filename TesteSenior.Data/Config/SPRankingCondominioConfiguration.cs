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

            
        }
    }
}
