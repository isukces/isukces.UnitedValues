// ReSharper disable All
// generator: DerivedUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [UnitsContainer]
    public static partial class VolumeUnits
    {
        public static void RegisterUnitExchangeFactors(UnitExchangeFactors factors)
        {
            factors.RegisterMany(All);
        }

        public static VolumeUnit TryRecoverUnitFromName([NotNull] string unitName)
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
            return new VolumeUnit(unitName);
        }

        internal static void Register(UnitRelationsDictionary dict)
        {
            dict.AddRelated<VolumeUnit, LengthUnit>(CubicMeter, LengthUnits.Meter);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Meter, CubicMeter);
            dict.AddRelated<VolumeUnit, LengthUnit>(CubicKm, LengthUnits.Km);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Km, CubicKm);
            dict.AddRelated<VolumeUnit, LengthUnit>(CubicDm, LengthUnits.Dm);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Dm, CubicDm);
            dict.AddRelated<VolumeUnit, LengthUnit>(CubicCm, LengthUnits.Cm);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Cm, CubicCm);
            dict.AddRelated<VolumeUnit, LengthUnit>(CubicMm, LengthUnits.Mm);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Mm, CubicMm);
            dict.AddRelated<VolumeUnit, LengthUnit>(CubicInch, LengthUnits.Inch);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Inch, CubicInch);
            dict.AddRelated<VolumeUnit, LengthUnit>(CubicFeet, LengthUnits.Feet);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Feet, CubicFeet);
            dict.AddRelated<VolumeUnit, LengthUnit>(CubicYard, LengthUnits.Yard);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Yard, CubicYard);
            dict.AddRelated<VolumeUnit, LengthUnit>(CubicFurlong, LengthUnits.Furlong);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Furlong, CubicFurlong);
            dict.AddRelated<VolumeUnit, LengthUnit>(CubicFathom, LengthUnits.Fathom);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Fathom, CubicFathom);
            dict.AddRelated<VolumeUnit, LengthUnit>(CubicMile, LengthUnits.Mile);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.Mile, CubicMile);
            dict.AddRelated<VolumeUnit, LengthUnit>(CubicNauticalMile, LengthUnits.NauticalMile);
            dict.AddRelated<LengthUnit, VolumeUnit>(LengthUnits.NauticalMile, CubicNauticalMile);
            dict.AddRelated<VolumeUnit, AreaUnit>(CubicMeter, AreaUnits.SquareMeter);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareMeter, CubicMeter);
            dict.AddRelated<VolumeUnit, AreaUnit>(CubicKm, AreaUnits.SquareKm);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareKm, CubicKm);
            dict.AddRelated<VolumeUnit, AreaUnit>(CubicDm, AreaUnits.SquareDm);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareDm, CubicDm);
            dict.AddRelated<VolumeUnit, AreaUnit>(CubicCm, AreaUnits.SquareCm);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareCm, CubicCm);
            dict.AddRelated<VolumeUnit, AreaUnit>(CubicMm, AreaUnits.SquareMm);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareMm, CubicMm);
            dict.AddRelated<VolumeUnit, AreaUnit>(CubicInch, AreaUnits.SquareInch);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareInch, CubicInch);
            dict.AddRelated<VolumeUnit, AreaUnit>(CubicFeet, AreaUnits.SquareFeet);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareFeet, CubicFeet);
            dict.AddRelated<VolumeUnit, AreaUnit>(CubicYard, AreaUnits.SquareYard);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareYard, CubicYard);
            dict.AddRelated<VolumeUnit, AreaUnit>(CubicFurlong, AreaUnits.SquareFurlong);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareFurlong, CubicFurlong);
            dict.AddRelated<VolumeUnit, AreaUnit>(CubicFathom, AreaUnits.SquareFathom);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareFathom, CubicFathom);
            dict.AddRelated<VolumeUnit, AreaUnit>(CubicMile, AreaUnits.SquareMile);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareMile, CubicMile);
            dict.AddRelated<VolumeUnit, AreaUnit>(CubicNauticalMile, AreaUnits.SquareNauticalMile);
            dict.AddRelated<AreaUnit, VolumeUnit>(AreaUnits.SquareNauticalMile, CubicNauticalMile);
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
                    CubicMeter,
                    CubicKm,
                    CubicDm,
                    CubicCm,
                    CubicMm,
                    CubicInch,
                    CubicFeet,
                    CubicYard,
                    CubicFurlong,
                    CubicFathom,
                    CubicMile,
                    CubicNauticalMile
                };
            }
        }

        private static readonly VolumeUnit CubicMeterVolumeUnit = new VolumeUnit(LengthUnits.Meter);

        public static readonly UnitDefinition<VolumeUnit> CubicMeter = new UnitDefinition<VolumeUnit>(CubicMeterVolumeUnit, 1m);

        private static readonly VolumeUnit CubicKmVolumeUnit = new VolumeUnit(LengthUnits.Km);

        public static readonly UnitDefinition<VolumeUnit> CubicKm = new UnitDefinition<VolumeUnit>(CubicKmVolumeUnit, 1000m * 1000m * 1000m);

        private static readonly VolumeUnit CubicDmVolumeUnit = new VolumeUnit(LengthUnits.Dm);

        public static readonly UnitDefinition<VolumeUnit> CubicDm = new UnitDefinition<VolumeUnit>(CubicDmVolumeUnit, 0.1m * 0.1m * 0.1m);

        private static readonly VolumeUnit CubicCmVolumeUnit = new VolumeUnit(LengthUnits.Cm);

        public static readonly UnitDefinition<VolumeUnit> CubicCm = new UnitDefinition<VolumeUnit>(CubicCmVolumeUnit, 0.01m * 0.01m * 0.01m);

        private static readonly VolumeUnit CubicMmVolumeUnit = new VolumeUnit(LengthUnits.Mm);

        public static readonly UnitDefinition<VolumeUnit> CubicMm = new UnitDefinition<VolumeUnit>(CubicMmVolumeUnit, 0.001m * 0.001m * 0.001m);

        private static readonly VolumeUnit CubicInchVolumeUnit = new VolumeUnit(LengthUnits.Inch);

        public static readonly UnitDefinition<VolumeUnit> CubicInch = new UnitDefinition<VolumeUnit>(CubicInchVolumeUnit, 0.0254m * 0.0254m * 0.0254m);

        private static readonly VolumeUnit CubicFeetVolumeUnit = new VolumeUnit(LengthUnits.Feet);

        public static readonly UnitDefinition<VolumeUnit> CubicFeet = new UnitDefinition<VolumeUnit>(CubicFeetVolumeUnit, 0.3048m * 0.3048m * 0.3048m);

        private static readonly VolumeUnit CubicYardVolumeUnit = new VolumeUnit(LengthUnits.Yard);

        public static readonly UnitDefinition<VolumeUnit> CubicYard = new UnitDefinition<VolumeUnit>(CubicYardVolumeUnit, 0.9144m * 0.9144m * 0.9144m);

        private static readonly VolumeUnit CubicFurlongVolumeUnit = new VolumeUnit(LengthUnits.Furlong);

        public static readonly UnitDefinition<VolumeUnit> CubicFurlong = new UnitDefinition<VolumeUnit>(CubicFurlongVolumeUnit, 201.1680m * 201.1680m * 201.1680m);

        private static readonly VolumeUnit CubicFathomVolumeUnit = new VolumeUnit(LengthUnits.Fathom);

        public static readonly UnitDefinition<VolumeUnit> CubicFathom = new UnitDefinition<VolumeUnit>(CubicFathomVolumeUnit, 1.8288m * 1.8288m * 1.8288m);

        private static readonly VolumeUnit CubicMileVolumeUnit = new VolumeUnit(LengthUnits.Mile);

        public static readonly UnitDefinition<VolumeUnit> CubicMile = new UnitDefinition<VolumeUnit>(CubicMileVolumeUnit, 1609.344m * 1609.344m * 1609.344m);

        private static readonly VolumeUnit CubicNauticalMileVolumeUnit = new VolumeUnit(LengthUnits.NauticalMile);

        public static readonly UnitDefinition<VolumeUnit> CubicNauticalMile = new UnitDefinition<VolumeUnit>(CubicNauticalMileVolumeUnit, 1852m * 1852m * 1852m);

    }
}
