// ReSharper disable All
// generator: FractionValuesGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(SpecificHeatCapacityJsonConverter))]
    public partial struct SpecificHeatCapacity : IUnitedValue<SpecificHeatCapacityUnit>, IEquatable<SpecificHeatCapacity>, IFormattable
    {
        /// <summary>
        /// creates instance of SpecificHeatCapacity
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public SpecificHeatCapacity(decimal value, SpecificHeatCapacityUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public SpecificHeatCapacity(decimal value, EnergyUnit counterUnit, MassDetlaKelvinUnit denominatorUnit)
        {
            Value = value;
            Unit = new SpecificHeatCapacityUnit(counterUnit, denominatorUnit);
        }

        public SpecificHeatCapacity ConvertTo(SpecificHeatCapacityUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var a = new Energy(Value, Unit.CounterUnit);
            var b = new MassDetlaKelvin(1, Unit.DenominatorUnit);
            a = a.ConvertTo(newUnit.CounterUnit);
            b = b.ConvertTo(newUnit.DenominatorUnit);
            return new SpecificHeatCapacity(a.Value / b.Value, newUnit);
        }

        public bool Equals(SpecificHeatCapacity other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<SpecificHeatCapacityUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<SpecificHeatCapacityUnit> unitedValue ? Equals(unitedValue) : false;
        }

        public decimal GetBaseUnitValue()
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Unit.GetHashCode();
            }
        }

        public SpecificHeatCapacity Round(int decimalPlaces)
        {
            return new SpecificHeatCapacity(Math.Round(Value, decimalPlaces), Unit);
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

        public SpecificHeatCapacity WithCounterUnit(EnergyUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithCounterUnit
            var oldUnit = Unit.CounterUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithCounterUnit(newUnit);
            return new SpecificHeatCapacity(oldFactor / newFactor * Value, resultUnit);
        }

        public SpecificHeatCapacity WithDenominatorUnit(MassDetlaKelvinUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithDenominatorUnit
            var oldUnit = Unit.DenominatorUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithDenominatorUnit(newUnit);
            return new SpecificHeatCapacity(newFactor / oldFactor * Value, resultUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(SpecificHeatCapacity left, SpecificHeatCapacity right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(SpecificHeatCapacity left, SpecificHeatCapacity right)
        {
            return left.Equals(right);
        }

        public static SpecificHeatCapacity Parse(string value)
        {
            // generator : FractionValuesGenerator.Add_Parse
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(SpecificHeatCapacity));
            var units = Common.SplitUnitNameBySlash(r.UnitName);
            if (units.Length != 3)
                throw new Exception($"{r.UnitName} is not valid SpecificHeatCapacity unit");
            var counterUnit = new EnergyUnit(units[0]);
            var denominatorUnit = new MassDetlaKelvinUnit(new MassUnit(units[1]), new KelvinTemperatureUnit(units[2]));
            return new SpecificHeatCapacity(r.Value, counterUnit, denominatorUnit);
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public SpecificHeatCapacityUnit Unit { get; }

    }
}