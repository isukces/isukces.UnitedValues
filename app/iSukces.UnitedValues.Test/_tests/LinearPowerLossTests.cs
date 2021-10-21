using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class LinearPowerLossTests
    {
        [Fact]
        public void T01_Should_create()
        {
            var ir = new LinearPowerLoss(34, PowerUnits.Watt, LengthUnits.Meter);
            Assert.Equal("34W/m", ir.ToString());

            ir = LinearPowerLoss.FromWattPerMeter(34);
            Assert.Equal("34W/m", ir.ToString());
        }
    }
}
