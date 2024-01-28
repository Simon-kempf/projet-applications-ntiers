using JeBalance.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.SQLServer.Model
{
	[Table("DENONCIATIONS")]
	public class DenonciationSQLS : Denonciation
    {
        [Column("id")]
        public new int Id { get; set; }

        
        [Column("delit")]
        public new int Delit { get; set; } 


        [Column("statutInfo")]
        public int StatutInfo { get; set; }


        [Column("statutSuspect")]
        public int StatutSuspect { get; set; }


        [Column("horodatage")]
        public new DateTime Horodatage { get; set; }


		[Column("paysEvasion")]
		public new string PaysEvasion { get; set; }


		[Column("informateur")]
		public string Informateur { get; set; }


		[Column("suspect")]
		public string Suspect { get; set; }


		[Column("reponse")]
		public string Reponse { get; set; }
	}
}
