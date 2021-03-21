using System.Collections.Generic;

namespace UnitGenerator
{
    public class UnitInfo : IUnitConfig
    {
        public static UnitInfo Parse(string x)
        {
            if (string.IsNullOrEmpty(x))
                return null;
            var a = x.Split(',');
            if (a.Length < 3) return null;
            var valueGroup = new ValueGroup(a[0].Trim());
            return new UnitInfo
            {
                Gr           = valueGroup,
                IsComparable = a[1].Trim() == "+",
                BaseUnit     = valueGroup.UnitContainerTypeName + "." + a[2].Trim()
            };
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