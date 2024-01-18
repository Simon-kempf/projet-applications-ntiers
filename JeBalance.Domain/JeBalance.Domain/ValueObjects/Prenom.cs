using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class Prenom : SimpleValueObject<string>
{
    public const int MIN_LENGTH = 2;
    public const int MAX_LENGTH = 50;

	public Prenom() : base("")
	{
	}
	public Prenom(string value) : base(value)
    {
    }

    public override string Validate(string value)
    {
        var trimmedValue = value.Trim();

        if(string.IsNullOrEmpty(trimmedValue)) throw new ApplicationException("Le pr�nom ne peut pas �tre vide");
        
        if(trimmedValue.Length < MIN_LENGTH) throw new ApplicationException($"Le nombre de caract�res du pr�nom doit �tre sup�rieur �  {MIN_LENGTH}");

        if(trimmedValue.Length > MAX_LENGTH) throw new ApplicationException($"Le nombre de caract�res du pr�nom doit �tre inf�rieur � {MAX_LENGTH}");

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