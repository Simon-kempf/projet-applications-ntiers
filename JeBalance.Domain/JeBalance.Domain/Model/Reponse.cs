using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Model
{
    public class Reponse : Entity
    {
        public DateTime Horodatage { get; }
        public Type Type { get; }
        public int? Retribution { get; }
        public Reponse(DateTime horodatage, Type type, int? retribution) : base(0)
        {
            Horodatage = horodatage;
            Type = type;
            if (retribution != null) { Retribution = retribution; }
        }

        public Reponse(DateTime horodatage, int id, Type type, int? retribution) : base(id)
        {
            Horodatage = horodatage;
            Type = type;
            if (retribution != null) { Retribution = retribution; }
        }
    }
}
