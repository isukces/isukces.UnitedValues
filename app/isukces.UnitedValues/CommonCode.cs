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
			var factor = GlobalUnitRegistry.Factors.Get(newUnit);
            if (factor != null)
                return new Weight(basic / factor.Value, newUnit);
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


		public Weight Round(int decimalPlaces)
        {
            return new Weight(Math.Round(Value, decimalPlaces), Unit);
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
			var factor = GlobalUnitRegistry.Factors.Get(Unit);
            if (factor != null)
                return Value * factor.Value;
            throw new Exception("Unable to find multiplication for unit " + Unit);
        }

		public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName;
        }

		// properties

        public decimal Value { get; }
        public WeightUnit Unit { get; }

		public static WeightUnit BaseUnit = WeightUnits.Kg;
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
			var factor = GlobalUnitRegistry.Factors.Get(newUnit);
            if (factor != null)
                return new Length(basic / factor.Value, newUnit);
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


		public Length Round(int decimalPlaces)
        {
            return new Length(Math.Round(Value, decimalPlaces), Unit);
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
			var factor = GlobalUnitRegistry.Factors.Get(Unit);
            if (factor != null)
                return Value * factor.Value;
            throw new Exception("Unable to find multiplication for unit " + Unit);
        }

		public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName;
        }

		// properties

        public decimal Value { get; }
        public LengthUnit Unit { get; }

		public static LengthUnit BaseUnit = LengthUnits.Meter;
		public static Length Zero => new Length(0m, BaseUnit);
	}

	[JsonConverter(typeof(AreaJsonConverter))]
	public partial struct Area : IUnitedValue<AreaUnit>, IEquatable<Area> {

		public Area(decimal value, AreaUnit unit)
        {
            Value = value;
            Unit = unit;
        }	

		public bool Equals(IUnitedValue<AreaUnit> other)
	    {
	        if (other == null) return false;
			return Value == other.Value && Unit.Equals(other.Unit);
	    }

		public Area ConvertTo(AreaUnit newUnit)
        {
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
			var factor = GlobalUnitRegistry.Factors.Get(newUnit);
            if (factor != null)
                return new Area(basic / factor.Value, newUnit);
            throw new Exception("Unable to find multiplication for unit " + newUnit);
        }

		// Equality

		public bool Equals(Area other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Area && Equals((Area)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Unit.GetHashCode();
            }
        }

		// Algebra

		public static Area operator +(Area left, Area right)
        {
            right = right.ConvertTo(left.Unit);
            return new Area(right.Value + left.Value, left.Unit);
        }
        public static Area operator -(Area left, Area right)
        {
            right = right.ConvertTo(left.Unit);
            return new Area(left.Value - right.Value, left.Unit);
        }
        public static Area operator -(Area value) => new Area(-value.Value, value.Unit);

        public static Area operator *(Area value, decimal number) => new Area(value.Value * number, value.Unit);
        public static Area operator *(decimal number, Area value) => new Area(value.Value * number, value.Unit);

		public static Area operator /(Area value, decimal number) => new Area(value.Value / number, value.Unit);
        public static decimal operator /(Area left, Area right)
        {
            right = right.ConvertTo(left.Unit);
            return right.Value / left.Value;
        }


		public Area Round(int decimalPlaces)
        {
            return new Area(Math.Round(Value, decimalPlaces), Unit);
        }


		// other

		public static Area Parse(string value)
        {
            var parseResult = CommonParse.Parse(value, typeof(Area));
            return new Area(parseResult.Value, new AreaUnit(parseResult.UnitName));
        }

		public decimal GetBaseUnitValue()
        {
            if (Unit.Equals(BaseUnit))
                return Value;
			var factor = GlobalUnitRegistry.Factors.Get(Unit);
            if (factor != null)
                return Value * factor.Value;
            throw new Exception("Unable to find multiplication for unit " + Unit);
        }

		public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName;
        }

		// properties

        public decimal Value { get; }
        public AreaUnit Unit { get; }

		public static AreaUnit BaseUnit = AreaUnits.SquareMeter;
		public static Area Zero => new Area(0m, BaseUnit);
	}

	[JsonConverter(typeof(VolumeJsonConverter))]
	public partial struct Volume : IUnitedValue<VolumeUnit>, IEquatable<Volume> {

		public Volume(decimal value, VolumeUnit unit)
        {
            Value = value;
            Unit = unit;
        }	

		public bool Equals(IUnitedValue<VolumeUnit> other)
	    {
	        if (other == null) return false;
			return Value == other.Value && Unit.Equals(other.Unit);
	    }

		public Volume ConvertTo(VolumeUnit newUnit)
        {
            if (Unit.Equals(newUnit))
                return this;
            var basic = GetBaseUnitValue();
			var factor = GlobalUnitRegistry.Factors.Get(newUnit);
            if (factor != null)
                return new Volume(basic / factor.Value, newUnit);
            throw new Exception("Unable to find multiplication for unit " + newUnit);
        }

		// Equality

		public bool Equals(Volume other)
        {
            return Value == other.Value && Unit.Equals(other.Unit);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Volume && Equals((Volume)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ Unit.GetHashCode();
            }
        }

		// Algebra

		public static Volume operator +(Volume left, Volume right)
        {
            right = right.ConvertTo(left.Unit);
            return new Volume(right.Value + left.Value, left.Unit);
        }
        public static Volume operator -(Volume left, Volume right)
        {
            right = right.ConvertTo(left.Unit);
            return new Volume(left.Value - right.Value, left.Unit);
        }
        public static Volume operator -(Volume value) => new Volume(-value.Value, value.Unit);

        public static Volume operator *(Volume value, decimal number) => new Volume(value.Value * number, value.Unit);
        public static Volume operator *(decimal number, Volume value) => new Volume(value.Value * number, value.Unit);

		public static Volume operator /(Volume value, decimal number) => new Volume(value.Value / number, value.Unit);
        public static decimal operator /(Volume left, Volume right)
        {
            right = right.ConvertTo(left.Unit);
            return right.Value / left.Value;
        }


		public Volume Round(int decimalPlaces)
        {
            return new Volume(Math.Round(Value, decimalPlaces), Unit);
        }


		// other

		public static Volume Parse(string value)
        {
            var parseResult = CommonParse.Parse(value, typeof(Volume));
            return new Volume(parseResult.Value, new VolumeUnit(parseResult.UnitName));
        }

		public decimal GetBaseUnitValue()
        {
            if (Unit.Equals(BaseUnit))
                return Value;
			var factor = GlobalUnitRegistry.Factors.Get(Unit);
            if (factor != null)
                return Value * factor.Value;
            throw new Exception("Unable to find multiplication for unit " + Unit);
        }

		public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName;
        }

		// properties

        public decimal Value { get; }
        public VolumeUnit Unit { get; }

		public static VolumeUnit BaseUnit = VolumeUnits.QubicMeter;
		public static Volume Zero => new Volume(0m, BaseUnit);
	}


// ========================== EXTENSIONS

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
    public static partial class AreaExtensions
    {
        /// <summary>
        ///     Sumuje wagi
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Area Sum(this IEnumerable<Area> items)
        {
            if (items == null)
                return Area.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Area.Zero;
            var unit = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Area(value, unit);
        }

        /// <summary>
        ///     Sumuje wagi, nulle traktuje jako 0
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Area Sum(this IEnumerable<Area?> items)
        {
            if (items==null)
                return Area.Zero;            
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        /// <summary>
        ///     Sumuje wagi
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Area Sum<T>(this IEnumerable<T> items, Func<T, Area> map)
        {
            return items.Select(map).Sum();
        }
    }
    public static partial class VolumeExtensions
    {
        /// <summary>
        ///     Sumuje wagi
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Volume Sum(this IEnumerable<Volume> items)
        {
            if (items == null)
                return Volume.Zero;
            var c = items.ToArray();
            if (c.Length == 0)
                return Volume.Zero;
            var unit = c[0].Unit;
            var value = c.Aggregate(0m, (x, y) => x + y.ConvertTo(unit).Value);
            return new Volume(value, unit);
        }

        /// <summary>
        ///     Sumuje wagi, nulle traktuje jako 0
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Volume Sum(this IEnumerable<Volume?> items)
        {
            if (items==null)
                return Volume.Zero;            
            return items.Where(a => a != null).Select(a => a.Value).Sum();
        }

        /// <summary>
        ///     Sumuje wagi
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Volume Sum<T>(this IEnumerable<T> items, Func<T, Volume> map)
        {
            return items.Select(map).Sum();
        }
    }

// ========================== JSON

    public class WeightJsonConverter : AbstractUnitJsonConverter<Weight, WeightUnit>
    {
        protected override Weight Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Weight(value, string.IsNullOrEmpty(unit) ? Weight.BaseUnit : new WeightUnit(unit));
        }

        protected override Weight Parse(string txt)
        {
            return Weight.Parse(txt);
        }
    }
    public class LengthJsonConverter : AbstractUnitJsonConverter<Length, LengthUnit>
    {
        protected override Length Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Length(value, string.IsNullOrEmpty(unit) ? Length.BaseUnit : new LengthUnit(unit));
        }

        protected override Length Parse(string txt)
        {
            return Length.Parse(txt);
        }
    }
    public class AreaJsonConverter : AbstractUnitJsonConverter<Area, AreaUnit>
    {
        protected override Area Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Area(value, string.IsNullOrEmpty(unit) ? Area.BaseUnit : new AreaUnit(unit));
        }

        protected override Area Parse(string txt)
        {
            return Area.Parse(txt);
        }
    }
    public class VolumeJsonConverter : AbstractUnitJsonConverter<Volume, VolumeUnit>
    {
        protected override Volume Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Volume(value, string.IsNullOrEmpty(unit) ? Volume.BaseUnit : new VolumeUnit(unit));
        }

        protected override Volume Parse(string txt)
        {
            return Volume.Parse(txt);
        }
    }

// ========================== UNITS


	public partial struct WeightUnit : IUnit, IEquatable<WeightUnit>
    {

		public static implicit operator WeightUnit(UnitDefinition<WeightUnit> src) 
			=> new WeightUnit(src.UnitName);

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
    }

	/*
    public partial struct WeightUnitDefinition: IUnitDefinition
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
	*/


	public partial struct LengthUnit : IUnit, IEquatable<LengthUnit>
    {

		public static implicit operator LengthUnit(UnitDefinition<LengthUnit> src) 
			=> new LengthUnit(src.UnitName);

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
    }

	/*
    public partial struct LengthUnitDefinition: IUnitDefinition
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
	*/


	public partial struct AreaUnit : IUnit, IEquatable<AreaUnit>
    {

		public static implicit operator AreaUnit(UnitDefinition<AreaUnit> src) 
			=> new AreaUnit(src.UnitName);

        public AreaUnit(string unitName)
        {
			UnitName = unitName?.Replace("2", "²");
        }

        public static bool operator ==(AreaUnit left, AreaUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AreaUnit left, AreaUnit right)
        {
            return !left.Equals(right);
        }

        public bool Equals(AreaUnit other)
        {
            return String.Equals(UnitName, other.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is AreaUnit && Equals((AreaUnit)obj);
        }

        public override int GetHashCode()
        {
            return UnitName?.GetHashCode() ?? 0;
        }

        public override string ToString() => UnitName;

        bool IEquatable<AreaUnit>.Equals(AreaUnit other) => Equals(other);

        public string UnitName { get; }
    }

	/*
    public partial struct AreaUnitDefinition: IUnitDefinition
    {
        public AreaUnitDefinition(string unitName, decimal multiplication, params string[] aliases)
        {
            UnitName = unitName;
            Multiplication = multiplication;
            Aliases = aliases ?? new string[0];
        }


        public static implicit operator AreaUnit(AreaUnitDefinition x)
            => new AreaUnit(x.UnitName);

        public string UnitName { get; }
        public decimal Multiplication { get; }
        public string[] Aliases { get; }
      
    }
	*/


	public partial struct VolumeUnit : IUnit, IEquatable<VolumeUnit>
    {

		public static implicit operator VolumeUnit(UnitDefinition<VolumeUnit> src) 
			=> new VolumeUnit(src.UnitName);

        public VolumeUnit(string unitName)
        {
			UnitName = unitName?.Replace("3", "³");
        }

        public static bool operator ==(VolumeUnit left, VolumeUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(VolumeUnit left, VolumeUnit right)
        {
            return !left.Equals(right);
        }

        public bool Equals(VolumeUnit other)
        {
            return String.Equals(UnitName, other.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is VolumeUnit && Equals((VolumeUnit)obj);
        }

        public override int GetHashCode()
        {
            return UnitName?.GetHashCode() ?? 0;
        }

        public override string ToString() => UnitName;

        bool IEquatable<VolumeUnit>.Equals(VolumeUnit other) => Equals(other);

        public string UnitName { get; }
    }

	/*
    public partial struct VolumeUnitDefinition: IUnitDefinition
    {
        public VolumeUnitDefinition(string unitName, decimal multiplication, params string[] aliases)
        {
            UnitName = unitName;
            Multiplication = multiplication;
            Aliases = aliases ?? new string[0];
        }


        public static implicit operator VolumeUnit(VolumeUnitDefinition x)
            => new VolumeUnit(x.UnitName);

        public string UnitName { get; }
        public decimal Multiplication { get; }
        public string[] Aliases { get; }
      
    }
	*/
}

