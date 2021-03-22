using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class UnitExchangeFactorsTest
    {
        [Fact]
        public void T01_ShouldConvertLength()
        {
            var a = GlobalUnitRegistry.Factors.Get<LengthUnit>("yd");
            Assert.NotNull(a);
            Assert.Equal(0.9144m, a.Value);
        }
    }
}