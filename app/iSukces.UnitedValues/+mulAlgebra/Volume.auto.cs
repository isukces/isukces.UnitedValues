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
            var value = volume.Value * densityConverted.Value;
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
            // Mass operator *(Density density, Volume volume)
            // scenario with hint
            // .Is<Density, Volume, Mass>("*")
            // hint location GetBasicOperatorHints, line 31
            var densityUnit = density.Unit;
            var volumeConverted = volume.ConvertTo(densityUnit.DenominatorUnit);
            var value = density.Value * volumeConverted.Value;
            return new Mass(value, densityUnit.CounterUnit);
            // scenario D1
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="volume">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static Mass? operator *(Volume? volume, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volume is null)
                return null;
            return volume.Value * density;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="volume">rigth factor (multiplier)</param>
        public static Mass? operator *(Density? density, Volume volume)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return density.Value * volume;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="volume">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static Mass? operator *(Volume volume, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return volume * density.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="volume">rigth factor (multiplier)</param>
        public static Mass? operator *(Density density, Volume? volume)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volume is null)
                return null;
            return density * volume.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="volume">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static Mass? operator *(Volume? volume, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volume is null || density is null)
                return null;
            return volume.Value * density.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="volume">rigth factor (multiplier)</param>
        public static Mass? operator *(Density? density, Volume? volume)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null || volume is null)
                return null;
            return density.Value * volume.Value;
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

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volume">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(Volume? volume, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volume is null)
                return null;
            return volume.Value / area;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volume">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(Volume? volume, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volume is null)
                return null;
            return volume.Value / length;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volume">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(Volume volume, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return volume / area.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volume">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(Volume volume, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return volume / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volume">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(Volume? volume, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volume is null || area is null)
                return null;
            return volume.Value / area.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volume">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(Volume? volume, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volume is null || length is null)
                return null;
            return volume.Value / length.Value;
        }

    }
}
