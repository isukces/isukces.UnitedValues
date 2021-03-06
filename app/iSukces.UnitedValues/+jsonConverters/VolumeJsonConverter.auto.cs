// ReSharper disable All
// generator: UnitJsonConverterGenerator
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class VolumeJsonConverter : AbstractUnitJsonConverter<Volume, VolumeUnit>
    {
        protected override Volume Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Volume(value, string.IsNullOrEmpty(unit) ? Volume.BaseUnit : new VolumeUnit(unit));
        }

        protected override Volume Parse(string txt)
        {
            return Volume.Parse(txt);
        }

    }
}
