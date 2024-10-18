using Xunit;

namespace iSukces.UnitedValues.Test;

public class ThermalResistanceTests
{
    [Fact]
    public void T01_Should_calculate_inverse()
    {
        var res = ThermalResistance.FromMeterKelvinPerWatt(2);
        var tos = res.ToString();
        Assert.Equal("2m*K/W", tos);

        var rev = 1 / res;
        Assert.Equal("0.5W/(m*K)", rev.ToString());
    }


    [Fact]
    public void T02_Should_calculate_inverse()
    {
        var res = ThermalConductivity.FromWattPerMeterKelvin(2);
        var tos = res.ToString();
        Assert.Equal("2W/(m*K)", tos);

        var rev = 1 / res;
        Assert.Equal("0.5m*K/W", rev.ToString());
    }


    [Fact]
    public void T03a_Should_sum_ThermalResistance()
    {
        var res1 = ThermalResistance.FromMeterKelvinPerWatt(3);
        var res2 = ThermalResistance.FromMeterKelvinPerWatt(2);
        var res  = res1 + res2;
        Assert.Equal("5m*K/W", res.ToString());
    }


    [Fact]
    public void T03b_Should_sum_ThermalResistance()
    {
        var res1 = ThermalResistance.FromMeterKelvinPerWatt(3);
        var res2 = new ThermalResistance(200, new ThermalResistanceUnit(LengthUnits.Cm, PowerUnits.Watt));
        var res  = res1 + res2;
        Assert.Equal(5m, res.Value);
        Assert.Equal("m*K/W", res.Unit.ToString());
    }

    [Fact]
    public void T03c_Should_sum_ThermalResistance()
    {
        var res1 = ThermalResistance.FromMeterKelvinPerWatt(3);
        var res2 = new ThermalResistance(2000, new ThermalResistanceUnit(LengthUnits.Meter, PowerUnits.KiloWatt));
        var res  = res1 + res2;
        Assert.Equal(5m, res.Value);
        Assert.Equal("m*K/W", res.Unit.ToString());
    }

    [Fact]
    public void T04a_Should_sub_ThermalResistance()
    {
        var res1 = ThermalResistance.FromMeterKelvinPerWatt(3);
        var res2 = ThermalResistance.FromMeterKelvinPerWatt(2);
        var res  = res1 - res2;
        Assert.Equal("1m*K/W", res.ToString());
    }
        
    [Fact]
    public void T04b_Should_sub_ThermalResistance()
    {
        var res1 = ThermalResistance.FromMeterKelvinPerWatt(3);
        var res2 = new ThermalResistance(200, new ThermalResistanceUnit(LengthUnits.Cm, PowerUnits.Watt));
        var res  = res1 - res2;
        Assert.Equal(1m, res.Value);
        Assert.Equal("m*K/W", res.Unit.ToString());
    }

    [Fact]
    public void T04c_Should_sub_ThermalResistance()
    {
        var res1 = ThermalResistance.FromMeterKelvinPerWatt(3);
        var res2 = new ThermalResistance(2000, new ThermalResistanceUnit(LengthUnits.Meter, PowerUnits.KiloWatt));
        var res  = res1 - res2;
        Assert.Equal(1m, res.Value);
        Assert.Equal("m*K/W", res.Unit.ToString());
    }
}