// ReSharper disable All
// generator: FractionValuesGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(PlanarDensityJsonConverter))]
    public partial struct PlanarDensity : IUnitedValue<PlanarDensityUnit>, IEquatable<PlanarDensity>, IFormattable
    {
        /// <summary>
        /// creates instance of PlanarDensity
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public PlanarDensity(decimal value, PlanarDensityUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public PlanarDensity(decimal value, WeightUnit counterUnit, AreaUnit denominatorUnit)
        {
            Value = value;
            Unit = new PlanarDensityUnit(counterUnit, denominatorUnit);
        }

        public PlanarDensity ConvertTo(PlanarDensityUnit newUnit)
        {
            if (Unit.Equals(newUnit))
                return this;
            var a = new Weight(Value, Unit.CounterUnit);
            var b = new Area(1, Unit.DenominatorUnit);
            a = a.ConvertTo(newUnit.CounterUnit);
            b = b.ConvertTo(newUnit.DenominatorUnit);
            return new PlanarDensity(a.Value / b.Value, newUnit);
        }

        public bool Equals(PlanarDensity other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<PlanarDensityUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<PlanarDensityUnit> unitedValue ? Equals(unitedValue) : false;
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

        public PlanarDensity WithCounterUnit(WeightUnit newCounterUnit)
        {
            // generator : FractionValuesGenerator.Add_WithCounterUnit
            if (Unit.CounterUnit.Equals(newCounterUnit))
                return this;
            var tmp = new Weight(Value, Unit.CounterUnit);
            tmp = tmp.ConvertTo(newCounterUnit);
            var resultUnit = new PlanarDensityUnit(newCounterUnit, Unit.DenominatorUnit);
            return new PlanarDensity(tmp.Value, resultUnit);
        }

        public PlanarDensity WithDenominatorUnit(AreaUnit newDenominatorUnit)
        {
            // generator : FractionValuesGenerator.Add_WithDenominatorUnit
            if (this.Unit.DenominatorUnit == newDenominatorUnit)
                return this;
            var nu = new PlanarDensityUnit(Unit.CounterUnit, newDenominatorUnit);
            return ConvertTo(nu);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(PlanarDensity left, PlanarDensity right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(PlanarDensity left, PlanarDensity right)
        {
            return left.Equals(right);
        }

        public static PlanarDensity Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(PlanarDensity));
            var units = r.UnitName.Split('/');
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid PlanarDensity unit");
            var counterUnit = new WeightUnit(units[0]);
            var denominatorUnit = new AreaUnit(units[1]);
            return new PlanarDensity(r.Value, counterUnit, denominatorUnit);
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public PlanarDensityUnit Unit { get; }

    }
}
