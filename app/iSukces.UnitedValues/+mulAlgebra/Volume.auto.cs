// ReSharper disable All
using System;

namespace iSukces.UnitedValues
{
    public partial struct Volume
    {
        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="dividend">a dividend (counter) - a value that is being divided</param>
        /// <param name="divisor">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length operator /(Volume dividend, Area divisor)
        {
            // generator : AlgebraGenerator2.CreateOperator:61
            var rightUnit = GlobalUnitRegistry.Relations.Get<VolumeUnit, AreaUnit>(dividend.Unit);
            if (rightUnit is null)
                throw new Exception($"Unable to convert {divisor.Unit} into {typeof(AreaUnit)}");
            var resultUnit = GlobalUnitRegistry.Relations.Get<VolumeUnit, LengthUnit>(dividend.Unit);
            if (resultUnit is null)
                throw new Exception($"Unable to convert {divisor.Unit} into {typeof(LengthUnit)}");
            var divisorConverted = divisor.ConvertTo(rightUnit.Item1);
            var value          = dividend.Value / divisorConverted.Value;
            return new Length(value, resultUnit.Item1);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="dividend">a dividend (counter) - a value that is being divided</param>
        /// <param name="divisor">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area operator /(Volume dividend, Length divisor)
        {
            // generator : AlgebraGenerator2.CreateOperator:61
            var rightUnit = GlobalUnitRegistry.Relations.Get<VolumeUnit, LengthUnit>(dividend.Unit);
            if (rightUnit is null)
                throw new Exception($"Unable to convert {divisor.Unit} into {typeof(LengthUnit)}");
            var resultUnit = GlobalUnitRegistry.Relations.Get<VolumeUnit, AreaUnit>(dividend.Unit);
            if (resultUnit is null)
                throw new Exception($"Unable to convert {divisor.Unit} into {typeof(AreaUnit)}");
            var divisorConverted = divisor.ConvertTo(rightUnit.Item1);
            var value          = dividend.Value / divisorConverted.Value;
            return new Area(value, resultUnit.Item1);
        }

    }
}
