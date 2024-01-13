using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.SQLServer.Model
{
	public class PersonneSQLS
	{
		[Column("id")]
		public int Id { get; set; }

		[Column("nom")]
		public Nom Nom { get; set; } = new Nom(string.Empty);

		[Column("prenom")]
		public Prenom Prenom { get; set; } = new Prenom(string.Empty);

		[Column("statut")]
		public Statut Statut { get; set; }

	}
}
