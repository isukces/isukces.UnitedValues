using System;
using System.Globalization;
using Newtonsoft.Json;

namespace iSukces.UnitedValues
{
    [JsonConverter(typeof(DensityJsonConverter))]
    [Serializable]
    public partial struct Density : IUnitedValue<DensityUnit>, IEquatable<Density>, IFormattable
    {
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

        public static bool operator ==(Density left, Density right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Density left, Density right)
        {
            return !left.Equals(right);
        }


        public static Weight operator *(Density d, Volume v)
        {
            v = v.ConvertTo(d.Unit.DenominatorUnit);
            return new Weight(d.Value * v.Value, d.Unit.CounterUnit);
        }

        public static Weight operator *(Volume v, Density d)
        {
            v = v.ConvertTo(d.Unit.DenominatorUnit);
            return new Weight(d.Value * v.Value, d.Unit.CounterUnit);
        }

        public static Density Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(Density));
            var units = r.UnitName.Split('/');
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid density unit");
            var counterUnit = new WeightUnit(units[0].Trim());
            var denominatorUnit = new VolumeUnit(units[1].Trim());
            return new Density(r.Value, counterUnit, denominatorUnit);
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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Density && Equals((Density)obj);
        }

        public bool Equals(IUnitedValue<DensityUnit> other)
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

        public DensityUnit Unit { get; }

        public string ToString(string format, IFormatProvider provider) 
            => this.ToStringFormat(format, provider);
    }

    public struct DensityUnit : IUnit, IEquatable<DensityUnit>
    {
        public DensityUnit(WeightUnit counterUnit, VolumeUnit denominatorUnit)
        {
            CounterUnit = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public static bool operator ==(DensityUnit left, DensityUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DensityUnit left, DensityUnit right)
        {
            return !left.Equals(right);
        }

        public bool Equals(DensityUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is DensityUnit && Equals((DensityUnit)obj);
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
        public VolumeUnit DenominatorUnit { get; }
    }
}