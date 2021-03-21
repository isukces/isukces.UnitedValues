﻿using System;
using System.Globalization;
using Newtonsoft.Json;

namespace iSukces.UnitedValues
{
    [JsonConverter(typeof(PlanarDensityJsonConverter))]
    [Serializable]
    public partial struct PlanarDensity : IUnitedValue<PlanarDensityUnit>, IEquatable<PlanarDensity>, IFormattable
    {
        public PlanarDensity(decimal value, PlanarDensityUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public PlanarDensity(decimal value, WeightUnit counterUnit, AreaUnit denominatorUnit)
        {
            Value = value;
            Unit = new PlanarDensityUnit(counterUnit, denominatorUnit);
        }

        public static bool operator ==(PlanarDensity left, PlanarDensity right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PlanarDensity left, PlanarDensity right)
        {
            return !left.Equals(right);
        }

        public static PlanarDensity Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            var r = CommonParse.Parse(value, typeof(Density));
            var units = r.UnitName.Split('/');
            if (units.Length != 2)
                throw new Exception($"{r.UnitName} is not valid density unit");
            var counterUnit = new WeightUnit(units[0].Trim());
            var denominatorUnit = new AreaUnit(units[1].Trim());
            return new PlanarDensity(r.Value, counterUnit, denominatorUnit);
        }

        public PlanarDensity ConvertTo(PlanarDensityUnit newUnit)
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

        public bool Equals(IUnitedValue<PlanarDensityUnit> other)
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

        public string ToString(string format, IFormatProvider provider)
            => this.ToStringFormat(format, provider);

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName;

        public decimal Value { get; }

        public PlanarDensityUnit Unit { get; }
    }
    
}