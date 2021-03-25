// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct Force
    {
        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure operator /(Force force, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForFractionalResult
            // scenario E
            return new Pressure(force.Value / area.Value, force.Unit, area.Unit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="pressure">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area operator /(Force force, Pressure pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario A
            // pressure unit will be synchronized with force unit
            var unit = new PressureUnit(force.Unit, pressure.Unit.DenominatorUnit);
            var pressureConverted    = pressure.WithCounterUnit(force.Unit);
            var value = force.Value / pressureConverted.Value;
            return new Area(value, pressure.Unit.DenominatorUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure? operator /(Force? force, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (force is null)
                return null;
            return force.Value / area;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="pressure">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(Force? force, Pressure pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (force is null)
                return null;
            return force.Value / pressure;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure? operator /(Force force, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return force / area.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="pressure">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(Force force, Pressure? pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (pressure is null)
                return null;
            return force / pressure.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure? operator /(Force? force, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (force is null || area is null)
                return null;
            return force.Value / area.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="pressure">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(Force? force, Pressure? pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (force is null || pressure is null)
                return null;
            return force.Value / pressure.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static LinearForce operator /(Force force, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForFractionalResult
            // scenario E
            return new LinearForce(force.Value / length.Value, force.Unit, length.Unit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="linearForce">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length operator /(Force force, LinearForce linearForce)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario A
            // linearforce unit will be synchronized with force unit
            var unit = new LinearForceUnit(force.Unit, linearForce.Unit.DenominatorUnit);
            var linearForceConverted    = linearForce.WithCounterUnit(force.Unit);
            var value = force.Value / linearForceConverted.Value;
            return new Length(value, linearForce.Unit.DenominatorUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static LinearForce? operator /(Force? force, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (force is null)
                return null;
            return force.Value / length;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="linearForce">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(Force? force, LinearForce linearForce)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (force is null)
                return null;
            return force.Value / linearForce;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static LinearForce? operator /(Force force, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return force / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="linearForce">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(Force force, LinearForce? linearForce)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null)
                return null;
            return force / linearForce.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static LinearForce? operator /(Force? force, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (force is null || length is null)
                return null;
            return force.Value / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="linearForce">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(Force? force, LinearForce? linearForce)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (force is null || linearForce is null)
                return null;
            return force.Value / linearForce.Value;
        }

    }
}
