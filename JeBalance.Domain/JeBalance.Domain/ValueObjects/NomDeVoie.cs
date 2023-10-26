using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class NomDeVoie : SimpleValueObject<string>
{
    private const int MIN_LENGTH = 2;
    private const int MAX_LENGTH = 50;

    public NomDeVoie(string value) : base(value)
    {
    }

    public override string Validate(string value)
    {
        var trimmedValue = value.Trim();

        if (string.IsNullOrEmpty(trimmedValue)) throw new ApplicationException("Le nom de la voie ne peut pas être vide");

        if (trimmedValue.Length < MIN_LENGTH) throw new ApplicationException($"Le nombre de caractères du nom de la voie doit être supérieur à  {MIN_LENGTH}");

        if (trimmedValue.Length > MAX_LENGTH) throw new ApplicationException($"Le nombre de caractères du nom de la voie doit être inférieur à {MAX_LENGTH}");

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