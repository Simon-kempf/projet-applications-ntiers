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
    internal class VIPConfiguration : IEntityTypeConfiguration<VIPSQLS>
    {
        public void Configure(EntityTypeBuilder<VIPSQLS> builder)
        {
            builder
 .ToTable("VIP", DatabaseContext.DEFAULT_SCHEMA)
 .HasKey(VIP => VIP.Id);
            builder.Property(VIP => VIP.Nom)
            .IsRequired().HasMaxLength(Nom.MAX_LENGTH);
            builder.Property(VIP => VIP.Prenom)
            .IsRequired().HasMaxLength(Prenom.MAX_LENGTH);
            builder.Property(VIP => VIP.Statut)
            .IsRequired().HasColumnType("string");
        }
    }
}
