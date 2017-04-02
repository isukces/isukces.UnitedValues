using System;
using System.Collections.Generic;

namespace isukces.UnitedValues
{
    public partial struct Length
    {
        public static Length FromKm(decimal m) => new Length(m, LengthUnitDefinition.Km);
        public static Length FromKm(long m) => new Length(m, LengthUnitDefinition.Km);
        public static Length FromKm(double m) => new Length((decimal)m, LengthUnitDefinition.Km);


        public static Length FromMeter(decimal m) => new Length(m, LengthUnitDefinition.Meter);
        public static Length FromMeter(long m) => new Length(m, LengthUnitDefinition.Meter);
        public static Length FromMeter(double m) => new Length((decimal)m, LengthUnitDefinition.Meter);

        public static Area operator *(Length a, Length b)
        {
            var resultUnit = ToAreaUnit(a.Unit);
            b = b.ConvertTo(a.Unit);
            return new Area(a.Value * b.Value, resultUnit);
        }

        public static Length operator /(Area a, Length b)
        {
            var resultUnit = ToLengthUnit(a.Unit);
            b = b.ConvertTo(resultUnit);
            return new Length(a.Value / b.Value, resultUnit);
        }

        private static LengthUnit ToLengthUnit(AreaUnit u)
        {
            if (u.Equals(AreaUnitDefinition.SquareMeter))
                return LengthUnitDefinition.Meter;
            throw new Exception($"Unable to convert {u} into LengthUnit");
        }


        public static Volume operator *(Area a, Length b)
        {
            var resultUnit = ToVolumeUnit(a.Unit);
            b = b.ConvertTo(ToLengthUnit(a.Unit));
            return new Volume(a.Value * b.Value, resultUnit);
        }

        private static VolumeUnit ToVolumeUnit(AreaUnit u)
        {
            throw new NotImplementedException();
        }

        private static AreaUnit ToAreaUnit(LengthUnit u)
        {
            if (u.Equals(LengthUnitDefinition.Meter))
                return AreaUnitDefinition.SquareMeter;

            throw new Exception($"Unable to convert {u} into AreaUnit");
        }


        public Length ConvertToMeter()
        {
            return ConvertTo(LengthUnitDefinition.Meter);
        }


        public Length RoundKg(Length w, int decimalPlaces)
        {
            return FromMeter(Math.Round(w.Value, decimalPlaces));
        }
    }

    public partial struct LengthUnit
    {
        static LengthUnit()
        {
            KnownUnits = new Dictionary<LengthUnit, decimal>();
            AddDefinition(LengthUnitDefinition.Km);
            AddDefinition(LengthUnitDefinition.Meter);
            AddDefinition(LengthUnitDefinition.Mm);

            AddDefinition(LengthUnitDefinition.Cm);
            AddDefinition(LengthUnitDefinition.Feet);
            AddDefinition(LengthUnitDefinition.Inch);
        }
    }

    public partial struct LengthUnitDefinition
    {
        public static readonly LengthUnitDefinition Meter = new LengthUnitDefinition("m", 1);
        public static readonly LengthUnitDefinition Km = new LengthUnitDefinition("km", 1000);
        public static readonly LengthUnitDefinition Mm = new LengthUnitDefinition("mm", 0.001m);
        public static readonly LengthUnitDefinition Cm = new LengthUnitDefinition("cm", 0.01m);
        public static readonly LengthUnitDefinition Inch = new LengthUnitDefinition("inch", 0.0254m);
        public static readonly LengthUnitDefinition Feet = new LengthUnitDefinition("ft", 0.0254m * 12);
    }
}