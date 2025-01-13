using System;

namespace UnitGenerator;

public class MulDivDefinition : IEquatable<MulDivDefinition>
{
    public MulDivDefinition(UnitDefinition left, UnitDefinition right, UnitDefinition result, string @operator)
    {
        Left     = left;
        Right    = right;
        Result   = result;
        Operator = @operator;
    }

    public static bool operator ==(MulDivDefinition? left, MulDivDefinition? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(MulDivDefinition? left, MulDivDefinition? right)
    {
        return !Equals(left, right);
    }


    public bool Equals(MulDivDefinition? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(Description, other.Description);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((MulDivDefinition)obj);
    }

    public override int GetHashCode()
    {
        return Description.GetHashCode();
    }

    public MulDivDefinition GetSwap()
    {
        return new MulDivDefinition(Right, Left, Result, Operator);
    }

    public override string ToString()
    {
        return Description;
    }

    public UnitDefinition Left   { get; }
    public UnitDefinition Right  { get; }
    public UnitDefinition Result { get; }

    public string Operator { get; }

    public string Description => $"{Right.Unit} {Operator} {Left.Unit} = {Result.Unit}";
}
