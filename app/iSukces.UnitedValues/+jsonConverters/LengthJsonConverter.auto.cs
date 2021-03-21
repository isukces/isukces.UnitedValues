// ReSharper disable All
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class LengthJsonConverter : AbstractUnitJsonConverter<Length, LengthUnit>
    {
        protected override Length Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Length(value, string.IsNullOrEmpty(unit) ? Length.BaseUnit : new LengthUnit(unit));
        }

        protected override Length Parse(string txt)
        {
            return Length.Parse(txt);
        }

    }
}
