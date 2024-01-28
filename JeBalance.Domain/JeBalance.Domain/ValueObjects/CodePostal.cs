using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;
public class CodePostal : SimpleValueObject<int>
{
    private const int MIN = 1;
    private const int MAX = 99999;

    public CodePostal(int value) : base(value)
    {
    }

	public CodePostal() : base(1)
	{
	}

	public override int Validate(int value) { 

        if (value < MIN) throw new ApplicationException($"Le code postal ne peux pas être inférieur à {MIN}");

        if (value > MAX) throw new ApplicationException($"Le code postal ne peux pas être supérieur à {MAX}");

        return value;
    }

    public static bool operator <(CodePostal a, int b) => a.Value < b;
    public static bool operator >(CodePostal a, int b) => a.Value > b;
    public static bool operator <=(CodePostal a, int b) => a.Value <= b;
    public static bool operator >=(CodePostal a, int b) => a.Value >= b;
    public static bool operator ==(CodePostal a, int b) => a.Value == b;
    public static bool operator !=(CodePostal a, int b) => a.Value != b;

    public override bool Equals(object? obj) => Value.Equals(obj);
    public override int GetHashCode() => Value.GetHashCode();
}