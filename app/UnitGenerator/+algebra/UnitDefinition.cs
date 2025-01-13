using System;
using System.Collections.Generic;
using iSukces.Code;

namespace UnitGenerator;

public class UnitDefinition : IEquatable<UnitDefinition>
{
    public UnitDefinition(string className, string unit, string description)
        :this((CsType)className, unit, description)
    {
            
    }
    public UnitDefinition(CsType className, string unit, string description)
    {
        Description = description;
        ClassName   = className;
        Unit        = unit;
    }

    public static bool operator ==(UnitDefinition? left, UnitDefinition? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(UnitDefinition? left, UnitDefinition? right)
    {
        return !Equals(left, right);
    }

    public void AddMul(UnitDefinition a, UnitDefinition b, UnitDefinition result)
    {
        MulsAndDivs.Add(new MulDivDefinition(a, b, result, "*"));
        // a * b = result
        // result / a = b
        // result / b = a
        if (result.Equals(Scalar))
        {
            a.MulsAndDivs.Add(new MulDivDefinition(result, a, b, "/"));
            if (!b.Equals(a))
                b.MulsAndDivs.Add(new MulDivDefinition(result, b, a, "/"));
        }
        else
        {
            result.MulsAndDivs.Add(new MulDivDefinition(result, a, b, "/"));
            if (!b.Equals(a))
                result.MulsAndDivs.Add(new MulDivDefinition(result, b, a, "/"));
        }
    }


    public bool Equals(UnitDefinition? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(ClassName, other.ClassName);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((UnitDefinition)obj);
    }

    public override int GetHashCode()
    {
        return ClassName != null ? ClassName.GetHashCode() : 0;
    }

    public override string ToString()
    {
        return Unit;
    }

    public static UnitDefinition Scalar => new UnitDefinition(CsType.Double, "scalar value", "Scalar value");

    public string Description { get; set; }

    public CsType                 ClassName   { get; }
    public string                 Unit        { get; }
    public List<MulDivDefinition> MulsAndDivs { get; } = new List<MulDivDefinition>();
}
