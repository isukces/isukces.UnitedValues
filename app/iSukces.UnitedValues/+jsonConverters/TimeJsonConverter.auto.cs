// ReSharper disable All
// generator: UnitJsonConverterGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class TimeJsonConverter : AbstractUnitJsonConverter<Time, TimeUnit>
    {
        protected override Time Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Time(value, string.IsNullOrEmpty(unit) ? Time.BaseUnit : new TimeUnit(unit));
        }

        protected override Time Parse(string txt)
        {
            return Time.Parse(txt);
        }

    }
}
