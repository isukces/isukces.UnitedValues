using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace isukces.UnitedValues
{
    [JsonConverter(typeof(LengthJsonConverter))]
    public partial struct Length : IEquatable<Length>, IComparable<Length>
    {
        public Length(decimal value, LengthUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public static Length operator +(Length a, Length b)
        {
            b = b.ConvertTo(a.Unit);
            return new Length(b.Value + a.Value, a.Unit);
        }

        public static decimal operator /(Length a, Length b)
        {
            b = b.ConvertTo(a.Unit);
            return b.Value / a.Value;
        }

        public static Length operator /(Length w, decimal d) => new Length(w.Value / d, w.Unit);

        public static bool operator ==(Length a, Length b) => a.CompareTo(b) == 0;
        public static bool operator >(Length a, Length b) => a.CompareTo(b) > 0;
        public static bool operator >=(Length a, Length b) => a.CompareTo(b) >= 0;
        public static bool operator !=(Length a, Length b) => a.CompareTo(b) != 0;


        public static bool operator <(Length a, Length b) => a.CompareTo(b) < 0;
        public static bool operator <=(Length a, Length b) => a.CompareTo(b) <= 0;

        public static Length operator *(Length w, decimal d) => new Length(w.Value * d, w.Unit);
        public static Length operator *(decimal d, Length w) => new Length(w.Value * d, w.Unit);

        public static Length operator -(Length a, Length b)
        {
            b = b.ConvertTo(a.Unit);
            return new Length(a.Value - b.Value, a.Unit);
        }

        public static Length operator -(Length a) => new Length(-a.Value, a.Unit);

        public static Length Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException();
            var m = ParseRegex.Match(value);
            if (!m.Success)
                throw new ArgumentException($"Unable to convert \'{value}\' into Length");
            var minus = m.Groups[1].Value == "-";
            var number = decimal.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture);
            if (minus)
                number = -number;
            var unit = m.Groups[6].Value.Trim();
            return new Length(number, new LengthUnit(unit));
        }

        private static void AddDefinition(LengthUnitDefinition definition)
        {
            KnownUnits[definition] = definition.Multiplication;
        }


        public int CompareTo(Length other)
        {
            if (Equals(other)) return 0;
            if (Unit.Equals(other.Unit))
                return Value.CompareTo(other.Value);
            var a = ConvertToMeter().Value;
            var b = other.ConvertToMeter().Value;
            return a.CompareTo(b);
        }

        public Length ConvertTo(LengthUnit newUnit)
        {
            if (Unit.Equals(newUnit))
                return this;
            var kg = ConvertToMeter();
            if (KnownUnits.TryGetValue(newUnit, out decimal mult))
                return new Length(kg.Value / mult, newUnit);
            throw new Exception("Unable to find multiplication for unit " + newUnit);
        }


        public Length ConvertToMeter()
        {
            if (Unit.UnitName == LengthUnitDefinition.Metr.UnitName)
                return this;
            if (KnownUnits.TryGetValue(Unit, out decimal mult))
                return FromMeter(Value * mult);
            throw new Exception("Unable to find multiplication for unit " + Unit);
        }


        public bool Equals(Length other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Length && Equals((Length)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Unit.GetHashCode();
            }
        }

        public Length RoundKg(Length w, int decimalPlaces)
        {
            return FromMeter(Math.Round(w.Value, decimalPlaces));
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName;
        }

        bool IEquatable<Length>.Equals(Length other)
        {
            return Equals(other);
        }

        public static Dictionary<LengthUnit, decimal> KnownUnits { get; }

        public static Length Zero => FromMeter(0m);

        public decimal Value { get; }

        public LengthUnit Unit { get; }

        private static readonly Regex ParseRegex = new Regex(RegexFilter, RegexOptions.Compiled);


        private const string RegexFilter = @"^\s*([-+]?)\s*((\d+)(\.(\d+))?)\s*(.*)\s*$";
    }


    public partial struct Length
    {
        static Length()
        {
            KnownUnits = new Dictionary<LengthUnit, decimal>();
            AddDefinition(LengthUnitDefinition.Km);
            AddDefinition(LengthUnitDefinition.Metr);
            AddDefinition(LengthUnitDefinition.Mm);

            AddDefinition(LengthUnitDefinition.Cm);
            AddDefinition(LengthUnitDefinition.Feet);
            AddDefinition(LengthUnitDefinition.Inch);
        }


        public static Length FromMeter(decimal m) => new Length(m, LengthUnitDefinition.Metr);
        public static Length FromMeter(long m) => new Length(m, LengthUnitDefinition.Metr);
        public static Length FromMeter(double m) => new Length((decimal)m, LengthUnitDefinition.Metr);

        public static Length FromKm(decimal m) => new Length(m, LengthUnitDefinition.Km);
        public static Length FromKm(long m) => new Length(m, LengthUnitDefinition.Km);
        public static Length FromKm(double m) => new Length((decimal)m, LengthUnitDefinition.Km);
    }
}