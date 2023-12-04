using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Model
{
    internal class Reponse : Entity
    {
        private Type Type { get; }
        private int? Retribution { get; }
        public Reponse(Type type, int? retribution) : base(0)
        {
            Type = type;
            if (retribution != null) { Retribution = retribution; }
        }

        public Reponse(int id, Type type, int? retribution) : base(id)
        {
            Type = type;
            if (retribution != null) { Retribution = retribution; }
        }
    }
}
