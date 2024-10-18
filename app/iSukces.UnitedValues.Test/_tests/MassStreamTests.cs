using Xunit;

namespace iSukces.UnitedValues.Test;

public class MassStreamTests
{
    [Fact]
    public void T01_Should()
    {
        var stream = new MassStream(10, MassUnits.Kg, TimeUnits.Second);
        Assert.Equal("10kg/s", stream.ToString());

        stream = stream.WithDenominatorUnit(TimeUnits.Hour);
        Assert.Equal(
            new MassStream(36000, MassUnits.Kg, TimeUnits.Hour),
            stream);

        stream = stream.WithCounterUnit(MassUnits.Tone);
        Assert.Equal(
            new MassStream(36, MassUnits.Tone, TimeUnits.Hour),
            stream);
    }
}