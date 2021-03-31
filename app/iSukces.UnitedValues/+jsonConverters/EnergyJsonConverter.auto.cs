// ReSharper disable All
// generator: UnitJsonConverterGenerator
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class EnergyJsonConverter : AbstractUnitJsonConverter<Energy, EnergyUnit>
    {
        protected override Energy Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Energy(value, string.IsNullOrEmpty(unit) ? Energy.BaseUnit : new EnergyUnit(unit));
        }

        protected override Energy Parse(string txt)
        {
            return Energy.Parse(txt);
        }

    }
}
