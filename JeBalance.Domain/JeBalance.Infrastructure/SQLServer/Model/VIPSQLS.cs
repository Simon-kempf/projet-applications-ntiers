using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using JeBalance.Infrastructure.SQLServer.Model;
using JeBalance.Domain.Model;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Infrastructure.SQLServer.Model
{
    public class VIPSQLS
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nom")]
        public String Nom { get; set; } = new Nom(string.Empty).ToString()!;

        [Column("prenom")]
        public String Prenom { get; set; } = new Prenom(string.Empty).ToString()!;

        [Column("statut")]
        public int Statut { get; set; } = 4;
    }
}
