using System.Collections.Generic;

namespace UnitGenerator
{
    public class UnitInfo : IUnitConfig
    {
        public UnitInfo(string valueTypeName, string mainUnit, bool isComparable)
        {
            Gr           = new TypesGoup(valueTypeName);
            IsComparable = isComparable;
            BaseUnit     = Gr.Container + "." + mainUnit.Trim();
        }

        public TypesGoup Gr            { get; set; }
        public string    ValueTypeName => Gr.Value;
        public string    UnitTypeName  => Gr.Unit;
        public bool      IsComparable  { get; set; }
        public string    BaseUnit      { get; set; }

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