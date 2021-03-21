using System.Collections.Generic;

namespace UnitGenerator
{
    public class UnitInfo
    {
        public static UnitInfo Parse(string x)
        {
            if (string.IsNullOrEmpty(x))
                return null;
            var a = x.Split(',');
            if (a.Length < 4) return null;
            return new UnitInfo
            {
                Name         = a[0].Trim(),
                Unit         = a[1].Trim(),
                IsComparable = a[2].Trim() == "+",
                BaseUnit     = a[3].Trim()
            };
        }

        public string Name         { get; set; }
        public string Unit         { get; set; }
        public bool   IsComparable { get; set; }
        public string BaseUnit     { get; set; }

        public IEnumerable<string> Interfaces
        {
            get
            {
                yield return $"IUnitedValue<{Unit}>";
                yield return $"IEquatable<{Name}>";
                if (IsComparable)
                    yield return $"IComparable<{Name}>";
                yield return "IFormattable";
            }
        }
    }
}