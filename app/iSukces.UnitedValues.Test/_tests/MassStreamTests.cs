using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class MassStreamTests
    {
        [Fact]
        public void T01_Should()
        {
            var stream = new MassStream(10, WeightUnits.Kg, TimeUnits.Second);
            Assert.Equal("10kg/s", stream.ToString());

            stream = stream.WithDenominatorUnit(TimeUnits.Hour);
            Assert.Equal(
                new MassStream(36000, WeightUnits.Kg, TimeUnits.Hour),
                stream);

            stream = stream.WithCounterUnit(WeightUnits.Tone);
            Assert.Equal(
                new MassStream(36, WeightUnits.Tone, TimeUnits.Hour),
                stream);
        }
    }
}