using System;
using System.Collections.Generic;
using iSukces.Code;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    /// <summary>
    ///     Group of derived units connected to the same basic unit
    /// </summary>
    public class DerivedUnit
    {
        public DerivedUnit(string name)
        {
            Name = name;
        }


        private static string Mul(int power, string x)
        {
            // var x = Ext.CsEncode(m);
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

        public DerivedUnit WithLengths(int power)
        {
            var g = new[]
            {
                new DerivedUnitItem("Meter", "m", 1m),
                new DerivedUnitItem("Km", "km", 1000m, "Kilometers"),
                new DerivedUnitItem("Dm", "dm", 0.1m, "Decimeters"),
                new DerivedUnitItem("Cm", "cm", 0.01m, "Centimeters"),
                new DerivedUnitItem("Mm", "mm", 0.001m, "Milimeters"),
                new DerivedUnitItem("Inch", "inch", 0.0254m, "Inches"),
                new DerivedUnitItem("Feet", "ft", 0.3048m, "Foot"),
                new DerivedUnitItem("Yard", "yd", 0.9144m, "Yards"),
                new DerivedUnitItem("Furlong", "fg", 201.1680m, "Furlongs"),
                new DerivedUnitItem("Fathom", "fh", 1.8288m),
                new DerivedUnitItem("Mile", "mil", 1609.344m, "Miles"),
                new DerivedUnitItem("NauticalMile", "nm", 1852m, "NauticalMiles")
            };

            return WithPoweredUnits(power, g, "Length,Area,Volume".Split(','));
        }

        public DerivedUnit WithTime(int power)
        {
            var g = new[]
            {
                new DerivedUnitItem("Second", "s", 1m),
                new DerivedUnitItem("Minute", "min", 60, "Minutes"),
                new DerivedUnitItem("Hour", "h", 3600, "Hours"),
            };

            return WithPoweredUnits(power, g, "Time,SquareTime".Split(','));
        }

        public DerivedUnit WithUnit(string unitShortName,
            string fieldName, 
            decimal multiplicator,
            string fromMethodNameSufix = null,
            TypeCodeAliases aliases = null
            )
        {
            if (aliases != null)
            {
                if (string. IsNullOrWhiteSpace(fieldName))
                    if (!string.IsNullOrWhiteSpace(aliases.NameSingular))
                        fieldName = aliases.NameSingular.FirstUpper();
                if (string. IsNullOrWhiteSpace(fromMethodNameSufix))
                    if (!string.IsNullOrWhiteSpace(aliases.NamePlural))
                        fromMethodNameSufix = aliases.NamePlural.FirstUpper();
            }
            Units.Add(new DerivedUnitDefinition(fieldName, unitShortName, multiplicator.CsEncode(), fromMethodNameSufix, aliases));
            return this;
        }

        private DerivedUnit WithPoweredUnits(int power, DerivedUnitItem[] items, string[] values)
        {
            Power    = power;
            if (power != 1)
                PowerOne = new TypesGroup(values[0]);
            var unitSuffix     = Suffix(power);
            var propertyPrefix = Prefix(power);

            foreach (var i in items)
            {
                var fromMethodNameSufix = i.FromMethodNameSufix.AddPrefix(propertyPrefix);
                WithUnit(
                    i.UnitShortCode + unitSuffix, 
                    propertyPrefix + i.FieldName,
                    Mul(power, i.ScaleFactor),
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

        public TypesGroup PowerOne { get; set; }

        public int Power { get; set; } = 1;


        private void WithUnit(string unitShortName, string fieldName, string scaleFactor,
            string fromMethodNameSufix = null)
        {
            Units.Add(new DerivedUnitDefinition(fieldName, unitShortName, scaleFactor, fromMethodNameSufix, null));
        }

        public string Name { get; }

        public List<DerivedUnitDefinition> Units           { get; } = new List<DerivedUnitDefinition>();
        public List<PrefixRelation>        PrefixRelations { get; } = new List<PrefixRelation>();
    }
}