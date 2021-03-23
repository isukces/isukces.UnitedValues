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
        /// <param name="dividend">a dividend (counter) - a value that is being divided</param>
        /// <param name="divisor">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length operator /(Volume dividend, Area divisor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRelatedUnits
            // scenario C
            var rightUnit = GlobalUnitRegistry.Relations.GetOrThrow<VolumeUnit, AreaUnit>(dividend.Unit);
            var resultUnit = GlobalUnitRegistry.Relations.GetOrThrow<VolumeUnit, LengthUnit>(dividend.Unit);
            var divisorConverted = divisor.ConvertTo(rightUnit);
            var value = dividend.Value / divisorConverted.Value;
            return new Length(value, resultUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="dividend">a dividend (counter) - a value that is being divided</param>
        /// <param name="divisor">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area operator /(Volume dividend, Length divisor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRelatedUnits
            // scenario C
            var rightUnit = GlobalUnitRegistry.Relations.GetOrThrow<VolumeUnit, LengthUnit>(dividend.Unit);
            var resultUnit = GlobalUnitRegistry.Relations.GetOrThrow<VolumeUnit, AreaUnit>(dividend.Unit);
            var divisorConverted = divisor.ConvertTo(rightUnit);
            var value = dividend.Value / divisorConverted.Value;
            return new Area(value, resultUnit);
        }

    }
}
