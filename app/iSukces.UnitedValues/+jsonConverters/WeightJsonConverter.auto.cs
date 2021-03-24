// ReSharper disable All
// generator: UnitJsonConverterGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class WeightJsonConverter : AbstractUnitJsonConverter<Mass, WeightUnit>
    {
        protected override Mass Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Mass(value, string.IsNullOrEmpty(unit) ? Mass.BaseUnit : new WeightUnit(unit));
        }

        protected override Mass Parse(string txt)
        {
            return Mass.Parse(txt);
        }

    }
}
