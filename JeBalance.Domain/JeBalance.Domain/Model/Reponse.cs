using JeBalance.Domain.Contracts;
using JeBalance.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.Model
{
    public class Reponse
    {
        public DateTime Horodatage { get; }
        public Type Type { get; }
        public int? Retribution { get; }
        public Reponse(DateTime horodatage, Type type, int? retribution)
        {
            Horodatage = horodatage;
            Type = type;
            if (retribution != null) { Retribution = retribution; }
        }

		public Reponse()
		{
		}

		public override bool Equals(object? obj)
		{
			return obj is Reponse reponse &&
				   Horodatage == reponse.Horodatage &&
				   Type == reponse.Type &&
				   Retribution == reponse.Retribution;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Horodatage, Type, Retribution);
		}
	}
}
