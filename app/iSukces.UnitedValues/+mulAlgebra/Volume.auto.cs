// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct Volume
    {
        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volume">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length operator /(Volume volume, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRelatedUnits
            // scenario C
            var rightUnit = GlobalUnitRegistry.Relations.GetOrThrow<VolumeUnit, AreaUnit>(volume.Unit);
            var resultUnit = GlobalUnitRegistry.Relations.GetOrThrow<VolumeUnit, LengthUnit>(volume.Unit);
            var areaConverted = area.ConvertTo(rightUnit);
            var value = volume.Value / areaConverted.Value;
            return new Length(value, resultUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volume">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area operator /(Volume volume, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRelatedUnits
            // scenario C
            var rightUnit = GlobalUnitRegistry.Relations.GetOrThrow<VolumeUnit, LengthUnit>(volume.Unit);
            var resultUnit = GlobalUnitRegistry.Relations.GetOrThrow<VolumeUnit, AreaUnit>(volume.Unit);
            var lengthConverted = length.ConvertTo(rightUnit);
            var value = volume.Value / lengthConverted.Value;
            return new Area(value, resultUnit);
        }

    }
}
