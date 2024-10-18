using System;
using System.Reflection;
using iSukces.Code;
using iSukces.UnitedValues;

namespace UnitGenerator;

internal class DecomposeExpressionFinder
{
    public DecomposeExpressionFinder(Assembly assembly)
    {
        _clrTypesResolver = new ClrTypesResolver(assembly);
    }

    public Element[] GetCodeItems(NameAndPower[] items, string targetName)
    {
        if (!_clrTypesResolver.TryGetValue(targetName, out var reflected))
            return null;
        var elements = new Element[items.Length];
        for (var index = 0; index < items.Length; index++)
        {
            var item = items[index];
            var el   = CreateElement(reflected, item);
            if (el is null)
                return null;
            elements[index] = el;
        }

        return elements;
    }

    private Element CreateElement(Type reflected, NameAndPower item)
    {
        var p  = reflected.GetProperty(item.Propertyname);
        var pt = p?.PropertyType;
        if (pt is null)
            return null;
        if (!_clrTypesResolver.TryGetValue(pt.Name.Substring(0, pt.Name.Length - 4), out var reflected3))
            return null;

        var fieldInfo = reflected3.GetField("BaseUnit");
        if (fieldInfo is null)
            return null;
        var el = fieldInfo.GetValue(null);
        // var el = Activator.CreateInstance(pt, new[] {"fake"});
        var power = item.Power;

        string PowerString(string x)
        {
            if (string.IsNullOrEmpty(x))
                return power.CsEncode();
            if (power == 1)
                return x;
            if (power == -1)
                return $"-{x}";
            return $"{power.CsEncode()} * x";
        }

        if (el is IDerivedDecomposableUnit)
        {
            var varName = item.Propertyname.FirstLower();
            return new Element
            {
                Init  = $"var {varName} = {item.Propertyname}.GetBasicUnit();",
                Unit  = $"{varName}.{nameof(DecomposableUnitItem.Unit)}",
                Power = PowerString($"{varName}.{nameof(DecomposableUnitItem.Power)}")
            };
        }

        if (el is IDecomposableUnit)
            // probably return null
            throw new NotImplementedException();

        return new Element
        {
            Unit  = item.Propertyname,
            Power = PowerString("")
        };
    }

    private readonly ClrTypesResolver _clrTypesResolver;


    public class Element
    {
        public string Init { get; set; }

        public string Expression => $"new {nameof(DecomposableUnitItem)}({Unit}, {Power})";

        public string Unit  { get; set; }
        public string Power { get; set; }
    }
}