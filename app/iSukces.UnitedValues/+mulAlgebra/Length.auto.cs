// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct Length
    {
        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="leftFactor">left factor (multiplicand)</param>
        /// <param name="rightFactor">rigth factor (multiplier)</param>
        public static Area operator *(Length leftFactor, Length rightFactor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRelatedUnits
            // scenario C
            var rightUnit = GlobalUnitRegistry.Relations.GetOrThrow<LengthUnit, LengthUnit>(leftFactor.Unit);
            var resultUnit = GlobalUnitRegistry.Relations.GetOrThrow<LengthUnit, AreaUnit>(leftFactor.Unit);
            var rightFactorConverted = rightFactor.ConvertTo(rightUnit);
            var value = leftFactor.Value * rightFactorConverted.Value;
            return new Area(value, resultUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="leftFactor">left factor (multiplicand)</param>
        /// <param name="rightFactor">rigth factor (multiplier)</param>
        public static Area? operator *(Length? leftFactor, Length rightFactor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (leftFactor is null)
                return null;
            return leftFactor.Value * rightFactor;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="leftFactor">left factor (multiplicand)</param>
        /// <param name="rightFactor">rigth factor (multiplier)</param>
        public static Area? operator *(Length leftFactor, Length? rightFactor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (rightFactor is null)
                return null;
            return leftFactor * rightFactor.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="leftFactor">left factor (multiplicand)</param>
        /// <param name="rightFactor">rigth factor (multiplier)</param>
        public static Area? operator *(Length? leftFactor, Length? rightFactor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (leftFactor is null || rightFactor is null)
                return null;
            return leftFactor.Value * rightFactor.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearDensity">rigth factor (multiplier)</param>
        public static Mass operator *(Length length, LinearDensity linearDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario B
            var unit = new LinearDensityUnit(linearDensity.Unit.CounterUnit, length.Unit);
            var linearDensityConverted    = linearDensity.WithDenominatorUnit(length.Unit);
            var value = length.Value * linearDensityConverted.Value;
            return new Mass(value, linearDensity.Unit.CounterUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Mass operator *(LinearDensity linearDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Mass operator *(LinearDensity linearDensity, Length length)
            // scenario D3
            var linearDensityUnit = linearDensity.Unit;
            var lengthConverted = length.ConvertTo(linearDensityUnit.DenominatorUnit);
            var value = linearDensity.Value * lengthConverted.Value;
            return new Mass(value, linearDensityUnit.CounterUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearDensity">rigth factor (multiplier)</param>
        public static Mass? operator *(Length? length, LinearDensity linearDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return length.Value * linearDensity;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Mass? operator *(LinearDensity? linearDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null)
                return null;
            return linearDensity.Value * length;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearDensity">rigth factor (multiplier)</param>
        public static Mass? operator *(Length length, LinearDensity? linearDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null)
                return null;
            return length * linearDensity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Mass? operator *(LinearDensity linearDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return linearDensity * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearDensity">rigth factor (multiplier)</param>
        public static Mass? operator *(Length? length, LinearDensity? linearDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null || linearDensity is null)
                return null;
            return length.Value * linearDensity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Mass? operator *(LinearDensity? linearDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null || length is null)
                return null;
            return linearDensity.Value * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static LinearDensity operator *(Length length, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario with hint
            var rightArgumentUnit = planarDensity.Unit;
            var areaUnit = length.Unit.GetAreaUnit();
            var x3 = new PlanarDensityUnit(rightArgumentUnit.CounterUnit, areaUnit);
            var planarDensityConverted = planarDensity.ConvertTo(x3);
            var value = length.Value * planarDensityConverted.Value;
            return new LinearDensity(value, new LinearDensityUnit(rightArgumentUnit.CounterUnit, length.Unit));
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static LinearDensity operator *(PlanarDensity planarDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // LinearDensity operator *(PlanarDensity planarDensity, Length length)
            // scenario with hint
            var lengthUnit = planarDensity.Unit.DenominatorUnit.GetLengthUnit();
            var lengthConverted = length.ConvertTo(lengthUnit);
            var value = planarDensity.Value * lengthConverted.Value;
            return new LinearDensity(value, new LinearDensityUnit(planarDensity.Unit.CounterUnit, lengthUnit));
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(Length? length, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return length.Value * planarDensity;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(PlanarDensity? planarDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null)
                return null;
            return planarDensity.Value * length;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(Length length, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null)
                return null;
            return length * planarDensity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(PlanarDensity planarDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return planarDensity * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(Length? length, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null || planarDensity is null)
                return null;
            return length.Value * planarDensity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(PlanarDensity? planarDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null || length is null)
                return null;
            return planarDensity.Value * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static PlanarDensity operator *(Length length, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario with hint
            var rightArgumentUnit = density.Unit;
            var areaUnit = length.Unit.GetAreaUnit();
            var volumeUnit = length.Unit.GetVolumeUnit();
            var x3 = new DensityUnit(rightArgumentUnit.CounterUnit, volumeUnit);
            var densityConverted = density.ConvertTo(x3);
            var value = length.Value * densityConverted.Value;
            return new PlanarDensity(value, new PlanarDensityUnit(rightArgumentUnit.CounterUnit, areaUnit));
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static PlanarDensity operator *(Density density, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // PlanarDensity operator *(Density density, Length length)
            // scenario with hint
            var areaUnit = density.Unit.DenominatorUnit.GetAreaUnit();
            var lengthUnit = density.Unit.DenominatorUnit.GetLengthUnit();
            var lengthConverted = length.ConvertTo(lengthUnit);
            var value = density.Value * lengthConverted.Value;
            return new PlanarDensity(value, new PlanarDensityUnit(density.Unit.CounterUnit, areaUnit));
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static PlanarDensity? operator *(Length? length, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return length.Value * density;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static PlanarDensity? operator *(Density? density, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return density.Value * length;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static PlanarDensity? operator *(Length length, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return length * density.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static PlanarDensity? operator *(Density density, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return density * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static PlanarDensity? operator *(Length? length, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null || density is null)
                return null;
            return length.Value * density.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static PlanarDensity? operator *(Density? density, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null || length is null)
                return null;
            return density.Value * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearForce">rigth factor (multiplier)</param>
        public static Force operator *(Length length, LinearForce linearForce)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario B
            var unit = new LinearForceUnit(linearForce.Unit.CounterUnit, length.Unit);
            var linearForceConverted    = linearForce.WithDenominatorUnit(length.Unit);
            var value = length.Value * linearForceConverted.Value;
            return new Force(value, linearForce.Unit.CounterUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearForce">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Force operator *(LinearForce linearForce, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Force operator *(LinearForce linearForce, Length length)
            // scenario D3
            var linearForceUnit = linearForce.Unit;
            var lengthConverted = length.ConvertTo(linearForceUnit.DenominatorUnit);
            var value = linearForce.Value * lengthConverted.Value;
            return new Force(value, linearForceUnit.CounterUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearForce">rigth factor (multiplier)</param>
        public static Force? operator *(Length? length, LinearForce linearForce)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return length.Value * linearForce;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearForce">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Force? operator *(LinearForce? linearForce, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null)
                return null;
            return linearForce.Value * length;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearForce">rigth factor (multiplier)</param>
        public static Force? operator *(Length length, LinearForce? linearForce)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null)
                return null;
            return length * linearForce.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearForce">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Force? operator *(LinearForce linearForce, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return linearForce * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearForce">rigth factor (multiplier)</param>
        public static Force? operator *(Length? length, LinearForce? linearForce)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null || linearForce is null)
                return null;
            return length.Value * linearForce.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearForce">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Force? operator *(LinearForce? linearForce, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null || length is null)
                return null;
            return linearForce.Value * length.Value;
        }

    }
}
