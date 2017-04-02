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


        public static Length operator /(Area a, Length b)
        {
            var resultUnit = ToLengthUnit(a.Unit);
            b = b.ConvertTo(resultUnit);
            return new Length(a.Value / b.Value, resultUnit);
        }

        public static Area operator *(Length a, Length b)
        {
            var resultUnit = ToAreaUnit(a.Unit);
            b = b.ConvertTo(a.Unit);
            return new Area(a.Value * b.Value, resultUnit);
        }

        public static Volume operator *(Length a, Area b)
        {
            var areaUnit = ToAreaUnit(a.Unit);
            b = b.ConvertTo(areaUnit);
            var volumeUnit = ToVolumeUnit(a.Unit);
            return new Volume(a.Value * b.Value, volumeUnit);
        }

        public static Volume operator *(Area a, Length b)
        {
            var lengthUnit = ToLengthUnit(a.Unit);
            b = b.ConvertTo(lengthUnit);
            var volumeUnit = ToVolumeUnit(a.Unit);
            return new Volume(a.Value * b.Value, volumeUnit);
        }

 
        private static AreaUnitDefinition ToAreaUnit(LengthUnit u)
        {
            var a = GlobalUnitRegistry.Relations.Get<LengthUnit, AreaUnitDefinition>(u);
            if (a == null)
                throw new Exception($"Unable to convert {u} into AreaUnit");
            return a.Item1;
        }

        private static LengthUnit ToLengthUnit(AreaUnit u)
        {
            if (u.Equals(AreaUnitDefinition.SquareMeter))
                return LengthUnitDefinition.Meter;
            throw new Exception($"Unable to convert {u} into LengthUnit");
        }

        private static VolumeUnitDefinition ToVolumeUnit(LengthUnit unit)
        {
            var a = GlobalUnitRegistry.Relations.Get<LengthUnit, VolumeUnitDefinition>(unit);
            if (a == null)
                throw new Exception($"Unable to convert {unit} into VolumeUnit");
            return a.Item1;
        }

        private static VolumeUnit ToVolumeUnit(AreaUnit u)
        {
            throw new NotImplementedException();
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
            foreach (var i in LengthUnitDefinition.All)
                AddDefinition(i);
        }
    }
}