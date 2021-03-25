// ReSharper disable All
// generator: UnitJsonConverterGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class MassJsonConverter : AbstractUnitJsonConverter<Mass, MassUnit>
    {
        protected override Mass Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Mass(value, string.IsNullOrEmpty(unit) ? Mass.BaseUnit : new MassUnit(unit));
        }

        protected override Mass Parse(string txt)
        {
            return Mass.Parse(txt);
        }

    }
}
