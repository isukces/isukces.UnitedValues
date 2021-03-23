using System;

namespace iSukces.UnitedValues
{
    public partial struct DeltaCelsiusTemperature
    {
        public static implicit operator DeltaCelsiusTemperature(DeltaKelvinTemperature temp)
        {
            if (temp.Unit == KelvinTemperatureUnits.Degree)
                return new DeltaCelsiusTemperature(temp.Value, CelsiusTemperatureUnits.Degree);
            throw new NotSupportedException(
                CelsiusTemperature.MakeMessage(temp, Kelvin, Celsius));
        }

        public static implicit operator DeltaKelvinTemperature(DeltaCelsiusTemperature temp)
        {
            if (temp.Unit == CelsiusTemperatureUnits.Degree)
                return new DeltaKelvinTemperature(temp.Value, KelvinTemperatureUnits.Degree);
            throw new NotSupportedException(
                CelsiusTemperature.MakeMessage(temp, Celsius, Kelvin));
        }

        private const string Celsius = "Celsius temperature difference";
        private const string Kelvin = "Kelvin temperature difference";
    }
}