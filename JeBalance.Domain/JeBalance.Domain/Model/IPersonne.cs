using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Model
{
    public abstract class IPersonne : Entity
    {
        public IPersonne(int id) : base(id)
        {
        }

        public Nom? Nom { get; set; }

        public Prenom? Prenom { get; set; }
        public Statut Statut { get; set; }
    }
}
