// ReSharper disable All
// generator: UnitJsonConverterGenerator
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class PressureJsonConverter : AbstractUnitJsonConverter<Pressure, PressureUnit>
    {
        protected override Pressure Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Pressure(value, string.IsNullOrEmpty(unit) ? Pressure.BaseUnit : new PressureUnit(unit));
        }

        protected override Pressure Parse(string txt)
        {
            return Pressure.Parse(txt);
        }

    }
}
