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
    [JsonConverter(typeof(VelocityJsonConverter))]
    public partial struct Velocity : IUnitedValue<VelocityUnit>, IEquatable<Velocity>, IFormattable
    {
        /// <summary>
        /// creates instance of Velocity
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Velocity(decimal value, VelocityUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public Velocity(decimal value, LengthUnit counterUnit, TimeUnit denominatorUnit)
        {
            Value = value;
            Unit = new VelocityUnit(counterUnit, denominatorUnit);
        }

        public Velocity ConvertTo(VelocityUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var a = new Length(Value, Unit.CounterUnit);
            var b = new Time(1, Unit.DenominatorUnit);
            a = a.ConvertTo(newUnit.CounterUnit);
            b = b.ConvertTo(newUnit.DenominatorUnit);
            return new Velocity(a.Value / b.Value, newUnit);
        }

        public bool Equals(Velocity other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<VelocityUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<VelocityUnit> unitedValue ? Equals(unitedValue) : false;
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

        public Velocity Round(int decimalPlaces)
        {
            return new Velocity(Math.Round(Value, decimalPlaces), Unit);
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

        public Velocity WithCounterUnit(LengthUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithCounterUnit
            var oldUnit = Unit.CounterUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithCounterUnit(newUnit);
            return new Velocity(oldFactor / newFactor * Value, resultUnit);
        }

        public Velocity WithDenominatorUnit(TimeUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithDenominatorUnit
            var oldUnit = Unit.DenominatorUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithDenominatorUnit(newUnit);
            return new Velocity(newFactor / oldFactor * Value, resultUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(Velocity left, Velocity right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(Velocity left, Velocity right)
        {
            return left.Equals(right);
        }

        public static Velocity Parse(string value)
        {
            // generator : FractionValuesGenerator.Add_Parse
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(Velocity));
            var units = Common.SplitUnitNameBySlash(r.UnitName);
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid Velocity unit");
            var counterUnit = new LengthUnit(units[0]);
            var denominatorUnit = new TimeUnit(units[1]);
            return new Velocity(r.Value, counterUnit, denominatorUnit);
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public VelocityUnit Unit { get; }

    }
}
