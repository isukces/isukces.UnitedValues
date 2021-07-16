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
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<Mass, Length, LinearDensity>("/")
            // hint location GetBasicOperatorHints, line 31
            var resultUnit = new LinearDensityUnit(mass.Unit, length.Unit);
            var value = mass.Value / length.Value;
            return new LinearDensity(value, resultUnit);
            // scenario F3
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
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static LinearDensity? operator /(Mass? mass, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (mass is null)
                return null;
            return mass.Value / length;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="linearDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(Mass? mass, LinearDensity linearDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (mass is null)
                return null;
            return mass.Value / linearDensity;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static LinearDensity? operator /(Mass mass, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return mass / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="linearDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(Mass mass, LinearDensity? linearDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null)
                return null;
            return mass / linearDensity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static LinearDensity? operator /(Mass? mass, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (mass is null || length is null)
                return null;
            return mass.Value / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="linearDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(Mass? mass, LinearDensity? linearDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (mass is null || linearDensity is null)
                return null;
            return mass.Value / linearDensity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static PlanarDensity operator /(Mass mass, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<Mass, Area, PlanarDensity>("/")
            // hint location GetBasicOperatorHints, line 31
            var resultUnit = new PlanarDensityUnit(mass.Unit, area.Unit);
            var value = mass.Value / area.Value;
            return new PlanarDensity(value, resultUnit);
            // scenario F3
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
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static PlanarDensity? operator /(Mass? mass, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (mass is null)
                return null;
            return mass.Value / area;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="planarDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(Mass? mass, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (mass is null)
                return null;
            return mass.Value / planarDensity;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static PlanarDensity? operator /(Mass mass, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return mass / area.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="planarDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(Mass mass, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null)
                return null;
            return mass / planarDensity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static PlanarDensity? operator /(Mass? mass, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (mass is null || area is null)
                return null;
            return mass.Value / area.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="planarDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(Mass? mass, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (mass is null || planarDensity is null)
                return null;
            return mass.Value / planarDensity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="volume">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density operator /(Mass mass, Volume volume)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<Mass, Volume, Density>("/")
            // hint location GetBasicOperatorHints, line 31
            var resultUnit = new DensityUnit(mass.Unit, volume.Unit);
            var value = mass.Value / volume.Value;
            return new Density(value, resultUnit);
            // scenario F3
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

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="volume">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(Mass? mass, Volume volume)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (mass is null)
                return null;
            return mass.Value / volume;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Volume? operator /(Mass? mass, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (mass is null)
                return null;
            return mass.Value / density;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="volume">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(Mass mass, Volume? volume)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volume is null)
                return null;
            return mass / volume.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Volume? operator /(Mass mass, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return mass / density.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="volume">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(Mass? mass, Volume? volume)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (mass is null || volume is null)
                return null;
            return mass.Value / volume.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="mass">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Volume? operator /(Mass? mass, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (mass is null || density is null)
                return null;
            return mass.Value / density.Value;
        }

    }
}
