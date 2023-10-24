using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class Nom : SimpleValueObject<string>
{
    private const int MIN_LENGTH = 2;
    private const int MAX_LENGTH = 50;

    public Nom(string value) : base(value)
    {
    }

    public override string Validate(string value)
    {
        var trimmedValue = value.Trim();

        if(string.IsNullOrEmpty(trimmedValue)) throw new ApplicationException("Le nom ne peut pas �tre vide");
        
        if(trimmedValue.Length < MIN_LENGTH) throw new ApplicationException($"Le nombre de caract�res du nom doit �tre sup�rieur �  {MIN_LENGTH}");

        if(trimmedValue.Length > MAX_LENGTH) throw new ApplicationException($"Le nombre de caract�res du nom doit �tre inf�rieur � {MAX_LENGTH}");

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