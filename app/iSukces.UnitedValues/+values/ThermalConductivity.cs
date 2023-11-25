using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial struct ThermalConductivity : IUnitedValue<ThermalConductivityUnit>
    {
        
        public static ThermalConductivity FromWattPerMeterKelvin(decimal value)
        {
            return new ThermalConductivity(value, BaseUnit);
        }

        
        public static ThermalConductivityUnit BaseUnit => ThermalConductivityUnits.WattPerMeterKelvin.Unit;
    }
}

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: ThermalValuesGenerator

namespace iSukces.UnitedValues
{
    public partial struct ThermalConductivity : IUnitedValue<ThermalConductivityUnit>
    {
        /// <summary>
        /// creates instance of ThermalConductivity
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public ThermalConductivity(decimal value, ThermalConductivityUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public bool Equals(ThermalConductivity other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<ThermalConductivityUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<ThermalConductivityUnit> unitedValue ? Equals(unitedValue) : false;
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
        /// implements - operator
        /// </summary>
        /// <param name="value"></param>
        public static ThermalConductivity operator -(ThermalConductivity value)
        {
            return new ThermalConductivity(-value.Value, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static ThermalResistance operator /(decimal number, ThermalConductivity value)
        {
            return new ThermalResistance(number / value.Value, value.Unit.GetThermalResistanceUnit());
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public ThermalConductivityUnit Unit { get; }

    }
}
