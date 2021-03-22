// ReSharper disable All
// generator: UnitJsonConverterGenerator
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class ForceJsonConverter : AbstractUnitJsonConverter<Force, ForceUnit>
    {
        protected override Force Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Force(value, string.IsNullOrEmpty(unit) ? Force.BaseUnit : new ForceUnit(unit));
        }

        protected override Force Parse(string txt)
        {
            return Force.Parse(txt);
        }

    }
}
