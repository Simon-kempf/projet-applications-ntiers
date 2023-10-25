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
        private const int MIN_LENGTH = 2;
        private const int MAX_LENGTH = 50;

        public PaysEvasion(string value) : base(value)
        {
        }

        public override string Validate(string value)
        {
            var trimmedValue = value.Trim();

            if (string.IsNullOrEmpty(trimmedValue)) throw new ApplicationException("Le nom d'un pays ne peut pas être vide");

            if (trimmedValue.Length < MIN_LENGTH) throw new ApplicationException($"Le nombre de caractères du nom d'un pays doit être supérieur à  {MIN_LENGTH}");

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
