namespace iSukces.UnitedValues
{
    partial struct PressureDrop
    {
        public static PressureDrop FromPascalPerMeter(decimal value)
        {
            return new PressureDrop(value, PressureUnits.Pascal, LengthUnits.Meter);
        }
    }
}
