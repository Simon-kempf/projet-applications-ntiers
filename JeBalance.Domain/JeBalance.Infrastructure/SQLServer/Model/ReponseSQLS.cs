using JeBalance.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Infrastructure.SQLServer.Model
{
    public class ReponseSQLS
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("horodatage")]
        public DateTime Horodatage { get; set; }
        [Column("type")]
        public int Type { get; set; }
        [Column("retribution")]
        public int Retribution { get; set; }
    }
}
