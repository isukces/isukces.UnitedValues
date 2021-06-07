namespace iSukces.UnitedValues
{
    partial struct Force
    {
        /// <summary>
        ///     Multiplication operation
        /// </summary>
        /// <param name="force">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Pressure operator /(Force force, Area area)
        {
            area  = area.ConvertTo(AreaUnits.SquareMeter);
            force = force.ConvertTo(ForceUnits.Newton);
            return new Pressure(force.Value / area.Value, PressureUnits.Pascal);
        }

        /// <summary>
        ///     Multiplication operation
        /// </summary>
        /// <param name="force">left factor (multiplicand)</param>
        /// <param name="pressure">rigth factor (multiplier)</param>
        public static Area operator /(Force force, Pressure pressure)
        {
            pressure = pressure.ConvertTo(PressureUnits.Pascal);
            force    = force.ConvertTo(ForceUnits.Newton);
            return new Area(force.Value / pressure.Value, AreaUnits.SquareMeter);
        }
    }
}
