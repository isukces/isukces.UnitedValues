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
        /// <param name="linearForce">rigth factor (multiplier)</param>
        public static Force operator *(Length length, LinearForce linearForce)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario B
            var unit = new LinearForceUnit(linearForce.Unit.CounterUnit, length.Unit);
            var linearForceConverted    = linearForce.WithDenominatorUnit(length.Unit);
            var value = length.Value / linearForceConverted.Value;
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
            // length unit will be taken from denominator of linearforce unit
            // scenario D
            var lengthConverted = length.ConvertTo(linearForce.Unit.DenominatorUnit);
            var value = lengthConverted.Value * linearForce.Value;
            return new Force(value, linearForce.Unit.CounterUnit);
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
            var value = length.Value / linearDensityConverted.Value;
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
            // length unit will be taken from denominator of lineardensity unit
            // scenario D
            var lengthConverted = length.ConvertTo(linearDensity.Unit.DenominatorUnit);
            var value = lengthConverted.Value * linearDensity.Value;
            return new Mass(value, linearDensity.Unit.CounterUnit);
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

    }
}
