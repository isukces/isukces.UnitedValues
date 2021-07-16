// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct Power
    {
        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="power">a dividend (counter) - a value that is being divided</param>
        /// <param name="energyMassDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static MassStream operator /(Power power, EnergyMassDensity energyMassDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario with hint
            // .Is<Power, EnergyMassDensity, MassStream>("/")
            // hint location HandleCreateOperatorCode, line 16
            var ru = energyMassDensity.Unit;
            var energy = new Energy(energyMassDensity.Value, ru.CounterUnit);
            var time = energy / power;
            var value = 1 / time.Value;
            return new MassStream(value, new MassStreamUnit(ru.DenominatorUnit, time.Unit));
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="power">a dividend (counter) - a value that is being divided</param>
        /// <param name="massStream">a divisor (denominator) - a value which dividend is divided by</param>
        public static EnergyMassDensity operator /(Power power, MassStream massStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario G
            throw new NotImplementedException("Not implemented yet");
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="power">a dividend (counter) - a value that is being divided</param>
        /// <param name="energyMassDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static MassStream? operator /(Power? power, EnergyMassDensity energyMassDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (power is null)
                return null;
            return power.Value / energyMassDensity;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="power">a dividend (counter) - a value that is being divided</param>
        /// <param name="massStream">a divisor (denominator) - a value which dividend is divided by</param>
        public static EnergyMassDensity? operator /(Power? power, MassStream massStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (power is null)
                return null;
            return power.Value / massStream;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="power">a dividend (counter) - a value that is being divided</param>
        /// <param name="energyMassDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static MassStream? operator /(Power power, EnergyMassDensity? energyMassDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energyMassDensity is null)
                return null;
            return power / energyMassDensity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="power">a dividend (counter) - a value that is being divided</param>
        /// <param name="massStream">a divisor (denominator) - a value which dividend is divided by</param>
        public static EnergyMassDensity? operator /(Power power, MassStream? massStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (massStream is null)
                return null;
            return power / massStream.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="power">a dividend (counter) - a value that is being divided</param>
        /// <param name="energyMassDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static MassStream? operator /(Power? power, EnergyMassDensity? energyMassDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (power is null || energyMassDensity is null)
                return null;
            return power.Value / energyMassDensity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="power">a dividend (counter) - a value that is being divided</param>
        /// <param name="massStream">a divisor (denominator) - a value which dividend is divided by</param>
        public static EnergyMassDensity? operator /(Power? power, MassStream? massStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (power is null || massStream is null)
                return null;
            return power.Value / massStream.Value;
        }

    }
}
