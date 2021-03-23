// ReSharper disable All
// generator: UnitJsonConverterGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class DeltaKelvinTemperatureJsonConverter : AbstractUnitJsonConverter<DeltaKelvinTemperature, KelvinTemperatureUnit>
    {
        protected override DeltaKelvinTemperature Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new DeltaKelvinTemperature(value, string.IsNullOrEmpty(unit) ? DeltaKelvinTemperature.BaseUnit : new KelvinTemperatureUnit(unit));
        }

        protected override DeltaKelvinTemperature Parse(string txt)
        {
            return DeltaKelvinTemperature.Parse(txt);
        }

    }
}
