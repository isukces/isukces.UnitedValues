using Xunit;

namespace iSukces.UnitedValues.Test
{
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
    }
}
