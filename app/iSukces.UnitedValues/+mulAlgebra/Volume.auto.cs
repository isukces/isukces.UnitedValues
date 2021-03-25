// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct Volume
    {
        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="volume">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static Mass operator *(Volume volume, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario B
            var unit = new DensityUnit(density.Unit.CounterUnit, volume.Unit);
            var densityConverted    = density.WithDenominatorUnit(volume.Unit);
            var value = volume.Value / densityConverted.Value;
            return new Mass(value, density.Unit.CounterUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="volume">rigth factor (multiplier)</param>
        public static Mass operator *(Density density, Volume volume)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // volume unit will be taken from denominator of density unit
            // scenario D
            var volumeConverted = volume.ConvertTo(density.Unit.DenominatorUnit);
            var value = volumeConverted.Value * density.Value;
            return new Mass(value, density.Unit.CounterUnit);
        }

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
