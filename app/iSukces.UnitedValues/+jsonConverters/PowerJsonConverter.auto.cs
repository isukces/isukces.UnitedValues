// ReSharper disable All
// generator: UnitJsonConverterGenerator
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class PowerJsonConverter : AbstractUnitJsonConverter<Power, PowerUnit>
    {
        protected override Power Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Power(value, string.IsNullOrEmpty(unit) ? Power.BaseUnit : new PowerUnit(unit));
        }

        protected override Power Parse(string txt)
        {
            return Power.Parse(txt);
        }

    }
}
