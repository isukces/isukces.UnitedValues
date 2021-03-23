// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct Pressure
    {
        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="leftFactor">left factor (multiplicand)</param>
        /// <param name="rightFactor">rigth factor (multiplier)</param>
        public static Force operator *(Pressure leftFactor, Area rightFactor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // area unit will be taken from denominator of pressure unit
            // scenario D
            var rightFactorConverted = rightFactor.ConvertTo(leftFactor.Unit.DenominatorUnit);
            var value = rightFactorConverted.Value * leftFactor.Value;
            return new Force(value, leftFactor.Unit.CounterUnit);
        }

    }
}
