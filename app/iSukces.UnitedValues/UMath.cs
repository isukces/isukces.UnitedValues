using System;

namespace iSukces.UnitedValues;

public static class UMath
{
    public static Area Sqr(this Length value)
    {
        var resultUnit  = GlobalUnitRegistry.Relations.GetOrThrow<LengthUnit, AreaUnit>(value.Unit);
        var resultValue = value.Value * value.Value;
        return new Area(resultValue, resultUnit);
    }

    public static SquareTime Sqr(this Time value)
    {
        var resultUnit  = GlobalUnitRegistry.Relations.GetOrThrow<TimeUnit, SquareTimeUnit>(value.Unit);
        var resultValue = value.Value * value.Value;
        return new SquareTime(resultValue, resultUnit);
    }

    public static Length Sqrt(this Area value)
    {
        var resultUnit  = GlobalUnitRegistry.Relations.GetOrThrow<AreaUnit, LengthUnit>(value.Unit);
        var resultValue = (decimal)Math.Sqrt((double)value.Value);
        return new Length(resultValue, resultUnit);
    }

    public static Time Sqrt(this SquareTime value)
    {
        var resultUnit  = GlobalUnitRegistry.Relations.GetOrThrow<SquareTimeUnit, TimeUnit>(value.Unit);
        var resultValue = (decimal)Math.Sqrt((double)value.Value);
        return new Time(resultValue, resultUnit);
    }
}