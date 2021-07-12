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


        /// <summary>
        ///     Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="pressure">rigth factor (multiplier)</param>
        public static Force operator *(Area area, Pressure pressure)
        {
            area     = area.ConvertTo(AreaUnits.SquareMeter);
            pressure = pressure.ConvertTo(PressureUnits.Pascal);
            return new Force(area.Value * pressure.Value, ForceUnits.Newton);
        }

        /// <summary>
        ///     Multiplication operation
        /// </summary>
        /// <param name="pressure">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Force operator *(Pressure pressure, Area area)
        {
            area     = area.ConvertTo(AreaUnits.SquareMeter);
            pressure = pressure.ConvertTo(PressureUnits.Pascal);
            return new Force(area.Value * pressure.Value, ForceUnits.Newton);
        }
        

        // Manual !!!!!!!!
        /*/// <summary>
        ///     Multiplication operation
        /// </summary>
        /// <param name="pressure">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static LinearForce operator *(Length length, Pressure pressure)
        {
            length   = length.ConvertTo(LengthUnits.Meter);
            pressure = pressure.ConvertTo(PressureUnits.Pascal);
            LinearForceUnit unit = new LinearForceUnit(ForceUnits.Newton, LengthUnits.Meter);
            return new LinearForce(length.Value * pressure.Value, unit);
        }*/
    }
}
