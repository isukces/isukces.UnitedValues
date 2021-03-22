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
    }

    partial class AreaUnits
    {
        public const string SquareSign = "²";
    }
}