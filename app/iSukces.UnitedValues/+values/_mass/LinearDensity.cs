using System;
using System.Globalization;
using Newtonsoft.Json;

// -----===== autogenerated code =====-----
// ReSharper disable All
// generator: DerivedUnitGenerator, FractionValuesGenerator, UnitJsonConverterGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator, MultiplyAlgebraGenerator

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

        public LinearDensity FromKgPerMeter(decimal value)
        {
            return new LinearDensity(value, LinearDensityUnits.KgPerMeter.Unit);
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
                return (Value.GetHashCode() * 397) ^ Unit.GetHashCode();
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
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static PlanarDensity operator /(LinearDensity linearDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // PlanarDensity operator /(LinearDensity linearDensity, Length length)
            // scenario with hint
            // .Is<LinearDensity, Length, PlanarDensity>("/")
            // hint location GetBasicOperatorHints, line 31
            var linearDensityUnit = linearDensity.Unit;
            var tmp1 = linearDensityUnit.DenominatorUnit;
            var resultUnit = new PlanarDensityUnit(linearDensityUnit.CounterUnit, linearDensityUnit.DenominatorUnit.GetAreaUnit());
            var lengthConverted = length.ConvertTo(tmp1);
            var value = linearDensity.Value / lengthConverted.Value;
            return new PlanarDensity(value, resultUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="planarDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length operator /(LinearDensity linearDensity, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<LinearDensity, PlanarDensity, Length>("/")
            // hint location GetBasicOperatorHints, line 31
            var linearDensityUnit = linearDensity.Unit;
            var tmp1 = linearDensityUnit.DenominatorUnit;
            var targetRightUnit = new PlanarDensityUnit(linearDensityUnit.CounterUnit, tmp1.GetAreaUnit());
            var planarDensityConverted = planarDensity.ConvertTo(targetRightUnit);
            var value = linearDensity.Value / planarDensityConverted.Value;
            return new Length(value, tmp1);
            // scenario F1
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static PlanarDensity? operator /(LinearDensity? linearDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null)
                return null;
            return linearDensity.Value / length;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="planarDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(LinearDensity? linearDensity, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null)
                return null;
            return linearDensity.Value / planarDensity;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static PlanarDensity? operator /(LinearDensity linearDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return linearDensity / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="planarDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(LinearDensity linearDensity, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null)
                return null;
            return linearDensity / planarDensity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static PlanarDensity? operator /(LinearDensity? linearDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null || length is null)
                return null;
            return linearDensity.Value / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="planarDensity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(LinearDensity? linearDensity, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null || planarDensity is null)
                return null;
            return linearDensity.Value / planarDensity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density operator /(LinearDensity linearDensity, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Density operator /(LinearDensity linearDensity, Area area)
            // scenario with hint
            // .Is<LinearDensity, Area, Density>("/")
            // hint location GetBasicOperatorHints, line 31
            var linearDensityUnit = linearDensity.Unit;
            var tmp1 = linearDensityUnit.DenominatorUnit;
            var resultUnit = new DensityUnit(linearDensityUnit.CounterUnit, tmp1.GetVolumeUnit());
            var areaConverted = area.ConvertTo(tmp1.GetAreaUnit());
            var value = linearDensity.Value / areaConverted.Value;
            return new Density(value, resultUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area operator /(LinearDensity linearDensity, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<LinearDensity, Density, Area>("/")
            // hint location GetBasicOperatorHints, line 31
            var linearDensityUnit = linearDensity.Unit;
            var tmp1 = linearDensityUnit.DenominatorUnit;
            var targetRightUnit = new DensityUnit(linearDensityUnit.CounterUnit, tmp1.GetVolumeUnit());
            var densityConverted = density.ConvertTo(targetRightUnit);
            var value = linearDensity.Value / densityConverted.Value;
            return new Area(value, tmp1.GetAreaUnit());
            // scenario F1
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(LinearDensity? linearDensity, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null)
                return null;
            return linearDensity.Value / area;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(LinearDensity? linearDensity, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null)
                return null;
            return linearDensity.Value / density;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(LinearDensity linearDensity, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return linearDensity / area.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(LinearDensity linearDensity, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return linearDensity / density.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(LinearDensity? linearDensity, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null || area is null)
                return null;
            return linearDensity.Value / area.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="linearDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(LinearDensity? linearDensity, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null || density is null)
                return null;
            return linearDensity.Value / density.Value;
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
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(LinearDensity));
            var units = Common.SplitUnitNameBySlash(r.UnitName);
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid LinearDensity unit");
            var counterUnit = new MassUnit(units[0]);
            var denominatorUnit = new LengthUnit(units[1]);
            return new LinearDensity(r.Value, counterUnit, denominatorUnit);
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

    public partial class LinearDensityJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(LinearDensityUnit);
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
                if (objectType == typeof(LinearDensity))
                    return LinearDensity.Parse((string)reader.Value);
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
