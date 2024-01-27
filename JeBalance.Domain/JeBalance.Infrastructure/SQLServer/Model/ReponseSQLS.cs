using JeBalance.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.SQLServer.Model
{
    public class ReponseSQLS : Reponse
    {
        
        [Column("horodatage")]
        public new DateTime Horodatage { get; set; }
        [Column("type")]
        public new int Type { get; set; }
        [Column("retribution")]
        public new int Retribution { get; set; }
    }
}
