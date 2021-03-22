// ReSharper disable All
// generator: FractionValuesGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(DensityJsonConverter))]
    public partial struct Density : IUnitedValue<DensityUnit>, IEquatable<Density>, IFormattable
    {
        /// <summary>
        /// creates instance of Density
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Density(decimal value, DensityUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public Density(decimal value, WeightUnit counterUnit, VolumeUnit denominatorUnit)
        {
            Value = value;
            Unit = new DensityUnit(counterUnit, denominatorUnit);
        }

        public Density ConvertTo(DensityUnit newUnit)
        {
            if (Unit.Equals(newUnit))
                return this;
            var a = new Weight(Value, Unit.CounterUnit);
            var b = new Volume(1, Unit.DenominatorUnit);
            a = a.ConvertTo(newUnit.CounterUnit);
            b = b.ConvertTo(newUnit.DenominatorUnit);
            return new Density(a.Value / b.Value, newUnit);
        }

        public bool Equals(Density other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<DensityUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<DensityUnit> unitedValue ? Equals(unitedValue) : false;
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

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(Density left, Density right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(Density left, Density right)
        {
            return left.Equals(right);
        }

        public static Density Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(Density));
            var units = r.UnitName.Split('/');
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid Density unit");
            var counterUnit = new WeightUnit(units[0]);
            var denominatorUnit = new VolumeUnit(units[1]);
            return new Density(r.Value, counterUnit, denominatorUnit);
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public DensityUnit Unit { get; }

    }
}