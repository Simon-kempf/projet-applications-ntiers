using JeBalance.Domain.ValueObjects;
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
    internal class DenonciationConfiguration : IEntityTypeConfiguration<DenonciationSQLS>
    {
        public void Configure(EntityTypeBuilder<DenonciationSQLS> builder)
        {
            builder
                .ToTable("DENONCIATIONS", DatabaseContext.DEFAULT_SCHEMA)
                .HasKey(denonciation => denonciation.Id);
			builder.Property(denonciation => denonciation.Informateur)
				.IsRequired();
			builder.Property(denonciation => denonciation.Suspect)
				.IsRequired();
			builder.Property(denonciation => denonciation.Delit)
                .IsRequired();
            builder.Property(denonciation => denonciation.StatutInfo)
                .IsRequired();
            builder.Property(denonciation => denonciation.StatutSuspect)
                .IsRequired();
            builder.Property(denonciation => denonciation.Horodatage)
                .IsRequired();
			builder.Property(denonciation => denonciation.PaysEvasion)
				.IsRequired();
            builder.Property(denonciation => denonciation.Reponse)
                .IsRequired();
            builder.Property(denonciation => denonciation.EstTraitee)
                .IsRequired().HasColumnType("bit");
		}
    }
}
