// ReSharper disable All
// generator: UnitJsonConverterGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class CelsiusTemperatureJsonConverter : AbstractUnitJsonConverter<CelsiusTemperature, CelsiusTemperatureUnit>
    {
        protected override CelsiusTemperature Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new CelsiusTemperature(value, string.IsNullOrEmpty(unit) ? CelsiusTemperature.BaseUnit : new CelsiusTemperatureUnit(unit));
        }

        protected override CelsiusTemperature Parse(string txt)
        {
            return CelsiusTemperature.Parse(txt);
        }

    }
}
