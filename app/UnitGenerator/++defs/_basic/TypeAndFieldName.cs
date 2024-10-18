using System.ComponentModel;
using iSukces.Code;
using iSukces.UnitedValues;

namespace UnitGenerator;

[ImmutableObject(true)]
public class TypeAndFieldName
{
    public TypeAndFieldName(string type, string field)
    : this(new CsType(type), field)
    {
        
    }
    public TypeAndFieldName(CsType type, string field)
    {
        Type  = type.Declaration?.TrimToEmpty();
        Field = field?.TrimToEmpty();
    }

    public override string ToString()
    {
        return $"{Type}.{Field}";
    }

    public string Type { get; }

    public string Field { get; }

}