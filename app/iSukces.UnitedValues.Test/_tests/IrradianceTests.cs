using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class IrradianceTests
    {
        [Fact]
        public void T01_Should_create()
        {
            var ir = new Irradiance(34, PowerUnits.Watt, AreaUnits.SquareMeter);
            Assert.Equal("34W/m²",ir.ToString());


            ir = Irradiance.FromWattPerSquareMeter(34);
            Assert.Equal("34W/m²",ir.ToString());

        }
    }
}
