// ReSharper disable All
// generator: InversedValuesGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial struct InversedDeltaKelvinTemperature : IUnitedValue<InversedKelvinTemperatureUnit>
    {
        /// <summary>
        /// creates instance of InversedDeltaKelvinTemperature
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="unit">unit</param>
        public InversedDeltaKelvinTemperature(decimal value, InversedKelvinTemperatureUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public bool Equals(InversedDeltaKelvinTemperature other)
        {
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public bool Equals(IUnitedValue<InversedKelvinTemperatureUnit> other)
        {
            if (other is null)
                return false;
            return Value == other.Value && !(Unit is null) && Unit.Equals(other.Unit);
        }

        public override bool Equals(object other)
        {
            return other is IUnitedValue<InversedKelvinTemperatureUnit> unitedValue ? Equals(unitedValue) : false;
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
        public static InversedDeltaKelvinTemperature operator -(InversedDeltaKelvinTemperature value)
        {
            return new InversedDeltaKelvinTemperature(-value.Value, value.Unit);
        }

        /// <summary>
        /// implements / operator
        /// </summary>
        /// <param name="number"></param>
        /// <param name="value"></param>
        public static DeltaKelvinTemperature operator /(decimal number, InversedDeltaKelvinTemperature value)
        {
            return new DeltaKelvinTemperature(number / value.Value, value.Unit.GetKelvinTemperatureUnit());
        }

        /// <summary>
        /// value
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// unit
        /// </summary>
        public InversedKelvinTemperatureUnit Unit { get; }

        public static readonly InversedKelvinTemperatureUnit BaseUnit = InversedKelvinTemperatureUnits.DegreeInversedKelvinTemperatureUnit;

    }
}
