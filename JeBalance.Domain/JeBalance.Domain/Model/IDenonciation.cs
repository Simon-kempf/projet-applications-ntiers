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
        public IPersonne? Informateur { get; set; }
        public IPersonne? Suspect { get; set; }
        public Delit? Delit { get; set; }
        public PaysEvasion? PaysEvasion { get; set; }
        private Reponse? Reponse { get; set; }
    }
}
