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
    [JsonConverter(typeof(EnergyMassDensityJsonConverter))]
    public partial struct EnergyMassDensity : IUnitedValue<EnergyMassDensityUnit>, IEquatable<EnergyMassDensity>, IFormattable
    {
        /// <summary>
        /// creates instance of EnergyMassDensity
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public EnergyMassDensity(decimal value, EnergyMassDensityUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public EnergyMassDensity(decimal value, EnergyUnit counterUnit, MassUnit denominatorUnit)
        {
            Value = value;
            Unit = new EnergyMassDensityUnit(counterUnit, denominatorUnit);
        }

        public EnergyMassDensity ConvertTo(EnergyMassDensityUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_ConvertTo
            if (Unit.Equals(newUnit))
                return this;
            var a = new Energy(Value, Unit.CounterUnit);
            var b = new Mass(1, Unit.DenominatorUnit);
            a = a.ConvertTo(newUnit.CounterUnit);
            b = b.ConvertTo(newUnit.DenominatorUnit);
            return new EnergyMassDensity(a.Value / b.Value, newUnit);
        }

        public bool Equals(EnergyMassDensity other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<EnergyMassDensityUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<EnergyMassDensityUnit> unitedValue ? Equals(unitedValue) : false;
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

        public EnergyMassDensity Round(int decimalPlaces)
        {
            return new EnergyMassDensity(Math.Round(Value, decimalPlaces), Unit);
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

        public EnergyMassDensity WithCounterUnit(EnergyUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithCounterUnit
            var oldUnit = Unit.CounterUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithCounterUnit(newUnit);
            return new EnergyMassDensity(oldFactor / newFactor * Value, resultUnit);
        }

        public EnergyMassDensity WithDenominatorUnit(MassUnit newUnit)
        {
            // generator : FractionValuesGenerator.Add_WithDenominatorUnit
            var oldUnit = Unit.DenominatorUnit;
            if (oldUnit == newUnit)
                return this;
            var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);
            var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);
            var resultUnit = Unit.WithDenominatorUnit(newUnit);
            return new EnergyMassDensity(newFactor / oldFactor * Value, resultUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(EnergyMassDensity left, EnergyMassDensity right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(EnergyMassDensity left, EnergyMassDensity right)
        {
            return left.Equals(right);
        }

        public static EnergyMassDensity Parse(string value)
        {
            // generator : FractionValuesGenerator.Add_Parse
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(EnergyMassDensity));
            var units = Common.SplitUnitNameBySlash(r.UnitName);
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid EnergyMassDensity unit");
            var counterUnit = new EnergyUnit(units[0]);
            var denominatorUnit = new MassUnit(units[1]);
            return new EnergyMassDensity(r.Value, counterUnit, denominatorUnit);
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public EnergyMassDensityUnit Unit { get; }

    }
}
