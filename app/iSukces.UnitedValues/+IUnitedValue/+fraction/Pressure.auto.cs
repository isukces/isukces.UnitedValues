// ReSharper disable All
// generator: FractionValuesGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    [Serializable]
    [JsonConverter(typeof(PressureJsonConverter))]
    public partial struct Pressure : IUnitedValue<PressureUnit>, IEquatable<Pressure>, IFormattable
    {
        /// <summary>
        /// creates instance of Pressure
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public Pressure(decimal value, PressureUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public Pressure(decimal value, ForceUnit counterUnit, AreaUnit denominatorUnit)
        {
            Value = value;
            Unit = new PressureUnit(counterUnit, denominatorUnit);
        }

        public Pressure ConvertTo(PressureUnit newUnit)
        {
            if (Unit.Equals(newUnit))
                return this;
            var a = new Force(Value, Unit.CounterUnit);
            var b = new Area(1, Unit.DenominatorUnit);
            a = a.ConvertTo(newUnit.CounterUnit);
            b = b.ConvertTo(newUnit.DenominatorUnit);
            return new Pressure(a.Value / b.Value, newUnit);
        }

        public bool Equals(Pressure other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<PressureUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<PressureUnit> unitedValue ? Equals(unitedValue) : false;
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

        public Pressure WithCounterUnit(ForceUnit newCounterUnit)
        {
            // generator : FractionValuesGenerator.Add_WithCounterUnit
            if (Unit.CounterUnit.Equals(newCounterUnit))
                return this;
            var tmp = new Force(Value, Unit.CounterUnit);
            tmp = tmp.ConvertTo(newCounterUnit);
            var resultUnit = new PressureUnit(newCounterUnit, Unit.DenominatorUnit);
            return new Pressure(tmp.Value, resultUnit);
        }

        public Pressure WithDenominatorUnit(AreaUnit newDenominatorUnit)
        {
            // generator : FractionValuesGenerator.Add_WithDenominatorUnit
            if (this.Unit.DenominatorUnit == newDenominatorUnit)
                return this;
            var nu = new PressureUnit(Unit.CounterUnit, newDenominatorUnit);
            return ConvertTo(nu);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(Pressure left, Pressure right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(Pressure left, Pressure right)
        {
            return left.Equals(right);
        }

        public static Pressure Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(Pressure));
            var units = r.UnitName.Split('/');
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid Pressure unit");
            var counterUnit = new ForceUnit(units[0]);
            var denominatorUnit = new AreaUnit(units[1]);
            return new Pressure(r.Value, counterUnit, denominatorUnit);
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public PressureUnit Unit { get; }

    }
}
