using iSukces.UnitedValues;

namespace UnitGenerator
{
    internal class CommonFractionalUnitDefs
    {
        private static CommonFractionalUnit[] GetItems()
        {
            var defs = new[]
            {
                Make<Acceleration>(nameof(LengthUnits.Meter),
                    nameof(SquareTimeUnits.SquareSecond))
            };
            return defs;
        }

        private static CommonFractionalUnit Make<T>(string counterUnit, string denominatorUnit,
            string targetPropertyName = null)
        {
            if (targetPropertyName is null)
                targetPropertyName = $"{counterUnit}sPer{denominatorUnit}s";
            var typeName = new XValueTypeName(typeof(T).Name);
            
            return new CommonFractionalUnit(new TypesGroup(typeName), counterUnit, denominatorUnit,
                targetPropertyName);
        }

        public static CommonFractionalUnitsCollection All
        {
            get
            {
                if (!(_all is null))
                    return _all;
                var items = GetItems();
                _all = new CommonFractionalUnitsCollection(items);
                return _all;
            }
        }


        private static CommonFractionalUnitsCollection _all;
    }
}