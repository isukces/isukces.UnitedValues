using System;
using System.Globalization;

namespace isukces.UnitedValues
{
    public partial struct PlanarDensity : IUnitedValue<PlaneDensityUnit>, IEquatable<PlanarDensity>
    {
        public PlanarDensity(decimal value, PlaneDensityUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public PlanarDensity(decimal value, WeightUnit counterUnit, AreaUnit denominatorUnit)
        {
            Value = value;
            Unit = new PlaneDensityUnit(counterUnit, denominatorUnit);
        }

        public static bool operator ==(PlanarDensity left, PlanarDensity right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PlanarDensity left, PlanarDensity right)
        {
            return !left.Equals(right);
        }


        public PlanarDensity ConvertTo(PlaneDensityUnit newUnit)
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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is PlanarDensity && Equals((PlanarDensity)obj);
        }

        public bool Equals(IUnitedValue<PlaneDensityUnit> other)
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

        public PlaneDensityUnit Unit { get; }
    }

    public struct PlaneDensityUnit : IUnit, IEquatable<PlaneDensityUnit>
    {
        public PlaneDensityUnit(WeightUnit counterUnit, AreaUnit denominatorUnit)
        {
            CounterUnit = counterUnit;
            DenominatorUnit = denominatorUnit;
        }

        public static bool operator ==(PlaneDensityUnit left, PlaneDensityUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PlaneDensityUnit left, PlaneDensityUnit right)
        {
            return !left.Equals(right);
        }

        public bool Equals(PlaneDensityUnit other)
        {
            return CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is PlaneDensityUnit && Equals((PlaneDensityUnit)obj);
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
        public AreaUnit DenominatorUnit { get; }
    }
}