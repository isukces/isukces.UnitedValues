// ReSharper disable All
// generator: DerivedUnitGenerator
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class LengthUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        /// <summary>
        /// All known length units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<LengthUnit>> All
        {
            get
            {
                return new []
                {
                    Meter,
                    Km,
                    Dm,
                    Cm,
                    Mm,
                    Inch,
                    Feet,
                    Yard,
                    Furlong,
                    Fathom,
                    Mile,
                    NauticalMile
                };
            }
        }

        public static readonly UnitDefinition<LengthUnit> Meter = new UnitDefinition<LengthUnit>("m", 1m);

        public static readonly UnitDefinition<LengthUnit> Km = new UnitDefinition<LengthUnit>("km", 1000m);

        public static readonly UnitDefinition<LengthUnit> Dm = new UnitDefinition<LengthUnit>("dm", 0.1m);

        public static readonly UnitDefinition<LengthUnit> Cm = new UnitDefinition<LengthUnit>("cm", 0.01m);

        public static readonly UnitDefinition<LengthUnit> Mm = new UnitDefinition<LengthUnit>("mm", 0.001m);

        public static readonly UnitDefinition<LengthUnit> Inch = new UnitDefinition<LengthUnit>("inch", 0.0254m);

        public static readonly UnitDefinition<LengthUnit> Feet = new UnitDefinition<LengthUnit>("ft", 0.3048m);

        public static readonly UnitDefinition<LengthUnit> Yard = new UnitDefinition<LengthUnit>("yd", 0.9144m);

        public static readonly UnitDefinition<LengthUnit> Furlong = new UnitDefinition<LengthUnit>("fg", 201.1680m);

        public static readonly UnitDefinition<LengthUnit> Fathom = new UnitDefinition<LengthUnit>("fh", 1.8288m);

        public static readonly UnitDefinition<LengthUnit> Mile = new UnitDefinition<LengthUnit>("mil", 1609.344m);

        public static readonly UnitDefinition<LengthUnit> NauticalMile = new UnitDefinition<LengthUnit>("nm", 1852m);

    }
}
