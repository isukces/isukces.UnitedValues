// ReSharper disable All
using System;

namespace iSukces.UnitedValues
{
    public partial struct Force
    {
        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="dividend">a dividend (counter) - a value that is being divided</param>
        /// <param name="divisor">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure operator /(Force dividend, Area divisor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForFractionalResult
            // scenario E
            return new Pressure(dividend.Value / divisor.Value, dividend.Unit, divisor.Unit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="dividend">a dividend (counter) - a value that is being divided</param>
        /// <param name="divisor">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area operator /(Force dividend, Pressure divisor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario A
            // pressure unit will be synchronized with force unit
            var unit = new PressureUnit(dividend.Unit, divisor.Unit.DenominatorUnit);
            var divisorConverted    = divisor.WithCounterUnit(dividend.Unit);
            var value = dividend.Value / divisorConverted.Value;
            return new Area(value, divisor.Unit.DenominatorUnit);
        }

    }
}
