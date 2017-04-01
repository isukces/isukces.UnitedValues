using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace isukces.UnitedValues
{
    [JsonConverter(typeof(WeightJsonConverter))]
    public partial struct Weight : IEquatable<Weight>, IComparable<Weight>
    {
        public Weight(decimal value, WeightUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public static Weight operator +(Weight a, Weight b)
        {
            b = b.ConvertTo(a.Unit);
            return new Weight(b.Value + a.Value, a.Unit);
        }

        public static decimal operator /(Weight a, Weight b)
        {
            b = b.ConvertTo(a.Unit);
            return b.Value / a.Value;
        }

        public static Weight operator /(Weight w, decimal d) => FromKg(w.Value / d);

        public static bool operator ==(Weight a, Weight b) => a.CompareTo(b) == 0;
        public static bool operator >(Weight a, Weight b) => a.CompareTo(b) > 0;
        public static bool operator >=(Weight a, Weight b) => a.CompareTo(b) >= 0;
        public static bool operator !=(Weight a, Weight b) => a.CompareTo(b) != 0;


        public static bool operator <(Weight a, Weight b) => a.CompareTo(b) < 0;
        public static bool operator <=(Weight a, Weight b) => a.CompareTo(b) <= 0;

        public static Weight operator *(Weight w, decimal d) => new Weight(w.Value * d, w.Unit);
        public static Weight operator *(decimal d, Weight w) => new Weight(w.Value * d, w.Unit);

        public static Weight operator -(Weight a, Weight b)
        {
            b = b.ConvertTo(a.Unit);
            return new Weight(a.Value - b.Value, a.Unit);
        }

        public static Weight operator -(Weight a) => new Weight(-a.Value, a.Unit);

        public static Weight Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException();
            var m = ParseRegex.Match(value);
            if (!m.Success)
                throw new ArgumentException($"Unable to convert \'{value}\' into Weight");
            var minus = m.Groups[1].Value == "-";
            var number = decimal.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture);
            if (minus)
                number = -number;
            var unit = m.Groups[6].Value.Trim();
            var unitL = unit.ToLower();
            if (unit == "kg")
                return FromKg(number);
            if (unitL == "t" || unitL == "ton" || unitL == "tons")
                return FromTons(number);
            return new Weight(number, new WeightUnit(unit));
            // throw new Exception("Unrecognized weight unit " + unit);
        }

        private static void AddDefinition(WeightUnitDefinition definition)
        {
            KnownUnits[definition] = definition.Multiplication;
        }


        public int CompareTo(Weight other)
        {
            if (Equals(other)) return 0;
            if (Unit.Equals(other.Unit))
                return Value.CompareTo(other.Value);
            var myKg = ConvertToKg().Value;
            var otherKg = other.ConvertToKg().Value;
            return myKg.CompareTo(otherKg);
        }

        public Weight ConvertTo(WeightUnit newUnit)
        {
            if (Unit.Equals(newUnit))
                return this;
            var kg = ConvertToKg();
            if (KnownUnits.TryGetValue(newUnit, out decimal mult))
                return new Weight(kg.Value / mult, newUnit);
            throw new Exception("Unable to find multiplication for unit " + newUnit);
        }


        public Weight ConvertToKg()
        {
            if (Unit.UnitName == WeightUnitDefinition.Kg.UnitName)
                return this;
            if (KnownUnits.TryGetValue(Unit, out decimal mult))
                return FromKg(Value * mult);
            throw new Exception("Unable to find multiplication for unit " + Unit);
        }


        public bool Equals(Weight other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Weight && Equals((Weight)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Unit.GetHashCode();
            }
        }

        public Weight RoundKg(Weight w, int decimalPlaces)
        {
            return FromKg(Math.Round(w.Value, decimalPlaces));
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName;
        }

        bool IEquatable<Weight>.Equals(Weight other)
        {
            return Equals(other);
        }

        public static Dictionary<WeightUnit, decimal> KnownUnits { get; }

        public static Weight Zero => FromKg(0m);

        public decimal Value { get; }

        public WeightUnit Unit { get; }

        private static readonly Regex ParseRegex = new Regex(RegexFilter, RegexOptions.Compiled);


        private const string RegexFilter = @"^\s*([-+]?)\s*((\d+)(\.(\d+))?)\s*(.*)\s*$";
    }

    public partial struct Weight
    {
        static Weight()
        {
            KnownUnits = new Dictionary<WeightUnit, decimal>();
            AddDefinition(WeightUnitDefinition.Kg);
            AddDefinition(WeightUnitDefinition.Tone);
            AddDefinition(WeightUnitDefinition.Gram);
        }


        public static Weight FromKg(decimal kg) => new Weight(kg, WeightUnitDefinition.Kg);
        public static Weight FromKg(long kg) => new Weight(kg, WeightUnitDefinition.Kg);
        public static Weight FromKg(double kg) => new Weight((decimal)kg, WeightUnitDefinition.Kg);

        public static Weight FromTons(decimal tons) => new Weight(tons, WeightUnitDefinition.Tone);
        public static Weight FromTons(double tons) => new Weight((decimal)tons, WeightUnitDefinition.Tone);
        public static Weight FromTons(long tons) => new Weight(tons, WeightUnitDefinition.Tone);
    }
}