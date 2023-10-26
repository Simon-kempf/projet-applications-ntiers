using JeBalance.Domain.Contracts;

namespace JeBalance.Domain.ValueObjects;
public class IdDenonciation : SimpleValueObject<int>
{
    private const int MIN = 0;

    public IdDenonciation(int value) : base(value)
    {
    }

    public override int Validate(int value)
    {

        if (value < MIN) throw new ApplicationException($"L'ID ne peut pas être inférieur à {MIN}");

        return value;
    }

    public static bool operator <(IdDenonciation a, int b) => a.Value < b;
    public static bool operator >(IdDenonciation a, int b) => a.Value > b;
    public static bool operator <=(IdDenonciation a, int b) => a.Value <= b;
    public static bool operator >=(IdDenonciation a, int b) => a.Value >= b;
    public static bool operator ==(IdDenonciation a, int b) => a.Value == b;
    public static bool operator !=(IdDenonciation a, int b) => a.Value != b;

    public override bool Equals(object? obj) => Value.Equals(obj);
    public override int GetHashCode() => Value.GetHashCode();
}