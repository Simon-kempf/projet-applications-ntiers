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
        public DateTime horodatage { get; set; }
        [Column("type")]
        public Domain.Model.Type type { get; set; }
        [Column("retribution")]
        public int retribution { get; set; }
    }
}
