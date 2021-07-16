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
            // .Is<Time, Power, Energy>("*")
            // hint location HandleCreateOperatorCode, line 42
            var timeValue = time.GetBaseUnitValue();
            var powerValue = power.GetBaseUnitValue();
            var basicEnergy = timeValue * powerValue;
            var value = basicEnergy;
            return new Energy(value, EnergyUnits.Joule);
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
            // .Is<Power, Time, Energy>("*")
            // hint location HandleCreateOperatorCode, line 51
            var x = 4;
            var powerValue = power.GetBaseUnitValue();
            var timeValue = time.GetBaseUnitValue();
            var basicEnergy = powerValue * timeValue;
            var value = basicEnergy;
            return new Energy(value, EnergyUnits.Joule);
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

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="time">left factor (multiplicand)</param>
        /// <param name="velocity">rigth factor (multiplier)</param>
        public static Length operator *(Time time, Velocity velocity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario B
            var unit = new VelocityUnit(velocity.Unit.CounterUnit, time.Unit);
            var velocityConverted    = velocity.WithDenominatorUnit(time.Unit);
            var value = time.Value * velocityConverted.Value;
            return new Length(value, velocity.Unit.CounterUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="velocity">left factor (multiplicand)</param>
        /// <param name="time">rigth factor (multiplier)</param>
        public static Length operator *(Velocity velocity, Time time)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Length operator *(Velocity velocity, Time time)
            // scenario with hint
            // .Is<Velocity, Time, Length>("*")
            // hint location GetBasicOperatorHints, line 31
            var velocityUnit = velocity.Unit;
            var timeConverted = time.ConvertTo(velocityUnit.DenominatorUnit);
            var value = velocity.Value * timeConverted.Value;
            return new Length(value, velocityUnit.CounterUnit);
            // scenario D1
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="time">left factor (multiplicand)</param>
        /// <param name="velocity">rigth factor (multiplier)</param>
        public static Length? operator *(Time? time, Velocity velocity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (time is null)
                return null;
            return time.Value * velocity;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="velocity">left factor (multiplicand)</param>
        /// <param name="time">rigth factor (multiplier)</param>
        public static Length? operator *(Velocity? velocity, Time time)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (velocity is null)
                return null;
            return velocity.Value * time;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="time">left factor (multiplicand)</param>
        /// <param name="velocity">rigth factor (multiplier)</param>
        public static Length? operator *(Time time, Velocity? velocity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (velocity is null)
                return null;
            return time * velocity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="velocity">left factor (multiplicand)</param>
        /// <param name="time">rigth factor (multiplier)</param>
        public static Length? operator *(Velocity velocity, Time? time)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (time is null)
                return null;
            return velocity * time.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="time">left factor (multiplicand)</param>
        /// <param name="velocity">rigth factor (multiplier)</param>
        public static Length? operator *(Time? time, Velocity? velocity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (time is null || velocity is null)
                return null;
            return time.Value * velocity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="velocity">left factor (multiplicand)</param>
        /// <param name="time">rigth factor (multiplier)</param>
        public static Length? operator *(Velocity? velocity, Time? time)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (velocity is null || time is null)
                return null;
            return velocity.Value * time.Value;
        }

    }
}
