// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct LinearForce
    {
        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure operator /(LinearForce linearForce, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Pressure operator /(LinearForce linearForce, Length length)
            // scenario with hint
            // hint location HandleCreateOperatorCode, line 49 Def_LinearForce_Length_Pressure
            var leftConverted = linearForce.ConvertTo(new LinearForceUnit(ForceUnits.Newton, LengthUnits.Meter));
            var rightConverted = length.ConvertTo(LengthUnits.Meter);
            var value = leftConverted.Value / rightConverted.Value;
            return new Pressure(value, PressureUnits.Pascal);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="pressure">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length operator /(LinearForce linearForce, Pressure pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Length operator /(LinearForce linearForce, Pressure pressure)
            // scenario with hint
            // hint location HandleCreateOperatorCode, line 42 Def_LinearForce_Length_Pressure
            var leftConverted = linearForce.ConvertTo(new LinearForceUnit(ForceUnits.Newton, LengthUnits.Meter));
            var rightConverted = pressure.ConvertTo(PressureUnits.Pascal);
            var value = leftConverted.Value / rightConverted.Value;
            return new Length(value, LengthUnits.Meter);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure? operator /(LinearForce? linearForce, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null)
                return null;
            return linearForce.Value / length;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="pressure">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(LinearForce? linearForce, Pressure pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null)
                return null;
            return linearForce.Value / pressure;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure? operator /(LinearForce linearForce, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return linearForce / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="pressure">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(LinearForce linearForce, Pressure? pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (pressure is null)
                return null;
            return linearForce / pressure.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure? operator /(LinearForce? linearForce, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null || length is null)
                return null;
            return linearForce.Value / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearForce">a dividend (counter) - a value that is being divided</param>
        /// <param name="pressure">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(LinearForce? linearForce, Pressure? pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null || pressure is null)
                return null;
            return linearForce.Value / pressure.Value;
        }

    }
}
