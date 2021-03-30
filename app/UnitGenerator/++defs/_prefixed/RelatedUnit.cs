using System;
using System.Collections.Generic;
using iSukces.Code;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    /// <summary>
    ///     Group of derived units connected to the same basic unit
    /// </summary>
    public sealed class RelatedUnit
    {
        public RelatedUnit(XValueTypeName name)
        {
            Name = name;
        }
        public RelatedUnit(string name)
        {
            Name = new XValueTypeName(name);
        }


        private static string Mul(int power, string x)
        {
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

        public RelatedUnit WithLengths(int power)
        {
            var g = new[]
            {
                new PrefixedUnitInfo("Meter", "m", 1m),
                new PrefixedUnitInfo("Km", "km", 1000m, "Kilometers"),
                new PrefixedUnitInfo("Dm", "dm", 0.1m, "Decimeters"),
                new PrefixedUnitInfo("Cm", "cm", 0.01m, "Centimeters"),
                new PrefixedUnitInfo("Mm", "mm", 0.001m, "Milimeters"),
                new PrefixedUnitInfo("Inch", "inch", 0.0254m, "Inches"),
                new PrefixedUnitInfo("Feet", "ft", 0.3048m, "Foot"),
                new PrefixedUnitInfo("Yard", "yd", 0.9144m, "Yards"),
                new PrefixedUnitInfo("Furlong", "fg", 201.1680m, "Furlongs"),
                new PrefixedUnitInfo("Fathom", "fh", 1.8288m),
                new PrefixedUnitInfo("Mile", "mil", 1609.344m, "Miles"),
                new PrefixedUnitInfo("NauticalMile", "nm", 1852m, "NauticalMiles")
            };

            return WithPowerDerivedUnits(power, g, XValueTypeName.FromSplit(',', "Length,Area,Volume"));
        }

        public RelatedUnit WithPrefixedUnit(string unitShortName, string fieldName,
            decimal multiplicator, string fromMethodNameSufix = null, TypeCodeAliases aliases = null)
        {
            if (aliases != null)
            {
                if (string.IsNullOrWhiteSpace(fieldName))
                    if (!string.IsNullOrWhiteSpace(aliases.NameSingular))
                        fieldName = aliases.NameSingular.FirstUpper();
                if (string.IsNullOrWhiteSpace(fromMethodNameSufix))
                    if (!string.IsNullOrWhiteSpace(aliases.NamePlural))
                        fromMethodNameSufix = aliases.NamePlural.FirstUpper();
            }

            var info = new AliasedPrefixedUnitInfo(fieldName, unitShortName, multiplicator.CsEncode(),
                fromMethodNameSufix, aliases);
            Units.Add(info);
            return this;
        }

        public RelatedUnit WithPrefixedUnits(string unitShortName, string fieldName, CommonPrefixes kilo)
        {
            void Add(string unitPrefix, string fieldPrefix, CommonPrefixes flag, decimal factor)
            {
                if ((kilo & flag) != 0)
                    WithPrefixedUnit(unitPrefix + unitShortName, fieldPrefix + fieldName, factor);
            }

            Add("k", "Kilo", CommonPrefixes.Kilo, 1_000);
            Add("M", "Mega", CommonPrefixes.Mega, 1_000_000);
            Add("G", "Giga", CommonPrefixes.Giga, 1_000_000_000);
            Add("m", "Mili", CommonPrefixes.Mili, 0.001m);
            Add("µ", "Micro", CommonPrefixes.Micro, 0.000_001m);
            return this;
        }

        public RelatedUnit WithTime(int power)
        {
            var g = new[]
            {
                new PrefixedUnitInfo("Second", "s", 1m),
                new PrefixedUnitInfo("Minute", "min", 60, "Minutes"),
                new PrefixedUnitInfo("Hour", "h", 3600, "Hours"),
            };

            var values = XValueTypeName.FromSplit(',', "Time,SquareTime");
            return WithPowerDerivedUnits(power, g, values);
        }

        private RelatedUnit WithPowerDerivedUnits(int power, PrefixedUnitInfo[] items, XValueTypeName[] values)
        {
            Power = power;
            if (power != 1)
                PowerOne = new TypesGroup(values[0]);
            var unitSuffix     = Suffix(power);
            var propertyPrefix = Prefix(power);

            foreach (var i in items)
            {
                var fromMethodNameSufix = i.FromMethodNameSufix.AddPrefix(propertyPrefix);
                var q = new AliasedPrefixedUnitInfo(propertyPrefix + i.FieldName,
                    i.UnitShortCode + unitSuffix,
                    Mul(power, i.ScaleFactor), fromMethodNameSufix, null);
                Units.Add(q);
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

        public XValueTypeName Name { get; }

        public List<AliasedPrefixedUnitInfo> Units           { get; } = new List<AliasedPrefixedUnitInfo>();
        public List<PrefixRelation>          PrefixRelations { get; } = new List<PrefixRelation>();
    }
}