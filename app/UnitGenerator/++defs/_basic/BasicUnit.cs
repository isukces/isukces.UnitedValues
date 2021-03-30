using System.Collections.Generic;

namespace UnitGenerator
{
    public class BasicUnit : IUnitInfo
    {
        public BasicUnit(string valueTypeName, string mainUnit, bool isComparable)
        {
            UnitTypes    = new TypesGroup(new XValueTypeName(valueTypeName));
            IsComparable = isComparable;
            BaseUnit     = UnitTypes.Container + "." + mainUnit.Trim();
        }


        /// <summary>
        ///     Types like {Force, ForceUnit, ForceUnits}
        /// </summary>
        public TypesGroup UnitTypes { get; }

        public bool IsComparable { get; }

        /// <summary>
        ///     Base unit name (also property name in *Units class i.e. Newton
        /// </summary>
        public string BaseUnit { get; }

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
}