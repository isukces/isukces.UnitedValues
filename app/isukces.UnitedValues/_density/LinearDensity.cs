using System;
using System.Globalization;
using Newtonsoft.Json;

namespace isukces.UnitedValues
{
    [JsonConverter(typeof(DensityJsonConverter))]
    public partial struct LinearDensity : IUnitedValue<LinearDensityUnit>, IEquatable<LinearDensity>
    {
        public LinearDensity(decimal value, LinearDensityUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public LinearDensity(decimal value, WeightUnit counterUnit, LengthUnit denominatorUnit)
        {
            Value = value;
            Unit = new LinearDensityUnit(counterUnit, denominatorUnit);
        }

        public static bool operator ==(LinearDensity left, LinearDensity right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LinearDensity left, LinearDensity right)
        {
            return !left.Equals(right);
        }

        public static LinearDensity Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(Density));
            var units = r.UnitName.Split('/');
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid density unit");
            var counterUnit = new WeightUnit(units[0].Trim());
            var denominatorUnit = new LengthUnit(units[1].Trim());
            return new LinearDensity(r.Value, counterUnit, denominatorUnit);
        }


        public LinearDensity ConvertTo(LinearDensityUnit newUnit)
        {
            if (Unit.Equals(newUnit))
                return this;
            var a = new Weight(Value, Unit.CounterUnit);
            var b = new Length(1, Unit.DenominatorUnit);
            a = a.ConvertTo(newUnit.CounterUnit);
            b = b.ConvertTo(newUnit.DenominatorUnit);
            return new LinearDensity(a.Value / b.Value, newUnit);
        }

        public bool Equals(LinearDensity other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LinearDensity && Equals((LinearDensity)obj);
        }

        public bool Equals(IUnitedValue<LinearDensityUnit> other)
        {
            throw new NotImplementedException();
        }

        public decimal GetBaseUnitValue()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Unit.GetHashCode();
            }
        }

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName;

        public decimal Value { get; }

        public LinearDensityUnit Unit { get; }
    }

    public struct LinearDensityUnit : IUnit, IEquatable<LinearDensityUnit>
    {
        public LinearDensityUnit(WeightUnit counterUnit, LengthUnit denominatorUnit)
        {
            CounterUnit = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public static bool operator ==(LinearDensityUnit left, LinearDensityUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LinearDensityUnit left, LinearDensityUnit right)
        {
            return !left.Equals(right);
        }

        public bool Equals(LinearDensityUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LinearDensityUnit && Equals((LinearDensityUnit)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (CounterUnit.GetHashCode() * 397) ^ DenominatorUnit.GetHashCode();
            }
        }

        public override string ToString() => UnitName;

        public string UnitName => CounterUnit.UnitName + "/" + DenominatorUnit.UnitName;
        public WeightUnit CounterUnit { get; }
        public LengthUnit DenominatorUnit { get; }
    }
}