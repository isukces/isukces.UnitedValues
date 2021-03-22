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
        public static Volume operator *(Length leftFactor, Area rightFactor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRelatedUnits
            // scenario C
            var rightUnit = GlobalUnitRegistry.Relations.GetOrThrow<LengthUnit, AreaUnit>(leftFactor.Unit);
            var resultUnit = GlobalUnitRegistry.Relations.GetOrThrow<LengthUnit, VolumeUnit>(leftFactor.Unit);
            var rightFactorConverted = rightFactor.ConvertTo(rightUnit);
            var value = leftFactor.Value * rightFactorConverted.Value;
            return new Volume(value, resultUnit);
        }

    }
}
