// ReSharper disable All
// generator: UnitJsonConverterGenerator
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class SquareTimeJsonConverter : AbstractUnitJsonConverter<SquareTime, SquareTimeUnit>
    {
        protected override SquareTime Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new SquareTime(value, string.IsNullOrEmpty(unit) ? SquareTime.BaseUnit : new SquareTimeUnit(unit));
        }

        protected override SquareTime Parse(string txt)
        {
            return SquareTime.Parse(txt);
        }

    }
}
