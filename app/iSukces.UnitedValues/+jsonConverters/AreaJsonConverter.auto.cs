// ReSharper disable All
// generator: UnitJsonConverterGenerator
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class AreaJsonConverter : AbstractUnitJsonConverter<Area, AreaUnit>
    {
        protected override Area Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Area(value, string.IsNullOrEmpty(unit) ? Area.BaseUnit : new AreaUnit(unit));
        }

        protected override Area Parse(string txt)
        {
            return Area.Parse(txt);
        }

    }
}
