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
		public new int Id { get; set; }

		[Column("nom")]
		public new String Nom { get; set; }

		[Column("prenom")]
		public new String Prenom { get; set; }

		[Column("statut")]
		public new int Statut { get; set; }
		[Column("estVIP")]
		public int estVIP { get; set; }

		[Column("estCalomniateur")]
		public new int estCalomniateur { get; set; }
		[Column("role")]
		public new int Role { get; set; }

		[Column("adresse")]
		public new string Adresse { get; set; }

	}
}
