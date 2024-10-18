using Xunit;

namespace iSukces.UnitedValues.Test;

public class InversedTemperatureTests
{
    [Fact]
    public void T01_should_inverse_Kelvin()
    {
        var c = new DeltaKelvinTemperature(10, KelvinTemperatureUnits.Degree);
        c = DeltaKelvinTemperature.FromDegree(10);
        Assert.Equal("10K", c.ToString());
        var d = 1 / c;

        Assert.Equal(0.1m, d.Value);
        Assert.Equal("1/K", d.Unit.UnitName);
    }
}