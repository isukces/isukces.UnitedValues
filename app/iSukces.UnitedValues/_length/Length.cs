namespace iSukces.UnitedValues
{
    public partial struct Length
    {
        public Length ConvertToMeter()
        {
            return ConvertTo(LengthUnits.Meter);
        }
    }
}