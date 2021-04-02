// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct Energy
    {
        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energy">a dividend (counter) - a value that is being divided</param>
        /// <param name="time">a divisor (denominator) - a value which dividend is divided by</param>
        public static Power operator /(Energy energy, Time time)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            var energyUnit = energy.Unit;
            var tmp1 = energyUnit.GetSuggestedTimeUnit();
            var tmp2 = PowerUnit.CratePowerUnitFromEnergyAndTime(energyUnit, tmp1);
            var resultUnit = tmp2;
            var timeConverted = time.ConvertTo(tmp1);
            var value = energy.Value / timeConverted.Value * tmp2.Multiplication;
            return new Power(value, resultUnit);
            // scenario F3
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energy">a dividend (counter) - a value that is being divided</param>
        /// <param name="power">a divisor (denominator) - a value which dividend is divided by</param>
        public static Time operator /(Energy energy, Power power)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // Fill method Definition
            // .Is<Energy, Power, Time>("/")
            throw new NotImplementedException();
            // scenario F3
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energy">a dividend (counter) - a value that is being divided</param>
        /// <param name="time">a divisor (denominator) - a value which dividend is divided by</param>
        public static Power? operator /(Energy? energy, Time time)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energy is null)
                return null;
            return energy.Value / time;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energy">a dividend (counter) - a value that is being divided</param>
        /// <param name="power">a divisor (denominator) - a value which dividend is divided by</param>
        public static Time? operator /(Energy? energy, Power power)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energy is null)
                return null;
            return energy.Value / power;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energy">a dividend (counter) - a value that is being divided</param>
        /// <param name="time">a divisor (denominator) - a value which dividend is divided by</param>
        public static Power? operator /(Energy energy, Time? time)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (time is null)
                return null;
            return energy / time.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energy">a dividend (counter) - a value that is being divided</param>
        /// <param name="power">a divisor (denominator) - a value which dividend is divided by</param>
        public static Time? operator /(Energy energy, Power? power)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (power is null)
                return null;
            return energy / power.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energy">a dividend (counter) - a value that is being divided</param>
        /// <param name="time">a divisor (denominator) - a value which dividend is divided by</param>
        public static Power? operator /(Energy? energy, Time? time)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energy is null || time is null)
                return null;
            return energy.Value / time.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energy">a dividend (counter) - a value that is being divided</param>
        /// <param name="power">a divisor (denominator) - a value which dividend is divided by</param>
        public static Time? operator /(Energy? energy, Power? power)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energy is null || power is null)
                return null;
            return energy.Value / power.Value;
        }

    }
}
