using System.ComponentModel;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    [ImmutableObject(true)]
    public class TypeAndFieldName
    {
        public TypeAndFieldName(string type, string field)
        {
            Type  = type?.TrimToEmpty();
            Field = field?.TrimToEmpty();
        }

        public override string ToString()
        {
            return $"{Type}.{Field}";
        }

        public string Type { get; }

        public string Field { get; }

    }
}