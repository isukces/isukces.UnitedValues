// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct Mass
    {
        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static LinearDensity operator /(Mass mass, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForFractionalResult
            // scenario E
            return new LinearDensity(mass.Value / length.Value, mass.Unit, length.Unit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="linearDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length operator /(Mass mass, LinearDensity linearDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario A
            // lineardensity unit will be synchronized with mass unit
            var unit = new LinearDensityUnit(mass.Unit, linearDensity.Unit.DenominatorUnit);
            var linearDensityConverted    = linearDensity.WithCounterUnit(mass.Unit);
            var value = mass.Value / linearDensityConverted.Value;
            return new Length(value, linearDensity.Unit.DenominatorUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static PlanarDensity operator /(Mass mass, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForFractionalResult
            // scenario E
            return new PlanarDensity(mass.Value / area.Value, mass.Unit, area.Unit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="planarDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area operator /(Mass mass, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario A
            // planardensity unit will be synchronized with mass unit
            var unit = new PlanarDensityUnit(mass.Unit, planarDensity.Unit.DenominatorUnit);
            var planarDensityConverted    = planarDensity.WithCounterUnit(mass.Unit);
            var value = mass.Value / planarDensityConverted.Value;
            return new Area(value, planarDensity.Unit.DenominatorUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="volume">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density operator /(Mass mass, Volume volume)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForFractionalResult
            // scenario E
            return new Density(mass.Value / volume.Value, mass.Unit, volume.Unit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Volume operator /(Mass mass, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario A
            // density unit will be synchronized with mass unit
            var unit = new DensityUnit(mass.Unit, density.Unit.DenominatorUnit);
            var densityConverted    = density.WithCounterUnit(mass.Unit);
            var value = mass.Value / densityConverted.Value;
            return new Volume(value, density.Unit.DenominatorUnit);
        }

    }
}
