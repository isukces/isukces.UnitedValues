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

    }
}
