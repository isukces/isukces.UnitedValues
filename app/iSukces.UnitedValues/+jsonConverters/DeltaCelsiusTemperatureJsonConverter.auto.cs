// ReSharper disable All
// generator: UnitJsonConverterGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class DeltaCelsiusTemperatureJsonConverter : AbstractUnitJsonConverter<DeltaCelsiusTemperature, CelsiusTemperatureUnit>
    {
        protected override DeltaCelsiusTemperature Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new DeltaCelsiusTemperature(value, string.IsNullOrEmpty(unit) ? DeltaCelsiusTemperature.BaseUnit : new CelsiusTemperatureUnit(unit));
        }

        protected override DeltaCelsiusTemperature Parse(string txt)
        {
            return DeltaCelsiusTemperature.Parse(txt);
        }

    }
}
