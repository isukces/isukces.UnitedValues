using System;

namespace isukces.UnitedValues
{
    public partial struct Area
    {
        public static Area FromKm(decimal m) => new Area(m, AreaUnits.SquareKm);
        public static Area FromKm(long m) => new Area(m, AreaUnits.SquareKm);
        public static Area FromKm(double m) => new Area((decimal)m, AreaUnits.SquareKm);


        public static Area FromMeter(decimal m) => new Area(m, AreaUnits.SquareMeter);
        public static Area FromMeter(long m) => new Area(m, AreaUnits.SquareMeter);
        public static Area FromMeter(double m) => new Area((decimal)m, AreaUnits.SquareMeter);


        public Area ConvertToMeter()
        {
            return ConvertTo(AreaUnits.SquareMeter);
        }


        public Area RoundKg(Area w, int decimalPlaces)
        {
            return FromMeter(Math.Round(w.Value, decimalPlaces));
        }
    }

    partial class AreaUnits
    {
        public const string Square = "²";
    }
}