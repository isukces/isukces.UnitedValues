// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct PlanarDensity
    {
        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="planarDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density operator /(PlanarDensity planarDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Density operator /(PlanarDensity planarDensity, Length length)
            // scenario with hint
            // .Is<PlanarDensity, Length, Density>("/")
            var planarDensityUnit = planarDensity.Unit;
            var tmp1 = planarDensityUnit.DenominatorUnit;
            var resultUnit = new DensityUnit(planarDensityUnit.CounterUnit, tmp1.GetVolumeUnit());
            var lengthConverted = length.ConvertTo(tmp1.GetLengthUnit());
            var value = planarDensity.Value / lengthConverted.Value;
            return new Density(value, resultUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="planarDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length operator /(PlanarDensity planarDensity, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<PlanarDensity, Density, Length>("/")
            var planarDensityUnit = planarDensity.Unit;
            var tmp1 = planarDensityUnit.DenominatorUnit;
            var targetRightUnit = new DensityUnit(planarDensityUnit.CounterUnit, tmp1.GetVolumeUnit());
            var densityConverted = density.ConvertTo(targetRightUnit);
            var value = planarDensity.Value / densityConverted.Value;
            return new Length(value, tmp1.GetLengthUnit());
            // scenario F1
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="planarDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(PlanarDensity? planarDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null)
                return null;
            return planarDensity.Value / length;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="planarDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(PlanarDensity? planarDensity, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null)
                return null;
            return planarDensity.Value / density;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="planarDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(PlanarDensity planarDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return planarDensity / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="planarDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(PlanarDensity planarDensity, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return planarDensity / density.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="planarDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(PlanarDensity? planarDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null || length is null)
                return null;
            return planarDensity.Value / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="planarDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(PlanarDensity? planarDensity, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null || density is null)
                return null;
            return planarDensity.Value / density.Value;
        }

    }
}
