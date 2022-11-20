using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial struct ThermalResistance : IUnitedValue<ThermalResistanceUnit>, IEquatable<ThermalResistance>
    {
        public static ThermalResistance FromMeterKelvinPerWatt(decimal value)
        {
            return new ThermalResistance(value, BaseUnit);
        }

        public static ThermalResistanceUnit BaseUnit => ThermalResistanceUnits.MeterKelvinPerWatt.Unit;

        public static bool operator ==(ThermalResistance left, ThermalResistance right) { return left.Equals(right); }
        public static bool operator !=(ThermalResistance left, ThermalResistance right) { return !left.Equals(right); }

        public static ThermalResistance operator +(ThermalResistance left, ThermalResistance right)
        {
            var rightConverted = right.ConvertTo(left.Unit);
            return new ThermalResistance(left.Value + rightConverted.Value, left.Unit);
        }

        public static ThermalResistance operator -(ThermalResistance left, ThermalResistance right)
        {
            var rightConverted = right.ConvertTo(left.Unit);
            return new ThermalResistance(left.Value - rightConverted.Value, left.Unit);
        }

        public ThermalResistance ConvertTo(ThermalResistanceUnit newUnit)
        {
            if (newUnit.Equals(Unit))
                return this;
            var value = Value;
            if (!Unit.LengthUnit.Equals(newUnit.LengthUnit))
            {
                var l = new Length(1, Unit.LengthUnit).ConvertTo(newUnit.LengthUnit).Value;
                value *= l;
            }
            if (!Unit.PowerUnit.Equals(newUnit.PowerUnit))
            {
                var l = new Power(1, Unit.PowerUnit).ConvertTo(newUnit.PowerUnit).Value;
                value /= l;
            }
            
            return new ThermalResistance(value, newUnit);
        }
    }
}

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: ThermalValuesGenerator

namespace iSukces.UnitedValues
{
    public partial struct ThermalResistance : IUnitedValue<ThermalResistanceUnit>
    {
        /// <summary>
        /// creates instance of ThermalResistance
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public ThermalResistance(decimal value, ThermalResistanceUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public bool Equals(ThermalResistance other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<ThermalResistanceUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<ThermalResistanceUnit> unitedValue ? Equals(unitedValue) : false;
        }

        public decimal GetBaseUnitValue()
        {
            // generator : BasicUnitValuesGenerator.Add_GetBaseUnitValue
            if (Unit.Equals(BaseUnit))
                return Value;
            var factor = GlobalUnitRegistry.Factors.Get(Unit);
            if (!(factor is null))
                return Value * factor.Value;
            throw new Exception("Unable to find multiplication for unit " + Unit);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Unit?.GetHashCode() ?? 0;
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
        /// implements - operator
        /// </summary>
        /// <param name="value"></param>
        public static ThermalResistance operator -(ThermalResistance value)
        {
            return new ThermalResistance(-value.Value, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static ThermalConductivity operator /(decimal number, ThermalResistance value)
        {
            return new ThermalConductivity(number / value.Value, value.Unit.GetThermalConductivityUnit());
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public ThermalResistanceUnit Unit { get; }

    }
}