// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct LinearDensity
    {
        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static PlanarDensity operator /(LinearDensity linearDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // PlanarDensity operator /(LinearDensity linearDensity, Length length)
            // scenario with hint
            // .Is<LinearDensity, Length, PlanarDensity>("/")
            var linearDensityUnit = linearDensity.Unit;
            var tmp1 = linearDensityUnit.DenominatorUnit;
            var resultUnit = new PlanarDensityUnit(linearDensityUnit.CounterUnit, tmp1.GetAreaUnit());
            var lengthConverted = length.ConvertTo(tmp1);
            var value = linearDensity.Value / lengthConverted.Value;
            return new PlanarDensity(value, resultUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="planarDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length operator /(LinearDensity linearDensity, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<LinearDensity, PlanarDensity, Length>("/")
            var linearDensityUnit = linearDensity.Unit;
            var tmp1 = linearDensityUnit.DenominatorUnit;
            var targetRightUnit = new PlanarDensityUnit(linearDensityUnit.CounterUnit, tmp1.GetAreaUnit());
            var planarDensityConverted = planarDensity.ConvertTo(targetRightUnit);
            var value = linearDensity.Value / planarDensityConverted.Value;
            return new Length(value, tmp1);
            // scenario F1
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static PlanarDensity? operator /(LinearDensity? linearDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null)
                return null;
            return linearDensity.Value / length;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="planarDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(LinearDensity? linearDensity, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null)
                return null;
            return linearDensity.Value / planarDensity;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static PlanarDensity? operator /(LinearDensity linearDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return linearDensity / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="planarDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(LinearDensity linearDensity, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null)
                return null;
            return linearDensity / planarDensity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static PlanarDensity? operator /(LinearDensity? linearDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null || length is null)
                return null;
            return linearDensity.Value / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="planarDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(LinearDensity? linearDensity, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null || planarDensity is null)
                return null;
            return linearDensity.Value / planarDensity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density operator /(LinearDensity linearDensity, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Density operator /(LinearDensity linearDensity, Area area)
            // scenario with hint
            // .Is<LinearDensity, Area, Density>("/")
            var linearDensityUnit = linearDensity.Unit;
            var tmp1 = linearDensityUnit.DenominatorUnit;
            var resultUnit = new DensityUnit(linearDensityUnit.CounterUnit, tmp1.GetVolumeUnit());
            var areaConverted = area.ConvertTo(tmp1.GetAreaUnit());
            var value = linearDensity.Value / areaConverted.Value;
            return new Density(value, resultUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area operator /(LinearDensity linearDensity, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<LinearDensity, Density, Area>("/")
            var linearDensityUnit = linearDensity.Unit;
            var tmp1 = linearDensityUnit.DenominatorUnit;
            var targetRightUnit = new DensityUnit(linearDensityUnit.CounterUnit, tmp1.GetVolumeUnit());
            var densityConverted = density.ConvertTo(targetRightUnit);
            var value = linearDensity.Value / densityConverted.Value;
            return new Area(value, tmp1.GetAreaUnit());
            // scenario F1
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(LinearDensity? linearDensity, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null)
                return null;
            return linearDensity.Value / area;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(LinearDensity? linearDensity, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null)
                return null;
            return linearDensity.Value / density;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(LinearDensity linearDensity, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return linearDensity / area.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(LinearDensity linearDensity, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return linearDensity / density.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(LinearDensity? linearDensity, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null || area is null)
                return null;
            return linearDensity.Value / area.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(LinearDensity? linearDensity, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null || density is null)
                return null;
            return linearDensity.Value / density.Value;
        }

    }
}
