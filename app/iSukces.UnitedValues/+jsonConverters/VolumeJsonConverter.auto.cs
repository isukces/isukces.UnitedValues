// ReSharper disable All
using Newtonsoft.Json;
using System;
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
