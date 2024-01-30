using JeBalance.Infrastructure.SQLServer.Configurations;
using JeBalance.Infrastructure.SQLServer.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.SQLServer
{
    public class DatabaseContext : DbContext
    {
		public const string DEFAULT_SCHEMA = "app";
		public DbSet<PersonneSQLS> Personnes { get; set; }
		public DbSet<DenonciationSQLS> Denonciations { get; set; }
		public DbSet<PersonneSQLS> VIPs { get; set; }

		public DatabaseContext()
		{
		}
 public DatabaseContext(DbContextOptions<DbContext> options)
 : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new DenonciationConfiguration());
			modelBuilder.ApplyConfiguration(new PersonneConfiguration());
			//modelBuilder.ApplyConfiguration(new ReponseConfiguration());
			//modelBuilder.ApplyConfiguration(new VIPConfiguration());
			base.OnModelCreating(modelBuilder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder
	   optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JeBalance;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		    }
		}

	}
}
