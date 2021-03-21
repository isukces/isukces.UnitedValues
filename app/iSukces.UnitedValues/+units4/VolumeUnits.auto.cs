// ReSharper disable All
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public static partial class VolumeUnits
    {
        internal static void Register(UnitRelationsDictionary dict)
        {
            dict.AddRelated<VolumeUnit, LengthUnit>(QubicMeter, LengthUnits.Meter);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Meter, QubicMeter);
            dict.AddRelated<VolumeUnit, LengthUnit>(QubicKm, LengthUnits.Km);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Km, QubicKm);
            dict.AddRelated<VolumeUnit, LengthUnit>(QubicDm, LengthUnits.Dm);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Dm, QubicDm);
            dict.AddRelated<VolumeUnit, LengthUnit>(QubicCm, LengthUnits.Cm);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Cm, QubicCm);
            dict.AddRelated<VolumeUnit, LengthUnit>(QubicMm, LengthUnits.Mm);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Mm, QubicMm);
            dict.AddRelated<VolumeUnit, LengthUnit>(QubicInch, LengthUnits.Inch);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Inch, QubicInch);
            dict.AddRelated<VolumeUnit, LengthUnit>(QubicFoot, LengthUnits.Foot);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Foot, QubicFoot);
            dict.AddRelated<VolumeUnit, LengthUnit>(QubicYard, LengthUnits.Yard);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Yard, QubicYard);
            dict.AddRelated<VolumeUnit, LengthUnit>(QubicFurlong, LengthUnits.Furlong);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Furlong, QubicFurlong);
            dict.AddRelated<VolumeUnit, LengthUnit>(QubicFathom, LengthUnits.Fathom);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Fathom, QubicFathom);
            dict.AddRelated<VolumeUnit, LengthUnit>(QubicMile, LengthUnits.Mile);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Mile, QubicMile);
            dict.AddRelated<VolumeUnit, LengthUnit>(QubicNauticalMile, LengthUnits.NauticalMile);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.NauticalMile, QubicNauticalMile);
            dict.AddRelated<VolumeUnit, AreaUnit>(QubicMeter, AreaUnits.SquareMeter);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareMeter, QubicMeter);
            dict.AddRelated<VolumeUnit, AreaUnit>(QubicKm, AreaUnits.SquareKm);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareKm, QubicKm);
            dict.AddRelated<VolumeUnit, AreaUnit>(QubicDm, AreaUnits.SquareDm);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareDm, QubicDm);
            dict.AddRelated<VolumeUnit, AreaUnit>(QubicCm, AreaUnits.SquareCm);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareCm, QubicCm);
            dict.AddRelated<VolumeUnit, AreaUnit>(QubicMm, AreaUnits.SquareMm);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareMm, QubicMm);
            dict.AddRelated<VolumeUnit, AreaUnit>(QubicInch, AreaUnits.SquareInch);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareInch, QubicInch);
            dict.AddRelated<VolumeUnit, AreaUnit>(QubicFoot, AreaUnits.SquareFoot);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareFoot, QubicFoot);
            dict.AddRelated<VolumeUnit, AreaUnit>(QubicYard, AreaUnits.SquareYard);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareYard, QubicYard);
            dict.AddRelated<VolumeUnit, AreaUnit>(QubicFurlong, AreaUnits.SquareFurlong);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareFurlong, QubicFurlong);
            dict.AddRelated<VolumeUnit, AreaUnit>(QubicFathom, AreaUnits.SquareFathom);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareFathom, QubicFathom);
            dict.AddRelated<VolumeUnit, AreaUnit>(QubicMile, AreaUnits.SquareMile);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareMile, QubicMile);
            dict.AddRelated<VolumeUnit, AreaUnit>(QubicNauticalMile, AreaUnits.SquareNauticalMile);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareNauticalMile, QubicNauticalMile);
        }

        /// <summary>
        /// All known volume units
        /// </summary>
        public static IReadOnlyList<UnitDefinition<VolumeUnit>> All
        {
            get
            {
                return new []
                {
                    QubicMeter,
                    QubicKm,
                    QubicDm,
                    QubicCm,
                    QubicMm,
                    QubicInch,
                    QubicFoot,
                    QubicYard,
                    QubicFurlong,
                    QubicFathom,
                    QubicMile,
                    QubicNauticalMile
                };
            }
        }

        public static readonly UnitDefinition<VolumeUnit> QubicMeter = new UnitDefinition<VolumeUnit>("m³", 1m);

        public static readonly UnitDefinition<VolumeUnit> QubicKm = new UnitDefinition<VolumeUnit>("km³", 1000m * 1000m * 1000m);

        public static readonly UnitDefinition<VolumeUnit> QubicDm = new UnitDefinition<VolumeUnit>("dm³", 0.1m * 0.1m * 0.1m);

        public static readonly UnitDefinition<VolumeUnit> QubicCm = new UnitDefinition<VolumeUnit>("cm³", 0.01m * 0.01m * 0.01m);

        public static readonly UnitDefinition<VolumeUnit> QubicMm = new UnitDefinition<VolumeUnit>("mm³", 0.001m * 0.001m * 0.001m);

        public static readonly UnitDefinition<VolumeUnit> QubicInch = new UnitDefinition<VolumeUnit>("inch³", 0.0254m * 0.0254m * 0.0254m);

        public static readonly UnitDefinition<VolumeUnit> QubicFoot = new UnitDefinition<VolumeUnit>("ft³", 0.3048m * 0.3048m * 0.3048m);

        public static readonly UnitDefinition<VolumeUnit> QubicYard = new UnitDefinition<VolumeUnit>("yd³", 0.9144m * 0.9144m * 0.9144m);

        public static readonly UnitDefinition<VolumeUnit> QubicFurlong = new UnitDefinition<VolumeUnit>("fg³", 201.1680m * 201.1680m * 201.1680m);

        public static readonly UnitDefinition<VolumeUnit> QubicFathom = new UnitDefinition<VolumeUnit>("fh³", 1.8288m * 1.8288m * 1.8288m);

        public static readonly UnitDefinition<VolumeUnit> QubicMile = new UnitDefinition<VolumeUnit>("mil³", 1609.344m * 1609.344m * 1609.344m);

        public static readonly UnitDefinition<VolumeUnit> QubicNauticalMile = new UnitDefinition<VolumeUnit>("nm³", 1852m * 1852m * 1852m);

    }
}
