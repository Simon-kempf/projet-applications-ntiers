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
		public DbSet<PersonneSQLS> Places { get; set; }
		public DatabaseContext()
		{
		}
 public DatabaseContext(DbContextOptions<DbContext> options)
 : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new PersonneConfiguration());
			base.OnModelCreating(modelBuilder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder
	   optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=" +
					"(localdb)\\MSSQLLocalDB; Initial Catalog = ParkNGo; " +
					"IntegratedSecurity = True; ApplicationIntent = ReadWrite; " +
					"MultiSubnetFailover = False");
		    }
		}

	}
}
