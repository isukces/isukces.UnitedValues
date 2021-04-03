namespace iSukces.UnitedValues
{
    partial struct Velocity
    {
        /// <summary>
        /// From m/s
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Velocity FromMeterPerSecond(decimal value)
        {
            return new Velocity(value, LengthUnits.Meter, TimeUnits.Second);
        }
    }
}