// ReSharper disable All
// generator: DerivedUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class AreaUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        public static AreaUnit TryRecoverUnitFromName([NotNull] string unitName)
        {
            // generator : DerivedUnitGenerator.Add_TryRecoverUnitFromName
            if (unitName is null)
                throw new NullReferenceException(nameof(unitName));
            unitName = unitName.Trim();
            if (unitName.Length == 0)
                throw new ArgumentException(nameof(unitName));
            foreach (var i in All)
            {
                if (unitName == i.UnitName)
                    return i.Unit;
            }
            return new AreaUnit(unitName);
        }

        internal static void Register(UnitRelationsDictionary dict)
        {
            dict.AddRelated<AreaUnit, LengthUnit>(SquareMeter, LengthUnits.Meter);
            dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Meter, SquareMeter);
            dict.AddRelated<AreaUnit, LengthUnit>(SquareKm, LengthUnits.Km);
            dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Km, SquareKm);
            dict.AddRelated<AreaUnit, LengthUnit>(SquareDm, LengthUnits.Dm);
            dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Dm, SquareDm);
            dict.AddRelated<AreaUnit, LengthUnit>(SquareCm, LengthUnits.Cm);
            dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Cm, SquareCm);
            dict.AddRelated<AreaUnit, LengthUnit>(SquareMm, LengthUnits.Mm);
            dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Mm, SquareMm);
            dict.AddRelated<AreaUnit, LengthUnit>(SquareInch, LengthUnits.Inch);
            dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Inch, SquareInch);
            dict.AddRelated<AreaUnit, LengthUnit>(SquareFeet, LengthUnits.Feet);
            dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Feet, SquareFeet);
            dict.AddRelated<AreaUnit, LengthUnit>(SquareYard, LengthUnits.Yard);
            dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Yard, SquareYard);
            dict.AddRelated<AreaUnit, LengthUnit>(SquareFurlong, LengthUnits.Furlong);
            dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Furlong, SquareFurlong);
            dict.AddRelated<AreaUnit, LengthUnit>(SquareFathom, LengthUnits.Fathom);
            dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Fathom, SquareFathom);
            dict.AddRelated<AreaUnit, LengthUnit>(SquareMile, LengthUnits.Mile);
            dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.Mile, SquareMile);
            dict.AddRelated<AreaUnit, LengthUnit>(SquareNauticalMile, LengthUnits.NauticalMile);
            dict.AddRelated<LengthUnit, AreaUnit>(LengthUnits.NauticalMile, SquareNauticalMile);
        }

        /// <summary>
        /// All known area units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<AreaUnit>> All
        {
            get
            {
                return new []
                {
                    SquareMeter,
                    SquareKm,
                    SquareDm,
                    SquareCm,
                    SquareMm,
                    SquareInch,
                    SquareFeet,
                    SquareYard,
                    SquareFurlong,
                    SquareFathom,
                    SquareMile,
                    SquareNauticalMile
                };
            }
        }

        internal static readonly AreaUnit SquareMeterAreaUnit = new AreaUnit(LengthUnits.Meter);

        public static readonly UnitDefinition<AreaUnit> SquareMeter = new UnitDefinition<AreaUnit>(SquareMeterAreaUnit, 1m);

        internal static readonly AreaUnit SquareKmAreaUnit = new AreaUnit(LengthUnits.Km);

        public static readonly UnitDefinition<AreaUnit> SquareKm = new UnitDefinition<AreaUnit>(SquareKmAreaUnit, 1000m * 1000m);

        internal static readonly AreaUnit SquareDmAreaUnit = new AreaUnit(LengthUnits.Dm);

        public static readonly UnitDefinition<AreaUnit> SquareDm = new UnitDefinition<AreaUnit>(SquareDmAreaUnit, 0.1m * 0.1m);

        internal static readonly AreaUnit SquareCmAreaUnit = new AreaUnit(LengthUnits.Cm);

        public static readonly UnitDefinition<AreaUnit> SquareCm = new UnitDefinition<AreaUnit>(SquareCmAreaUnit, 0.01m * 0.01m);

        internal static readonly AreaUnit SquareMmAreaUnit = new AreaUnit(LengthUnits.Mm);

        public static readonly UnitDefinition<AreaUnit> SquareMm = new UnitDefinition<AreaUnit>(SquareMmAreaUnit, 0.001m * 0.001m);

        internal static readonly AreaUnit SquareInchAreaUnit = new AreaUnit(LengthUnits.Inch);

        public static readonly UnitDefinition<AreaUnit> SquareInch = new UnitDefinition<AreaUnit>(SquareInchAreaUnit, 0.0254m * 0.0254m);

        internal static readonly AreaUnit SquareFeetAreaUnit = new AreaUnit(LengthUnits.Feet);

        public static readonly UnitDefinition<AreaUnit> SquareFeet = new UnitDefinition<AreaUnit>(SquareFeetAreaUnit, 0.3048m * 0.3048m);

        internal static readonly AreaUnit SquareYardAreaUnit = new AreaUnit(LengthUnits.Yard);

        public static readonly UnitDefinition<AreaUnit> SquareYard = new UnitDefinition<AreaUnit>(SquareYardAreaUnit, 0.9144m * 0.9144m);

        internal static readonly AreaUnit SquareFurlongAreaUnit = new AreaUnit(LengthUnits.Furlong);

        public static readonly UnitDefinition<AreaUnit> SquareFurlong = new UnitDefinition<AreaUnit>(SquareFurlongAreaUnit, 201.1680m * 201.1680m);

        internal static readonly AreaUnit SquareFathomAreaUnit = new AreaUnit(LengthUnits.Fathom);

        public static readonly UnitDefinition<AreaUnit> SquareFathom = new UnitDefinition<AreaUnit>(SquareFathomAreaUnit, 1.8288m * 1.8288m);

        internal static readonly AreaUnit SquareMileAreaUnit = new AreaUnit(LengthUnits.Mile);

        public static readonly UnitDefinition<AreaUnit> SquareMile = new UnitDefinition<AreaUnit>(SquareMileAreaUnit, 1609.344m * 1609.344m);

        internal static readonly AreaUnit SquareNauticalMileAreaUnit = new AreaUnit(LengthUnits.NauticalMile);

        public static readonly UnitDefinition<AreaUnit> SquareNauticalMile = new UnitDefinition<AreaUnit>(SquareNauticalMileAreaUnit, 1852m * 1852m);

    }
}
