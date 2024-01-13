using JeBalance.Domain.ValueObjects;
using JeBalance.Infrastructure.SQLServer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JeBalance.Infrastructure.SQLServer.Configurations
{
	internal class PersonneConfiguration : IEntityTypeConfiguration<PersonneSQLS>
	{
		public void Configure(EntityTypeBuilder<PersonneSQLS> builder)
		{
			builder
 .ToTable("PLACES", DatabaseContext.DEFAULT_SCHEMA)
 .HasKey(personne => personne.Id);
			builder.Property(personne => personne.Nom)
			.IsRequired().HasMaxLength(Nom.MAX_LENGTH);
			builder.Property(personne => personne.Prenom)
			.IsRequired().HasMaxLength(Prenom.MAX_LENGTH);
			builder.Property(personne => personne.Statut)
			.IsRequired().HasColumnType("string");
		}
	}
}
