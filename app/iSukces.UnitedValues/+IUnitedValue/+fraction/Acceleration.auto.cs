// ReSharper disable All
// generator: FractionValuesGenerator
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(AccelerationJsonConverter))]
    public partial struct Acceleration : IUnitedValue<AccelerationUnit>, IEquatable<Acceleration>, IFormattable
    {
        /// <summary>
        /// creates instance of Acceleration
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Acceleration(decimal value, AccelerationUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public Acceleration(decimal value, LengthUnit counterUnit, SquareTimeUnit denominatorUnit)
        {
            Value = value;
            Unit = new AccelerationUnit(counterUnit, denominatorUnit);
        }

        public Acceleration ConvertTo(AccelerationUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var a = new Length(Value, Unit.CounterUnit);
            var b = new SquareTime(1, Unit.DenominatorUnit);
            a = a.ConvertTo(newUnit.CounterUnit);
            b = b.ConvertTo(newUnit.DenominatorUnit);
            return new Acceleration(a.Value / b.Value, newUnit);
        }

        public bool Equals(Acceleration other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<AccelerationUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<AccelerationUnit> unitedValue ? Equals(unitedValue) : false;
        }

        public decimal GetBaseUnitValue()
        {
            // generator : FractionValuesGenerator.Add_GetBaseUnitValue
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Unit?.GetHashCode() ?? 0;
            }
        }

        public Acceleration Round(int decimalPlaces)
        {
            return new Acceleration(Math.Round(Value, decimalPlaces), Unit);
        }

        /// <summary>
        /// Returns unit name
        /// </summary>
        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName;
        }

        /// <summary>
        /// Returns unit name
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        public string ToString(string format, IFormatProvider provider = null)
        {
            return this.ToStringFormat(format, provider);
        }

        public Acceleration WithCounterUnit(LengthUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithCounterUnit
            var oldUnit = Unit.CounterUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithCounterUnit(newUnit);
            return new Acceleration(oldFactor / newFactor * Value, resultUnit);
        }

        public Acceleration WithDenominatorUnit(SquareTimeUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithDenominatorUnit
            var oldUnit = Unit.DenominatorUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithDenominatorUnit(newUnit);
            return new Acceleration(newFactor / oldFactor * Value, resultUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(Acceleration left, Acceleration right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(Acceleration left, Acceleration right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// creates acceleration from value in /
        /// </summary>
        /// <param name="value">Acceleration value in /</param>
        public static Acceleration FromMetersPerSquareSeconds(decimal value)
        {
            return new Acceleration(value, AccelerationUnits.MetersPerSquareSeconds);
        }

        /// <summary>
        /// creates acceleration from value in /
        /// </summary>
        /// <param name="value">Acceleration value in /</param>
        public static Acceleration FromMetersPerSquareSeconds(double value)
        {
            return new Acceleration((decimal)value, AccelerationUnits.MetersPerSquareSeconds);
        }

        /// <summary>
        /// creates acceleration from value in /
        /// </summary>
        /// <param name="value">Acceleration value in /</param>
        public static Acceleration FromMetersPerSquareSeconds(int value)
        {
            return new Acceleration(value, AccelerationUnits.MetersPerSquareSeconds);
        }

        /// <summary>
        /// creates acceleration from value in /
        /// </summary>
        /// <param name="value">Acceleration value in /</param>
        public static Acceleration FromMetersPerSquareSeconds(long value)
        {
            return new Acceleration(value, AccelerationUnits.MetersPerSquareSeconds);
        }

        public static Acceleration Parse(string value)
        {
            // generator : FractionValuesGenerator.Add_Parse
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(Acceleration));
            var units = Common.SplitUnitNameBySlash(r.UnitName);
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid Acceleration unit");
            var counterUnit = new LengthUnit(units[0]);
            var denominatorUnit = new SquareTimeUnit(units[1]);
            return new Acceleration(r.Value, counterUnit, denominatorUnit);
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public AccelerationUnit Unit { get; }

    }
}
