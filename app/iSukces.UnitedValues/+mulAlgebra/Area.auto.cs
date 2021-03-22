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
            // generator : AlgebraGenerator2.CreateOperator:61
            var rightUnit = GlobalUnitRegistry.Relations.Get<AreaUnit, LengthUnit>(leftFactor.Unit);
            if (rightUnit is null)
                throw new Exception($"Unable to convert {rightFactor.Unit} into {typeof(LengthUnit)}");
            var resultUnit = GlobalUnitRegistry.Relations.Get<AreaUnit, VolumeUnit>(leftFactor.Unit);
            if (resultUnit is null)
                throw new Exception($"Unable to convert {rightFactor.Unit} into {typeof(VolumeUnit)}");
            var rightFactorConverted = rightFactor.ConvertTo(rightUnit.Item1);
            var value          = leftFactor.Value * rightFactorConverted.Value;
            return new Volume(value, resultUnit.Item1);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="dividend">a dividend (counter) - a value that is being divided</param>
        /// <param name="divisor">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length operator /(Area dividend, Length divisor)
        {
            // generator : AlgebraGenerator2.CreateOperator:61
            var newUnit = GlobalUnitRegistry.Relations.Get<AreaUnit, LengthUnit>(dividend.Unit);
            if (newUnit is null)
                throw new Exception($"Unable to convert {divisor.Unit} into {typeof(LengthUnit)}");
            var divisorConverted = divisor.ConvertTo(newUnit.Item1);
            var value          = dividend.Value / divisorConverted.Value;
            return new Length(value, newUnit.Item1);
        }

    }
}
