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
        [Column("nom")]
        public Nom Nom { get; set; } = new Nom(string.Empty);

        [Column("prenom")]
        public Prenom Prenom { get; set; } = new Prenom(string.Empty);

        [Column("statut")]
        public Statut Statut { get; set; } = Statut.VIP;
    }
}
