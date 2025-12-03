using System.Linq;
using iSukces.UnitedValues;

namespace UnitGenerator;

public static class CommonFractionalUnitsExtensions
{
    extension(CommonFractionalUnit unitParts)
    {
        public string GetUnitName()
        {
            FractionUnit? fractionUnit = null;
            return GetUnitName(unitParts, ref fractionUnit);
        }

        public string GetUnitName(ref FractionUnit fractionUnit)
        {
            if (fractionUnit is null)
                fractionUnit = FractionUnitDefs.All
                    .ByValueTypeName(unitParts.Type.Value);
            var u        = GetUnitname(fractionUnit.CounterUnit.Container, unitParts.CounterUnit);
            var d        = GetUnitname(fractionUnit.DenominatorUnit.Container, unitParts.DenominatorUnit);
            var unitName = u + "/" + d;
            return unitName;
        }
    }

    private static string GetUnitname(XUnitContainerTypeName typeName, string fieldName)
    {
        try
        {
            var type  = typeof(LengthUnit).Assembly.GetTypes().Single(q => q.Name == typeName.TypeName);
            var field = type.GetField(fieldName);
            var value = field.GetValue(null);
            return ((IUnitNameContainer?)value).UnitName;
        }
        catch
        {
            return "";
        }
    }
}
