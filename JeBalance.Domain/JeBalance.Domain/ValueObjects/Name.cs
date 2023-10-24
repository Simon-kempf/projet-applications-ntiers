using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;

public class Name : SimpleValueObject<string>
{
    private const int MIN_LENGTH = 3;
    private const int MAX_LENGTH = 150;

    public Name(string value) : base(value)
    {
    }

    public override string Validate(string value)
    {
        var trimmedValue = value.Trim();

        if(string.IsNullOrEmpty(trimmedValue)) throw new ApplicationException("Name cannot be empty");
        
        if(trimmedValue.Length < MIN_LENGTH) throw new ApplicationException($"Name cannot be less than {MIN_LENGTH} character(s)");

        if(trimmedValue.Length > MAX_LENGTH) throw new ApplicationException($"Name cannot be more than {MAX_LENGTH} characters");

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