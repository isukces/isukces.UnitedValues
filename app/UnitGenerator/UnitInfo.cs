using System.Collections.Generic;

namespace UnitGenerator
{
    public class UnitInfo : IUnitConfig
    {
        public UnitInfo(string valueTypeName, string mainUnit, bool isComparable)
        {
            Gr           = new ValueGroup(valueTypeName);
            IsComparable = isComparable;
            BaseUnit     = Gr.UnitContainerTypeName + "." + mainUnit.Trim();
        }

        public ValueGroup Gr            { get; set; }
        public string     ValueTypeName => Gr.ValueTypeName;
        public string     UnitTypeName  => Gr.UnitTypeName;
        public bool       IsComparable  { get; set; }
        public string     BaseUnit      { get; set; }

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