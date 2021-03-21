// ReSharper disable All
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial class WeightJsonConverter : AbstractUnitJsonConverter<Weight, WeightUnit>
    {
        protected override Weight Make(decimal value, string unit)
        {
            unit = unit?.Trim();
            return new Weight(value, string.IsNullOrEmpty(unit) ? Weight.BaseUnit : new WeightUnit(unit));
        }

        protected override Weight Parse(string txt)
        {
            return Weight.Parse(txt);
        }

    }
}
