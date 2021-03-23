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
            var g = new[]
            {
                new ShortInfo("Meter", "m", 1m),
                new ShortInfo("Km", "km", 1000m, "Kilometers"),
                new ShortInfo("Dm", "dm", 0.1m, "Decimeters"),
                new ShortInfo("Cm", "cm", 0.01m, "Centimeters"),
                new ShortInfo("Mm", "mm", 0.001m, "Milimeters"),
                new ShortInfo("Inch", "inch", 0.0254m, "Inches"),
                new ShortInfo("Feet", "ft", 0.3048m, "Foot"),
                new ShortInfo("Yard", "yd", 0.9144m, "Yards"),
                new ShortInfo("Furlong", "fg", 201.1680m, "Furlongs"),
                new ShortInfo("Fathom", "fh", 1.8288m),
                new ShortInfo("Mile", "mil", 1609.344m, "Miles"),
                new ShortInfo("NauticalMile", "nm", 1852m, "NauticalMiles")
            };

            return WithPoweredUnits(power, g, "Length,Area,Volume".Split(','));
        }

        public DerivedUnitInfo WithPoweredUnits(int power, ShortInfo[] items, string[] values)
        {
            var unitSuffix     = Suffix(power);
            var propertyPrefix = Prefix(power);

            foreach (var i in items)
            {
                var fromMethodNameSufix = i.FromMethodNameSufix.AddPrefix(propertyPrefix);
                WithUnit(i.Unit + unitSuffix, propertyPrefix + i.Prop, Mul(power, i.M),
                    fromMethodNameSufix: fromMethodNameSufix);
            }

            if (power <= 1) return this;
            for (var i = 1; i < power; i++)
            {
                var otherUnitContainer = values[i - 1] + "Unit";
                var myUnitContainer    = values[power - 1] + "Unit";
                var relation = new PrefixRelation(
                    Prefix(i), Prefix(power),
                    myUnitContainer, otherUnitContainer);
                PrefixRelations.Add(relation);
            }

            return this;
        }

        public DerivedUnitInfo WithTime(int power)
        {
            var g = new[]
            {
                new ShortInfo("Second", "s", 1m),
                new ShortInfo("Minute", "min", 60, "Minutes"),
                new ShortInfo("Hour", "h", 3600, "Hours"),
            };

            return WithPoweredUnits(power, g, "Time,SquareTime".Split(','));
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

        public class ShortInfo
        {
            public ShortInfo(string prop, string unit, decimal m, string fromMethodNameSufix = null)
            {
                Prop                = prop;
                Unit                = unit;
                M                   = m;
                FromMethodNameSufix = fromMethodNameSufix;
            }

            public override string ToString()
            {
                return $"Prop={Prop}, Unit={Unit}, M={M}, FromMethodNameSufix={FromMethodNameSufix}";
            }

            public string Prop { get; }

            public string Unit { get; }

            public decimal M { get; }

            public string FromMethodNameSufix { get; }
        }
    }
}