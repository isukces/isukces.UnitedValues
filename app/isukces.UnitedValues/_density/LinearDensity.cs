using System;
using System.Globalization;

namespace isukces.UnitedValues
{
    public struct LinearDensity : IUnitedValue<LinearDensityUnit>, IEquatable<LinearDensity>
    {
        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName;

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

        public decimal Value { get; }

        public LinearDensityUnit Unit { get; }


        public static Weight operator *(LinearDensity d,  Length v)
        {
            v = v.ConvertTo(d.Unit.DenominatorUnit);
            return new Weight(d.Value * v.Value, d.Unit.CounterUnit);
        }

        public static Weight operator *(Length v, LinearDensity d)
        {
            v = v.ConvertTo(d.Unit.DenominatorUnit);
            return new Weight(d.Value * v.Value, d.Unit.CounterUnit);
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
    }

    public struct LinearDensityUnit : IUnit, IEquatable<LinearDensityUnit>
    {
        public override string ToString() => UnitName;

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

        public string UnitName => CounterUnit.UnitName + "/" + DenominatorUnit.UnitName;
        public WeightUnit CounterUnit { get; }
        public LengthUnit DenominatorUnit { get; }
    }
}