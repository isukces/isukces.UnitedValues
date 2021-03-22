using System;
using System.Collections.Generic;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class DerivedUnitInfo
    {
        public DerivedUnitInfo(string name)
        {
            Name = name;
        }


        private static string Mul(int power, decimal m)
        {
            var x = Ext.CsEncode(m);
            if (x == "1m")
                return x;
            var y                 = x;
            while (power-- > 1) y += " * " + x;

            return y;
        }

        private static string Prefix(int power)
        {
            switch (power)
            {
                case 1:
                    return null;
                case 2:
                    return "Square";
                case 3:
                    return "Cubic";
                default:
                    throw new NotSupportedException();
            }
        }

        private static string Suffix(int power)
        {
            switch (power)
            {
                case 1:
                    return null;
                case 2:
                    return AreaUnits.SquareSign;
                case 3:
                    return "³";
                default:
                    throw new NotSupportedException();
            }
        }

        public DerivedUnitInfo WithLengths(int power)
        {
            var unitSuffix     = Suffix(power);
            var propertyPrefix = Prefix(power);

            void Add(string prop, string unit, decimal m, string fromMethodNameSufix = null)
            {
                fromMethodNameSufix = fromMethodNameSufix.AddPrefix(propertyPrefix);
                WithUnit(unit + unitSuffix, propertyPrefix + prop, Mul(power, m),
                    fromMethodNameSufix: fromMethodNameSufix);
            }

            Add("Meter", "m", 1m);
            Add("Km", "km", 1000m, "Kilometers");
            Add("Dm", "dm", 0.1m, "Decimeters");
            Add("Cm", "cm", 0.01m, "Centimeters");
            Add("Mm", "mm", 0.001m, "Milimeters");
            Add("Inch", "inch", 0.0254m, "Inches");
            Add("Feet", "ft", 0.3048m, "Foot");
            Add("Yard", "yd", 0.9144m, "Yards");
            Add("Furlong", "fg", 201.1680m, "Furlongs");
            Add("Fathom", "fh", 1.8288m);
            Add("Mile", "mil", 1609.344m, "Miles");
            Add("NauticalMile", "nm", 1852m, "NauticalMiles");

            if (power <= 1) return this;
            for (var i = 1; i < power; i++)
            {
                var otherUnitContainer = GetUnit(i) + "Unit";
                var myUnitContainer    = GetUnit(power) + "Unit";
                var relation = new PrefixRelation(
                    Prefix(i), Prefix(power),
                    myUnitContainer, otherUnitContainer);
                PrefixRelations.Add(relation);
            }

            return this;

            string GetUnit(int xPower)
            {
                switch (xPower)
                {
                    case 1:
                        return "Length";
                    case 2:
                        return "Area";
                    case 3:
                        return "Volume";
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public DerivedUnitInfo WithUnit(string unitShortName,
            string propertyName, decimal multiplicator, string nameSingular = null,
            string namePlural = null,
            string fromMethodNameSufix = null)
        {
            Units.Add(new DerivedUnitDefinition(unitShortName, Ext.CsEncode(multiplicator), nameSingular, namePlural,
                propertyName, fromMethodNameSufix));
            return this;
        }


        private void WithUnit(string unitShortName,
            string propertyName, string multiplicator, string nameSingular = null,
            string namePlural = null,
            string fromMethodNameSufix = null)
        {
            Units.Add(new DerivedUnitDefinition(unitShortName, multiplicator, nameSingular, namePlural, propertyName,
                fromMethodNameSufix));
        }

        public string Name { get; }

        public List<DerivedUnitDefinition> Units           { get; } = new List<DerivedUnitDefinition>();
        public List<PrefixRelation>        PrefixRelations { get; } = new List<PrefixRelation>();
    }
}