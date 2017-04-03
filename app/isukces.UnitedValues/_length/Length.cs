using System;
using System.Collections.Generic;

namespace isukces.UnitedValues
{
    public partial struct Length
    {
        public static Length FromKm(decimal m) => new Length(m, LengthUnits.Km);
        public static Length FromKm(long m) => new Length(m, LengthUnits.Km);
        public static Length FromKm(double m) => new Length((decimal)m, LengthUnits.Km);


        public static Length FromMeter(decimal m) => new Length(m, LengthUnits.Meter);
        public static Length FromMeter(long m) => new Length(m, LengthUnits.Meter);
        public static Length FromMeter(double m) => new Length((decimal)m, LengthUnits.Meter);


        public static Length operator /(Area left, Length right)
        {
            return UnitedValuesUtils
                 .Divide<Area, AreaUnit, Length, LengthUnit, Length, LengthUnit>(
                     left, right,
                     (length, unit) => length.ConvertTo(unit), (value, unit) => new Length(value, unit));
        }

        public static Area operator *(Length left, Length right)
        {
            return UnitedValuesUtils
                .Multiply<Length, LengthUnit, Length, LengthUnit, Area, AreaUnit>(
                    left, right,
                    (length, unit) => length.ConvertTo(unit), (value, unit) => new Area(value, unit));
        }

        public static Volume operator *(Length left, Area right)
        {
            return UnitedValuesUtils
               .Multiply<Length, LengthUnit, Area, AreaUnit, Volume, VolumeUnit>(
                   left, right,
                   (area, unit) => area.ConvertTo(unit), (value, unit) => new Volume(value, unit));
        }

        public static Volume operator *(Area left, Length right)
        {
            return UnitedValuesUtils
                .Multiply<Area, AreaUnit, Length, LengthUnit, Volume, VolumeUnit>(
                    left, right,
                    (length, unit) => length.ConvertTo(unit), (value, unit) => new Volume(value, unit));
        }


        public Length ConvertToMeter()
        {
            return ConvertTo(LengthUnits.Meter);
        }

    }
 
}