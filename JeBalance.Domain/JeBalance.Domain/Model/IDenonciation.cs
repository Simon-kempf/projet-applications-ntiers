using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Model
{
    public abstract class IDenonciation : Entity
    {
        public IDenonciation(int id) : base(id)
        {
        }
        public DateTime? Horodatage { get; set; }
        public Personne? Informateur { get; set; }
        public Personne? Suspect { get; set; }
        public Delit? Delit { get; set; }
        public PaysEvasion? PaysEvasion { get; set; }
        public Reponse? Reponse { get; set; }
        public bool EstTraitee { get; set; } = false;
    }
}
