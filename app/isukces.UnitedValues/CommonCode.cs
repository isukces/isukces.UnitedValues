using System;
using System.Globalization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace isukces.UnitedValues
{
	[JsonConverter(typeof(WeightJsonConverter))]
	public partial struct Weight : IUnitedValue<WeightUnit>, IEquatable<Weight>, IComparable<Weight> {

		public Weight(decimal value, WeightUnit unit)
        {
            Value = value;
            Unit = unit;
        }	

		public bool Equals(IUnitedValue<WeightUnit> other)
	    {
	        if (other == null) return false;
			return Value == other.Value && Unit.Equals(other.Unit);
	    }

		public Weight ConvertTo(WeightUnit newUnit)
        {
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            if (WeightUnit.KnownUnits.TryGetValue(newUnit, out decimal mult))
                return new Weight(basic / mult, newUnit);
            throw new Exception("Unable to find multiplication for unit " + newUnit);
        }

		// Equality

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

		// Algebra

		public static Weight operator +(Weight left, Weight right)
        {
            right = right.ConvertTo(left.Unit);
            return new Weight(right.Value + left.Value, left.Unit);
        }
        public static Weight operator -(Weight left, Weight right)
        {
            right = right.ConvertTo(left.Unit);
            return new Weight(left.Value - right.Value, left.Unit);
        }
        public static Weight operator -(Weight value) => new Weight(-value.Value, value.Unit);

        public static Weight operator *(Weight value, decimal number) => new Weight(value.Value * number, value.Unit);
        public static Weight operator *(decimal number, Weight value) => new Weight(value.Value * number, value.Unit);

		public static Weight operator /(Weight value, decimal number) => new Weight(value.Value / number, value.Unit);
        public static decimal operator /(Weight left, Weight right)
        {
            right = right.ConvertTo(left.Unit);
            return right.Value / left.Value;
        }

		// IComparable

	    public int CompareTo(Weight other)
        {
			return UnitedValuesUtils.Compare<Weight,WeightUnit>(this, other);
        }
        public static bool operator !=(Weight left, Weight right) => left.CompareTo(right) != 0;
        public static bool operator ==(Weight left, Weight right) => left.CompareTo(right) == 0;
        public static bool operator >(Weight left, Weight right) => left.CompareTo(right) > 0;
        public static bool operator >=(Weight left, Weight right) => left.CompareTo(right) >= 0;
        public static bool operator <(Weight left, Weight right) => left.CompareTo(right) < 0;
        public static bool operator <=(Weight left, Weight right) => left.CompareTo(right) <= 0;

		// other

		public static Weight Parse(string value)
        {
            var parseResult = CommonParse.Parse(value, typeof(Weight));
            return new Weight(parseResult.Value, new WeightUnit(parseResult.UnitName));
        }

		public decimal GetBaseUnitValue()
        {
            if (Unit.Equals(BaseUnit))
                return Value;
            if (WeightUnit.KnownUnits.TryGetValue(Unit, out decimal mult))
                return Value * mult;
            throw new Exception("Unable to find multiplication for unit " + Unit);
        }

		public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName;
        }

		// properties

        public decimal Value { get; }
        public WeightUnit Unit { get; }

		public static WeightUnit BaseUnit = WeightUnitDefinition.Kg;
		public static Weight Zero => new Weight(0m, BaseUnit);
	}

	[JsonConverter(typeof(LengthJsonConverter))]
	public partial struct Length : IUnitedValue<LengthUnit>, IEquatable<Length>, IComparable<Length> {

		public Length(decimal value, LengthUnit unit)
        {
            Value = value;
            Unit = unit;
        }	

		public bool Equals(IUnitedValue<LengthUnit> other)
	    {
	        if (other == null) return false;
			return Value == other.Value && Unit.Equals(other.Unit);
	    }

		public Length ConvertTo(LengthUnit newUnit)
        {
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
            if (LengthUnit.KnownUnits.TryGetValue(newUnit, out decimal mult))
                return new Length(basic / mult, newUnit);
            throw new Exception("Unable to find multiplication for unit " + newUnit);
        }

		// Equality

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

		// Algebra

		public static Length operator +(Length left, Length right)
        {
            right = right.ConvertTo(left.Unit);
            return new Length(right.Value + left.Value, left.Unit);
        }
        public static Length operator -(Length left, Length right)
        {
            right = right.ConvertTo(left.Unit);
            return new Length(left.Value - right.Value, left.Unit);
        }
        public static Length operator -(Length value) => new Length(-value.Value, value.Unit);

        public static Length operator *(Length value, decimal number) => new Length(value.Value * number, value.Unit);
        public static Length operator *(decimal number, Length value) => new Length(value.Value * number, value.Unit);

		public static Length operator /(Length value, decimal number) => new Length(value.Value / number, value.Unit);
        public static decimal operator /(Length left, Length right)
        {
            right = right.ConvertTo(left.Unit);
            return right.Value / left.Value;
        }

		// IComparable

	    public int CompareTo(Length other)
        {
			return UnitedValuesUtils.Compare<Length,LengthUnit>(this, other);
        }
        public static bool operator !=(Length left, Length right) => left.CompareTo(right) != 0;
        public static bool operator ==(Length left, Length right) => left.CompareTo(right) == 0;
        public static bool operator >(Length left, Length right) => left.CompareTo(right) > 0;
        public static bool operator >=(Length left, Length right) => left.CompareTo(right) >= 0;
        public static bool operator <(Length left, Length right) => left.CompareTo(right) < 0;
        public static bool operator <=(Length left, Length right) => left.CompareTo(right) <= 0;

		// other

		public static Length Parse(string value)
        {
            var parseResult = CommonParse.Parse(value, typeof(Length));
            return new Length(parseResult.Value, new LengthUnit(parseResult.UnitName));
        }

		public decimal GetBaseUnitValue()
        {
            if (Unit.Equals(BaseUnit))
                return Value;
            if (LengthUnit.KnownUnits.TryGetValue(Unit, out decimal mult))
                return Value * mult;
            throw new Exception("Unable to find multiplication for unit " + Unit);
        }

		public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName;
        }

		// properties

        public decimal Value { get; }
        public LengthUnit Unit { get; }

		public static LengthUnit BaseUnit = LengthUnitDefinition.Meter;
		public static Length Zero => new Length(0m, BaseUnit);
	}

// ========================== UNIT DEF
    public static partial class WeightExtensions
    {
        /// <summary>
        ///     Sumuje wagi
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Weight Sum(this IEnumerable<Weight> items)
        {
            if (items == null)
                return Weight.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Weight.Zero;
            var unit = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Weight(value, unit);
        }

        /// <summary>
        ///     Sumuje wagi, nulle traktuje jako 0
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Weight Sum(this IEnumerable<Weight?> items)
        {
            if (items==null)
                return Weight.Zero;            
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        /// <summary>
        ///     Sumuje wagi
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Weight Sum<T>(this IEnumerable<T> items, Func<T, Weight> map)
        {
            return items.Select(map).Sum();
        }
    }
    public static partial class LengthExtensions
    {
        /// <summary>
        ///     Sumuje wagi
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Length Sum(this IEnumerable<Length> items)
        {
            if (items == null)
                return Length.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Length.Zero;
            var unit = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Length(value, unit);
        }

        /// <summary>
        ///     Sumuje wagi, nulle traktuje jako 0
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Length Sum(this IEnumerable<Length?> items)
        {
            if (items==null)
                return Length.Zero;            
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        /// <summary>
        ///     Sumuje wagi
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Length Sum<T>(this IEnumerable<T> items, Func<T, Length> map)
        {
            return items.Select(map).Sum();
        }
    }

// ========================== UNIT DEF


	public partial struct WeightUnit : IEquatable<WeightUnit>
    {

        private static void AddDefinition(WeightUnitDefinition definition)
        {
            KnownUnits[definition] = definition.Multiplication;
			if (definition.Aliases!=null && definition.Aliases.Length>0)
				foreach(var i in definition.Aliases)
					KnownUnits[new WeightUnit(i)] = definition.Multiplication;
        }


        public WeightUnit(string unitName)
        {
            UnitName = unitName;
        }

        public static bool operator ==(WeightUnit left, WeightUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(WeightUnit left, WeightUnit right)
        {
            return !left.Equals(right);
        }

        public bool Equals(WeightUnit other)
        {
            return String.Equals(UnitName, other.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is WeightUnit && Equals((WeightUnit)obj);
        }

        public override int GetHashCode()
        {
            return UnitName?.GetHashCode() ?? 0;
        }

        public override string ToString() => UnitName;

        bool IEquatable<WeightUnit>.Equals(WeightUnit other) => Equals(other);

        public string UnitName { get; }
        public static Dictionary<WeightUnit, decimal> KnownUnits { get; }
    }

    public partial struct WeightUnitDefinition
    {
        public WeightUnitDefinition(string unitName, decimal multiplication, params string[] aliases)
        {
            UnitName = unitName;
            Multiplication = multiplication;
            Aliases = aliases ?? new string[0];
        }


        public static implicit operator WeightUnit(WeightUnitDefinition x)
            => new WeightUnit(x.UnitName);

        public string UnitName { get; }
        public decimal Multiplication { get; }
        public string[] Aliases { get; }
      
    }


	public partial struct LengthUnit : IEquatable<LengthUnit>
    {

        private static void AddDefinition(LengthUnitDefinition definition)
        {
            KnownUnits[definition] = definition.Multiplication;
			if (definition.Aliases!=null && definition.Aliases.Length>0)
				foreach(var i in definition.Aliases)
					KnownUnits[new LengthUnit(i)] = definition.Multiplication;
        }


        public LengthUnit(string unitName)
        {
            UnitName = unitName;
        }

        public static bool operator ==(LengthUnit left, LengthUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LengthUnit left, LengthUnit right)
        {
            return !left.Equals(right);
        }

        public bool Equals(LengthUnit other)
        {
            return String.Equals(UnitName, other.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LengthUnit && Equals((LengthUnit)obj);
        }

        public override int GetHashCode()
        {
            return UnitName?.GetHashCode() ?? 0;
        }

        public override string ToString() => UnitName;

        bool IEquatable<LengthUnit>.Equals(LengthUnit other) => Equals(other);

        public string UnitName { get; }
        public static Dictionary<LengthUnit, decimal> KnownUnits { get; }
    }

    public partial struct LengthUnitDefinition
    {
        public LengthUnitDefinition(string unitName, decimal multiplication, params string[] aliases)
        {
            UnitName = unitName;
            Multiplication = multiplication;
            Aliases = aliases ?? new string[0];
        }


        public static implicit operator LengthUnit(LengthUnitDefinition x)
            => new LengthUnit(x.UnitName);

        public string UnitName { get; }
        public decimal Multiplication { get; }
        public string[] Aliases { get; }
      
    }
}

