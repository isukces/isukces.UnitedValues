using System.Collections.Generic;
using System.Linq;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class CommonFractionalUnits
    {
        private static CommonFractionalUnitsCollection _collection;
        public static CommonFractionalUnitsCollection GetAll()
        {
            if (_collection is null)
            {
                var defs = new[]
                {
                    Make<Acceleration>(nameof(LengthUnits.Meter),
                        nameof(SquareTimeUnits.SquareSecond))
                };
                _collection = new CommonFractionalUnitsCollection(defs);
            }

            return  _collection;
        }
            
        public CommonFractionalUnits(TypesGoup type, string counterUnit, string denominatorUnit, string targetPropertyName)
        {
            Type               = type;
            CounterUnit        = counterUnit;
            DenominatorUnit    = denominatorUnit;
            TargetPropertyName = targetPropertyName;
        }

        public static CommonFractionalUnits Make<T>(string counterUnit, string denominatorUnit, string targetPropertyName = null)
        {
            if (targetPropertyName is null)
                targetPropertyName = $"{counterUnit}sPer{denominatorUnit}s";
            return new CommonFractionalUnits(new TypesGoup(typeof(T).Name), counterUnit, denominatorUnit, targetPropertyName);
        }

        public override string ToString()
        {
            return
                $"Type={Type}, CounterUnit={CounterUnit}, DenominatorUnit={DenominatorUnit}, TargetPropertyName={TargetPropertyName}";
        }

        public TypesGoup Type { get; }

        public string CounterUnit { get; }

        public string DenominatorUnit { get; }

        public string TargetPropertyName { get; }
    }

    public static class CommonFractionalUnitsHelper
    {
        private static string GetUnitname(string typeName, string fieldName)
        {
            try
            {
                var type  = typeof(LengthUnit).Assembly.GetTypes().Single(q => q.Name == typeName);
                var field = type.GetField(fieldName);
                var value = field.GetValue(null);
                return ((IUnitNameContainer)value).UnitName;
            }
            catch
            {
                return "";
            }
        }

        public static string GetUnitName(this CommonFractionalUnits unitParts)
        {
            FractionUnitInfo fractionUnitInfo = null;
            return GetUnitName(unitParts, ref fractionUnitInfo);
        }
        public static string GetUnitName(this CommonFractionalUnits unitParts, ref FractionUnitInfo fractionUnitInfo)
        {
            if (fractionUnitInfo is null)
                fractionUnitInfo = FractionUnitDefs.AllFractionUnits
                    .ByValueTypeName(unitParts.Type.Value);
            var u        = GetUnitname(fractionUnitInfo.CounterUnit.Container, unitParts.CounterUnit);
            var d        = GetUnitname(fractionUnitInfo.DenominatorUnit.Container, unitParts.DenominatorUnit);
            var unitName = u + "/" + d;
            return unitName;
        }
    }
}