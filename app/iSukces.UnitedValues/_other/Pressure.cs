namespace iSukces.UnitedValues
{
    public partial struct Pressure
    {
        public Pressure(decimal value, ForceUnit force, AreaUnit area)
        {
            var areaValue = new Area(1, area)
                .ConvertTo(AreaUnits.SquareMeter);
            var forceValue = new Force(value, force)
                .ConvertTo(ForceUnits.Newton);
            Value = forceValue.Value / areaValue.Value;

            Unit = PressureUnits.Pascal;
        }
    }
}
