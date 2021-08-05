using System;
using System.Globalization;
using Newtonsoft.Json;
namespace iSukces.UnitedValues
{
    public static class EnergyMassDensityUnits
    {
        public static readonly EnergyMassDensityUnit KiloWattHourPerTone 
            = new EnergyMassDensityUnit(EnergyUnits.KiloWattHour, MassUnits.Tone);
    }
}

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: FractionValuesGenerator, UnitJsonConverterGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator

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
            // generator : BasicUnitValuesGenerator.Add_GetBaseUnitValue
            var factor1 = GlobalUnitRegistry.Factors.Get(Unit.CounterUnit);
            var factor2 = GlobalUnitRegistry.Factors.Get(Unit.DenominatorUnit);
            if ((factor1.HasValue && factor2.HasValue))
                return Value * factor1.Value / factor2.Value;
            throw new Exception("Unable to find multiplication for unit " + Unit);
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
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="deltaKelvinTemperature">a divisor (denominator) - a value which dividend is divided by</param>
        public static SpecificHeatCapacity operator /(EnergyMassDensity energyMassDensity, DeltaKelvinTemperature deltaKelvinTemperature)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // SpecificHeatCapacity operator /(EnergyMassDensity energyMassDensity, DeltaKelvinTemperature deltaKelvinTemperature)
            // scenario with hint
            // .Is<EnergyMassDensity, DeltaKelvinTemperature, SpecificHeatCapacity>("/")
            // hint location Add_EnergyMassDensity_DeltaKelvinTemperature_SpecificHeatCapacity, line 16
            var energyMassDensityUnit = energyMassDensity.Unit;
            var resultUnit = new SpecificHeatCapacityUnit(energyMassDensityUnit.CounterUnit, energyMassDensityUnit.DenominatorUnit, deltaKelvinTemperature.Unit);
            var value = energyMassDensity.Value / deltaKelvinTemperature.Value;
            return new SpecificHeatCapacity(value, resultUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="specificHeatCapacity">a divisor (denominator) - a value which dividend is divided by</param>
        public static DeltaKelvinTemperature operator /(EnergyMassDensity energyMassDensity, SpecificHeatCapacity specificHeatCapacity)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<EnergyMassDensity, SpecificHeatCapacity, DeltaKelvinTemperature>("/")
            // hint location Add_EnergyMassDensity_DeltaKelvinTemperature_SpecificHeatCapacity, line 16
            var energyMassDensityUnit = energyMassDensity.Unit;
            var specificHeatCapacityUnit = specificHeatCapacity.Unit;
            var tmp1 = specificHeatCapacityUnit.DenominatorUnit;
            var targetRightUnit = new SpecificHeatCapacityUnit(energyMassDensityUnit.CounterUnit, energyMassDensityUnit.DenominatorUnit, tmp1);
            var specificHeatCapacityConverted = specificHeatCapacity.ConvertTo(targetRightUnit);
            var value = energyMassDensity.Value / specificHeatCapacityConverted.Value;
            return new DeltaKelvinTemperature(value, tmp1);
            // scenario F1
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="deltaKelvinTemperature">a divisor (denominator) - a value which dividend is divided by</param>
        public static SpecificHeatCapacity? operator /(EnergyMassDensity? energyMassDensity, DeltaKelvinTemperature deltaKelvinTemperature)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energyMassDensity is null)
                return null;
            return energyMassDensity.Value / deltaKelvinTemperature;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="specificHeatCapacity">a divisor (denominator) - a value which dividend is divided by</param>
        public static DeltaKelvinTemperature? operator /(EnergyMassDensity? energyMassDensity, SpecificHeatCapacity specificHeatCapacity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energyMassDensity is null)
                return null;
            return energyMassDensity.Value / specificHeatCapacity;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="deltaKelvinTemperature">a divisor (denominator) - a value which dividend is divided by</param>
        public static SpecificHeatCapacity? operator /(EnergyMassDensity energyMassDensity, DeltaKelvinTemperature? deltaKelvinTemperature)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (deltaKelvinTemperature is null)
                return null;
            return energyMassDensity / deltaKelvinTemperature.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="specificHeatCapacity">a divisor (denominator) - a value which dividend is divided by</param>
        public static DeltaKelvinTemperature? operator /(EnergyMassDensity energyMassDensity, SpecificHeatCapacity? specificHeatCapacity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (specificHeatCapacity is null)
                return null;
            return energyMassDensity / specificHeatCapacity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="deltaKelvinTemperature">a divisor (denominator) - a value which dividend is divided by</param>
        public static SpecificHeatCapacity? operator /(EnergyMassDensity? energyMassDensity, DeltaKelvinTemperature? deltaKelvinTemperature)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energyMassDensity is null || deltaKelvinTemperature is null)
                return null;
            return energyMassDensity.Value / deltaKelvinTemperature.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="specificHeatCapacity">a divisor (denominator) - a value which dividend is divided by</param>
        public static DeltaKelvinTemperature? operator /(EnergyMassDensity? energyMassDensity, SpecificHeatCapacity? specificHeatCapacity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energyMassDensity is null || specificHeatCapacity is null)
                return null;
            return energyMassDensity.Value / specificHeatCapacity.Value;
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

    public partial class EnergyMassDensityJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EnergyMassDensityUnit);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The JsonReader to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.ValueType == typeof(string))
            {
                if (objectType == typeof(EnergyMassDensity))
                    return EnergyMassDensity.Parse((string)reader.Value);
            }
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is null)
                writer.WriteNull();
            else
                writer.WriteValue(value.ToString());
        }

    }
}
