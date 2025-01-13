using Xunit;

namespace iSukces.UnitedValues.Test;

public class LinearDensityTests
{
    [Fact]
    public void T01_Should_div_LinearDensity_by_Length()
    {
        //  PlanarDensity operator /(LinearDensity linearDensity, Length length)
        var linearDensity = new LinearDensity(20, MassUnits.Kg, LengthUnits.Meter);
        var length        = Length.FromCentimeters(200);
        var result        = linearDensity / length;
        Assert.Equal(10m, result.Value);
        Assert.Equal("kg/m²", result.Unit.UnitName);
    }

    [Fact]
    public void T02_Should_LinearDensity_by_PlanarDensity()
    {
        //  Length operator /(LinearDensity linearDensity, PlanarDensity planarDensity)
        var linearDensity = new LinearDensity(20, MassUnits.Kg, LengthUnits.Meter);
        var planarDensity = new PlanarDensity(10, MassUnits.Kg, AreaUnits.SquareMeter);
        var result        = linearDensity / planarDensity;
        Assert.Equal(2, result.Value);
        Assert.Equal("m", result.Unit.UnitName);
    }
}
