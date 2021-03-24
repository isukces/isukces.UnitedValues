// ReSharper disable All
// generator: DerivedUnitGenerator
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

        public static readonly UnitDefinition<AreaUnit> SquareMeter = new UnitDefinition<AreaUnit>("m²", 1m);

        public static readonly UnitDefinition<AreaUnit> SquareKm = new UnitDefinition<AreaUnit>("km²", 1000m * 1000m);

        public static readonly UnitDefinition<AreaUnit> SquareDm = new UnitDefinition<AreaUnit>("dm²", 0.1m * 0.1m);

        public static readonly UnitDefinition<AreaUnit> SquareCm = new UnitDefinition<AreaUnit>("cm²", 0.01m * 0.01m);

        public static readonly UnitDefinition<AreaUnit> SquareMm = new UnitDefinition<AreaUnit>("mm²", 0.001m * 0.001m);

        public static readonly UnitDefinition<AreaUnit> SquareInch = new UnitDefinition<AreaUnit>("inch²", 0.0254m * 0.0254m);

        public static readonly UnitDefinition<AreaUnit> SquareFeet = new UnitDefinition<AreaUnit>("ft²", 0.3048m * 0.3048m);

        public static readonly UnitDefinition<AreaUnit> SquareYard = new UnitDefinition<AreaUnit>("yd²", 0.9144m * 0.9144m);

        public static readonly UnitDefinition<AreaUnit> SquareFurlong = new UnitDefinition<AreaUnit>("fg²", 201.1680m * 201.1680m);

        public static readonly UnitDefinition<AreaUnit> SquareFathom = new UnitDefinition<AreaUnit>("fh²", 1.8288m * 1.8288m);

        public static readonly UnitDefinition<AreaUnit> SquareMile = new UnitDefinition<AreaUnit>("mil²", 1609.344m * 1609.344m);

        public static readonly UnitDefinition<AreaUnit> SquareNauticalMile = new UnitDefinition<AreaUnit>("nm²", 1852m * 1852m);

    }
}
