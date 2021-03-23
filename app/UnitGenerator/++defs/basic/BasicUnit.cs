using System.Collections.Generic;

namespace UnitGenerator
{
    public class PrimitiveUnit : IUnitInfo
    {
        public PrimitiveUnit(string valueTypeName, string mainUnit, bool isComparable)
        {
            UnitTypes    = new TypesGroup(valueTypeName);
            IsComparable = isComparable;
            BaseUnit     = UnitTypes.Container + "." + mainUnit.Trim();
        }


        /// <summary>
        ///     Types like {Force, ForceUnit, ForceUnits}
        /// </summary>
        public TypesGroup UnitTypes { get; }

        public string ValueTypeName => UnitTypes.Value;

        public string UnitTypeName => UnitTypes.Unit;
        public bool   IsComparable { get; }

        /// <summary>
        ///     Base unit name (also property name in *Units class i.e. Newton
        /// </summary>
        public string BaseUnit { get; }

        public IEnumerable<string> Interfaces
        {
            get
            {
                yield return $"IUnitedValue<{UnitTypeName}>";
                yield return $"IEquatable<{ValueTypeName}>";
                if (IsComparable)
                    yield return $"IComparable<{ValueTypeName}>";
                yield return "IFormattable";
            }
        }
    }
}