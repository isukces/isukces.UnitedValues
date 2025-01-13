using Xunit;

namespace iSukces.UnitedValues.Test;

public class IrradianceAndLinearPowerLossTests
{
    [Fact]
    public void T01_Should_create_Irradiance()
    {
        var irradiance = new Irradiance(34, PowerUnits.Watt, AreaUnits.SquareMeter);
        Assert.Equal("34W/m²", irradiance.ToString());

        irradiance = Irradiance.FromWattPerSquareMeter(34);
        Assert.Equal("34W/m²", irradiance.ToString());
    }


    [Fact]
    public void T02_Should_create_LinearPowerLoss()
    {
        var ir = new LinearPowerLoss(34, PowerUnits.Watt, LengthUnits.Meter);
        Assert.Equal("34W/m", ir.ToString());

        ir = LinearPowerLoss.FromWattPerMeter(34);
        Assert.Equal("34W/m", ir.ToString());
    }

    [Fact]
    public void T03_Should_mul_Irradiance_Area()
    {
        var loss   = Irradiance.FromWattPerSquareMeter(5);
        var length = Area.FromSquareMeter(2);
        var power  = loss * length;
        Assert.Equal("10W", power.ToString());
    }


    [Fact]
    public void T04_Should_mul_Irradiance_Length()
    {
        var irradiance = Irradiance.FromWattPerSquareMeter(5);
        var length     = Length.FromMeter(2);
        var loss       = irradiance * length;
        Assert.Equal("10W/m", loss.ToString());
    }

    [Fact]
    public void T05_Should_mul_LinearPowerLoss_Length()
    {
        var loss   = LinearPowerLoss.FromWattPerMeter(5);
        var length = Length.FromMeter(2);
        var power  = loss * length;
        Assert.Equal("10W", power.ToString());
    }

    [Fact]
    public void T06_Should_divide_Power_Area()
    {
        var power  = Power.FromWatt(10);
        var length = Area.FromSquareMeter(2);
        var loss   = power / length;
        Assert.Equal("5W/m²", loss.ToString());
    }

    [Fact]
    public void T07_Should_divide_Power_Length()
    {
        var power  = Power.FromWatt(10);
        var length = Length.FromMeter(2);
        var loss   = power / length;
        Assert.Equal("5W/m", loss.ToString());
    }
}
