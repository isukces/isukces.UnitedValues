using System;

namespace iSukces.UnitedValues
{
    public partial struct Area
    {
        public Area ConvertToMeter()
        {
            return ConvertTo(AreaUnits.SquareMeter);
        }


        public Area RoundSquareMeter(int decimalPlaces)
        {
            return ConvertToMeter().Round(decimalPlaces);
        }

        public Length GetCircleRadius()
        {
            var u = Unit.GetLengthUnit();
            var r = Math.Sqrt((double)Value / Math.PI);
            return new Length((decimal)r, u);
        }

        public Length GetCircleDiameter()
        {
            return 2 * GetCircleRadius();
        }
    }

    partial class AreaUnits
    {
        public const string SquareSign = "²";
    }
}