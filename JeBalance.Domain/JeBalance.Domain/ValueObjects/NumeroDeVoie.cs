using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;
public class NumeroDeVoie : SimpleValueObject<int>
{
    private const int MIN = 1;
    private const int MAX = 999;

    public NumeroDeVoie(int value) : base(value)
    {
    }

	public NumeroDeVoie() : base(1)
	{
	}

	public override int Validate(int value)
    {

        if (value < MIN) throw new ApplicationException($"Le numéro de voie ne peux pas être inférieur à {MIN}");

        if (value > MAX) throw new ApplicationException($"Le numéro de voie ne peux pas être supérieur à {MAX}");

        return value;
    }

    public static bool operator <(NumeroDeVoie a, int b) => a.Value < b;
    public static bool operator >(NumeroDeVoie a, int b) => a.Value > b;
    public static bool operator <=(NumeroDeVoie a, int b) => a.Value <= b;
    public static bool operator >=(NumeroDeVoie a, int b) => a.Value >= b;
    public static bool operator ==(NumeroDeVoie a, int b) => a.Value == b;
    public static bool operator !=(NumeroDeVoie a, int b) => a.Value != b;

    public override bool Equals(object? obj) => Value.Equals(obj);
    public override int GetHashCode() => Value.GetHashCode();
}