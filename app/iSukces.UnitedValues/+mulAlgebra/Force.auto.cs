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
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static LinearForce operator /(Force force, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // hint location HandleCreateOperatorCode, line 19 Def_Force_Length_LinearForce
            var value = force.Value / length.Value;
            return new LinearForce(value, new LinearForceUnit(force.Unit, length.Unit));
            // scenario F3
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

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Pressure operator /(Force force, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<Force, Area, Pressure>("/")
            // hint location HandleCreateOperatorCode, line 24
            var leftConverted = force.ConvertTo(ForceUnits.Newton);
            var rightConverted = area.ConvertTo(AreaUnits.SquareMeter);
            var value = leftConverted.Value / rightConverted.Value;
            return new Pressure(value, PressureUnits.Pascal);
            // scenario F3
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="force">a dividend (counter) - a value that is being divided</param>
        /// <param name="pressure">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area operator /(Force force, Pressure pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<Force, Pressure, Area>("/")
            // hint location HandleCreateOperatorCode, line 31
            var leftConverted = force.ConvertTo(ForceUnits.Newton);
            var rightConverted = pressure.ConvertTo(PressureUnits.Pascal);
            var value = leftConverted.Value / rightConverted.Value;
            return new Area(value, AreaUnits.SquareMeter);
            // scenario F3
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

    }
}
