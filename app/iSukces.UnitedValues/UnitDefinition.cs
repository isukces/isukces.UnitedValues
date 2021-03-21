using System;
using System.Collections.Generic;

namespace iSukces.UnitedValues
{
    public struct UnitDefinition<TUnit> : IUnitNameContainer
        where TUnit : IUnit
    {
        public UnitDefinition(string unitName, decimal multiplication, params string[] aliases)
        {
            UnitName = unitName;
            Multiplication = multiplication;
            Aliases = aliases ?? new string[0];
        }

        public string UnitName { get; }
        public decimal Multiplication { get; }
        public string[] Aliases { get; }
    }

    public class UnitEqualityComparer<TUnit> : IEqualityComparer<TUnit>
        where TUnit : IUnit
    {
        public bool Equals(TUnit x, TUnit y)
        {
            return string.Equals(x?.UnitName, y?.UnitName, StringComparison.Ordinal);
        }

        public int GetHashCode(TUnit obj)
            => string.IsNullOrEmpty(obj?.UnitName)
                ? 0
                : obj.UnitName.GetHashCode();
    }
}