// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct Time
    {
        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="time">left factor (multiplicand)</param>
        /// <param name="power">rigth factor (multiplier)</param>
        public static Energy operator *(Time time, Power power)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // Fill method Definition
            // .Is<Time, Power, Energy>("*")
            throw new NotImplementedException();
            // scenario F3
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="power">left factor (multiplicand)</param>
        /// <param name="time">rigth factor (multiplier)</param>
        public static Energy operator *(Power power, Time time)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // Fill method Definition
            // .Is<Power, Time, Energy>("*")
            throw new NotImplementedException();
            // scenario F3
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="time">left factor (multiplicand)</param>
        /// <param name="power">rigth factor (multiplier)</param>
        public static Energy? operator *(Time? time, Power power)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (time is null)
                return null;
            return time.Value * power;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="power">left factor (multiplicand)</param>
        /// <param name="time">rigth factor (multiplier)</param>
        public static Energy? operator *(Power? power, Time time)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (power is null)
                return null;
            return power.Value * time;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="time">left factor (multiplicand)</param>
        /// <param name="power">rigth factor (multiplier)</param>
        public static Energy? operator *(Time time, Power? power)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (power is null)
                return null;
            return time * power.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="power">left factor (multiplicand)</param>
        /// <param name="time">rigth factor (multiplier)</param>
        public static Energy? operator *(Power power, Time? time)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (time is null)
                return null;
            return power * time.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="time">left factor (multiplicand)</param>
        /// <param name="power">rigth factor (multiplier)</param>
        public static Energy? operator *(Time? time, Power? power)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (time is null || power is null)
                return null;
            return time.Value * power.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="power">left factor (multiplicand)</param>
        /// <param name="time">rigth factor (multiplier)</param>
        public static Energy? operator *(Power? power, Time? time)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (power is null || time is null)
                return null;
            return power.Value * time.Value;
        }

    }
}
