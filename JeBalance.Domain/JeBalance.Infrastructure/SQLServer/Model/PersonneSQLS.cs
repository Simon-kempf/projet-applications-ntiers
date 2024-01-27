using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.SQLServer.Model
{
	[Table("PERSONNES")]
	public class PersonneSQLS : Personne
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("nom")]
		public String Nom { get; set; }

		[Column("prenom")]
		public String Prenom { get; set; }

		[Column("statut")]
		public int Statut { get; set; }

	}
}
