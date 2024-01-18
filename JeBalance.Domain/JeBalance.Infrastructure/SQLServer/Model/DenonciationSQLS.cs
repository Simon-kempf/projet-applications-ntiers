using JeBalance.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.SQLServer.Model
{
    public class DenonciationSQLS
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("idInformateur")]
        public int IdInformateur { get; set; }
        [Column("idSuspect")]
        public int IdSuspect { get; set; }
        [Column("delit")]
        public Delit Delit { get; set; }
        [Column("statutInfo")]
        public Statut statutInfo { get; set; }
        [Column("statutSuspect")]
        public Statut statutSuspect { get; set; }
        [Column("horodatage")]
        public DateTime horodatage { get; set; }
    }
}
