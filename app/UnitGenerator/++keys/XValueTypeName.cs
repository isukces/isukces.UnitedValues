using System;
using System.Linq;
using iSukces.Code;
using UnitGenerator.Local;

namespace UnitGenerator;

public partial class XValueTypeName:ITypeNameProvider
{
    public static XValueTypeName[] FromSplit(char separator, string text)
    {
        var items = text.Split(separator);
        return items.Select(a => new XValueTypeName(a)).ToArray();
    }

    public string FirstLower()
    {
        return ValueTypeName.FirstLower();
    }

    public string GetExtensions()
    {
        return ValueTypeName + "Extensions";
    }

    public string ToLower()
    {
        return ValueTypeName.ToLower();
    }

    public UnitNameKind Kind
    {
        get
        {
            if (ValueTypeName.StartsWith("Delta", StringComparison.Ordinal))
                return UnitNameKind.Delta;
            return UnitNameKind.Normal;
        }
    }

    public string CoreName
    {
        get
        {
            if (Kind == UnitNameKind.Delta)
                return ValueTypeName.Substring(5);
            return ValueTypeName;
        }
    }

    public XUnitTypeName ToUnitTypeName()
    {
        return new XUnitTypeName(CoreName + "Unit");
    }

    public string GetTypename()
    {
        return ValueTypeName;
    }
}

public enum UnitNameKind
{
    Normal,
    Delta
}