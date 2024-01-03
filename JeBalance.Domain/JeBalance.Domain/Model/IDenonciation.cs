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
        public IPersonne? Informateur { get; }
        public IPersonne? Suspect { get; }
        public Delit? Delit { get; }
        public PaysEvasion? PaysEvasion { get; }
    }
}
