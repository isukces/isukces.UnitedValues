using System.Collections.Generic;
using iSukces.Code;

namespace UnitGenerator;

public class BasicUnit : IUnitInfo
{
    public override string ToString()
    {
        return BaseUnit.ToString();
    }

    public string BaseUnitField
    {
        get { return BaseUnit.Field; }
    }

    public BasicUnit(string valueTypeName, string mainUnit, bool isComparable)
    {
        UnitTypes    = new TypesGroup(new XValueTypeName(valueTypeName));
        IsComparable = isComparable;
        BaseUnit     = new TypeAndFieldName(UnitTypes.Container.GetTypename(), mainUnit);
    }


    /// <summary>
    ///     Types like {Force, ForceUnit, ForceUnits}
    /// </summary>
    public TypesGroup UnitTypes { get; }

    public bool IsComparable { get; }

    /// <summary>
    ///     Base unit name (also property name in *Units class i.e. Newton
    /// </summary>
    public TypeAndFieldName BaseUnit { get; }

    public IEnumerable<string> Interfaces
    {
        get
        {
            yield return $"IUnitedValue<{UnitTypes.Unit}>";
            yield return $"IEquatable<{UnitTypes.Value}>";
            if (IsComparable)
                yield return $"IComparable<{UnitTypes.Value}>";
            yield return "IFormattable";
        }
    }
}
