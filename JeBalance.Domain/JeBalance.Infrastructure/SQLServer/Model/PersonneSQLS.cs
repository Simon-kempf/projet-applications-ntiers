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
	public class PersonneSQLS : Personne
	{
		[Column("id")]
		public new int Id { get; set; }

		[Column("nom")]
		public new String Nom { get; set; } = new Nom(string.Empty).ToString()!;

		[Column("prenom")]
		public new String Prenom { get; set; } = new Prenom(string.Empty).ToString()!;

		[Column("statut")]
		public new int Statut { get; set; } = 0;

	}
}
