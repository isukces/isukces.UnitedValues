namespace iSukces.UnitedValues
{
    public partial struct Pressure
    {
        public Pressure(decimal value, ForceUnit force, AreaUnit area)
        {
            var areaSqM = new Area(1, area).ConvertTo(AreaUnits.SquareMeter);
            Unit  = PressureUnits.Pascal;
            Value = value / areaSqM.Value;
        }


    }
}
