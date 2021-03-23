using System;

namespace iSukces.UnitedValues
{
    public partial struct CelsiusTemperature
    {
        public static string MakeMessage<T>(IUnitedValue<T> temp, string a, string b)
            where T : IUnit, IEquatable<T>
        {
            return $"Unable to convert {a} in {temp.Unit} into {b}.";
        }

        public static implicit operator CelsiusTemperature(KelvinTemperature temp)
        {
            if (temp.Unit == KelvinTemperatureUnits.Degree)
                return FromDegree(temp.Value + AbsoluteZeroValue);
            throw new NotSupportedException(
                MakeMessage(temp, Kelvin, Celsius));
        }

        public static implicit operator KelvinTemperature(CelsiusTemperature temp)
        {
            if (temp.Unit == CelsiusTemperatureUnits.Degree)
                return FromDegree(temp.Value - AbsoluteZeroValue);
            throw new NotSupportedException(
                MakeMessage(temp, Celsius, Kelvin));
        }

        public static CelsiusTemperature AbsoluteZero = FromDegree(AbsoluteZeroValue);
        private const string Celsius = "Celsius temperature";
        private const string Kelvin = "Kelvin temperature";

        private const decimal AbsoluteZeroValue = -273.15m;
        
         
    }
}