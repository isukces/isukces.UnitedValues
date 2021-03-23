// ReSharper disable All
// generator: UnitJsonConverterGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class KelvinTemperatureJsonConverter : AbstractUnitJsonConverter<KelvinTemperature, KelvinTemperatureUnit>
    {
        protected override KelvinTemperature Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new KelvinTemperature(value, string.IsNullOrEmpty(unit) ? KelvinTemperature.BaseUnit : new KelvinTemperatureUnit(unit));
        }

        protected override KelvinTemperature Parse(string txt)
        {
            return KelvinTemperature.Parse(txt);
        }

    }
}
