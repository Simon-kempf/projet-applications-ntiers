using JeBalance.Infrastructure.SQLServer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.SQLServer.Configurations
{
    internal class ReponseConfiguration : IEntityTypeConfiguration<ReponseSQLS>
    {
        public void Configure(EntityTypeBuilder<ReponseSQLS> builder)
        {
            builder
                .ToTable("REPONSES", DatabaseContext.DEFAULT_SCHEMA)
                .HasKey(reponse => reponse.Id);
            builder.Property(denonciation => denonciation.Horodatage)
                .IsRequired();
            builder.Property(denonciation => denonciation.Type)
                .IsRequired();
            builder.Property(denonciation => denonciation.Retribution);
        }
    }
}
