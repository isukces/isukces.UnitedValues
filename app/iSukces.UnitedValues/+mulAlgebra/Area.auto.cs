// ReSharper disable All
using System;

namespace iSukces.UnitedValues
{
    public partial struct Area
    {
        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="leftFactor">left factor (multiplicand)</param>
        /// <param name="rightFactor">rigth factor (multiplier)</param>
        public static Volume operator *(Area leftFactor, Length rightFactor)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator:46
            var rightUnit = GlobalUnitRegistry.Relations.GetOrThrow<AreaUnit, LengthUnit>(leftFactor.Unit);
            var resultUnit = GlobalUnitRegistry.Relations.GetOrThrow<AreaUnit, VolumeUnit>(leftFactor.Unit);
            var rightFactorConverted = rightFactor.ConvertTo(rightUnit);
            var value          = leftFactor.Value * rightFactorConverted.Value;
            return new Volume(value, resultUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="dividend">a dividend (counter) - a value that is being divided</param>
        /// <param name="divisor">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length operator /(Area dividend, Length divisor)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator:46
            var newUnit = GlobalUnitRegistry.Relations.GetOrThrow<AreaUnit, LengthUnit>(dividend.Unit);
            var divisorConverted = divisor.ConvertTo(newUnit);
            var value          = dividend.Value / divisorConverted.Value;
            return new Length(value, newUnit);
        }

    }
}
