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
    public class VIPSQLS : Personne
    {
        [Column("id")]
        public new int Id { get; set; }

        [Column("nom")]
        public new String Nom { get; set; } = new Nom(string.Empty).ToString()!;

        [Column("prenom")]
        public new String Prenom { get; set; } = new Prenom(string.Empty).ToString()!;

        [Column("statut")]
        public new int Statut { get; set; } = 4;
    }
}
