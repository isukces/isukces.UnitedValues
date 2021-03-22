// ReSharper disable All
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
            // generator : AlgebraGenerator2.CreateOperator:61
            var rightUnit = GlobalUnitRegistry.Relations.Get<LengthUnit, LengthUnit>(leftFactor.Unit);
            if (rightUnit is null)
                throw new Exception($"Unable to convert {rightFactor.Unit} into {typeof(LengthUnit)}");
            var resultUnit = GlobalUnitRegistry.Relations.Get<LengthUnit, AreaUnit>(leftFactor.Unit);
            if (resultUnit is null)
                throw new Exception($"Unable to convert {rightFactor.Unit} into {typeof(AreaUnit)}");
            var rightFactorConverted = rightFactor.ConvertTo(rightUnit.Item1);
            var value          = leftFactor.Value * rightFactorConverted.Value;
            return new Area(value, resultUnit.Item1);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="leftFactor">left factor (multiplicand)</param>
        /// <param name="rightFactor">rigth factor (multiplier)</param>
        public static Volume operator *(Length leftFactor, Area rightFactor)
        {
            // generator : AlgebraGenerator2.CreateOperator:61
            var rightUnit = GlobalUnitRegistry.Relations.Get<LengthUnit, AreaUnit>(leftFactor.Unit);
            if (rightUnit is null)
                throw new Exception($"Unable to convert {rightFactor.Unit} into {typeof(AreaUnit)}");
            var resultUnit = GlobalUnitRegistry.Relations.Get<LengthUnit, VolumeUnit>(leftFactor.Unit);
            if (resultUnit is null)
                throw new Exception($"Unable to convert {rightFactor.Unit} into {typeof(VolumeUnit)}");
            var rightFactorConverted = rightFactor.ConvertTo(rightUnit.Item1);
            var value          = leftFactor.Value * rightFactorConverted.Value;
            return new Volume(value, resultUnit.Item1);
        }

    }
}
