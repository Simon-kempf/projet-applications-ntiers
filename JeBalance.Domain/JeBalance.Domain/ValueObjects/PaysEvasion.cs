using JeBalance.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeBalance.Domain.ValueObjects
{
    public class PaysEvasion : SimpleValueObject<String>
    {
        private const int MAX_LENGTH = 50;

        public PaysEvasion(string value) : base(value)
        {
        }

		public PaysEvasion() : base("Non renseigné")
		{
		}

		public override string Validate(string value)
        {
            var trimmedValue = value.Trim();

            if (trimmedValue.Length > MAX_LENGTH) throw new ApplicationException($"Le nombre de caractères du nom d'un pays doit être inférieur à {MAX_LENGTH}");

            return trimmedValue;
        }

        public override bool Equals(object? obj)
        {
            return Value == obj?.ToString();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
