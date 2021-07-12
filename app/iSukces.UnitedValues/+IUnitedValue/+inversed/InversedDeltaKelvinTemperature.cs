namespace iSukces.UnitedValues
{
    public partial struct InversedDeltaKelvinTemperature
    {
        /// <summary>
        ///     implements * operator
        /// </summary>
        /// <param name="delta"></param>
        /// <param name="value"></param>
        public static decimal operator *(DeltaCelsiusTemperature delta, InversedDeltaKelvinTemperature value)
        {
            return delta.Value * value.Value;
        }

        /// <summary>
        ///     implements * operator
        /// </summary>
        /// <param name="delta"></param>
        /// <param name="value"></param>
        public static decimal operator *(InversedDeltaKelvinTemperature value, DeltaCelsiusTemperature delta)
        {
            return delta.Value * value.Value;
        }

        public static InversedDeltaKelvinTemperature FromDegree(decimal value)
        {
            var unit = InversedKelvinTemperatureUnits.DegreeInversedKelvinTemperatureUnit;
            return new InversedDeltaKelvinTemperature(value, unit);
        }
    }
}
