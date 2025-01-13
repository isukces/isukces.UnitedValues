using Xunit;

namespace iSukces.UnitedValues.Test;

public class EnergyMassDensityTests
{
    [Fact]
    public void T01_Should_div_energy_by_mass()
    {
        var power   = Power.FromKiloWatt(30);
        var density = new EnergyMassDensity(15, EnergyUnits.KiloWattHour, MassUnits.Tone);
        var stream  = power / density;
        Assert.Equal(2, stream.Value);
        Assert.Equal("t/h", stream.Unit.UnitName);

        {
            var power1   = power.ConvertTo(PowerUnits.Watt);
            var density1 = density.ConvertTo(new EnergyMassDensityUnit(EnergyUnits.Joule, MassUnits.Kg));
            var stream1  = power1 / density1;
            Assert.Equal(0.555555555555555555555m, stream1.Value, 8);
            Assert.Equal("kg/s", stream1.Unit.UnitName);
            stream1 = stream1.ConvertTo(stream.Unit);
            Assert.Equal(2, stream1.Value);
        }
    }
}
