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
    [JsonConverter(typeof(LinearDensityJsonConverter))]
    public partial struct LinearDensity : IUnitedValue<LinearDensityUnit>, IEquatable<LinearDensity>, IFormattable
    {
        /// <summary>
        /// creates instance of LinearDensity
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public LinearDensity(decimal value, LinearDensityUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public LinearDensity(decimal value, MassUnit counterUnit, LengthUnit denominatorUnit)
        {
            Value = value;
            Unit = new LinearDensityUnit(counterUnit, denominatorUnit);
        }

        public LinearDensity ConvertTo(LinearDensityUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var a = new Mass(Value, Unit.CounterUnit);
            var b = new Length(1, Unit.DenominatorUnit);
            a = a.ConvertTo(newUnit.CounterUnit);
            b = b.ConvertTo(newUnit.DenominatorUnit);
            return new LinearDensity(a.Value / b.Value, newUnit);
        }

        public bool Equals(LinearDensity other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<LinearDensityUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<LinearDensityUnit> unitedValue ? Equals(unitedValue) : false;
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

        public LinearDensity Round(int decimalPlaces)
        {
            return new LinearDensity(Math.Round(Value, decimalPlaces), Unit);
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

        public LinearDensity WithCounterUnit(MassUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithCounterUnit
            var oldUnit = Unit.CounterUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithCounterUnit(newUnit);
            return new LinearDensity(oldFactor / newFactor * Value, resultUnit);
        }

        public LinearDensity WithDenominatorUnit(LengthUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithDenominatorUnit
            var oldUnit = Unit.DenominatorUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithDenominatorUnit(newUnit);
            return new LinearDensity(newFactor / oldFactor * Value, resultUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(LinearDensity left, LinearDensity right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(LinearDensity left, LinearDensity right)
        {
            return left.Equals(right);
        }

        public static LinearDensity Parse(string value)
        {
            // generator : FractionValuesGenerator.Add_Parse
            throw new NotImplementedException("Not implemented yet");
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public LinearDensityUnit Unit { get; }

    }
}
