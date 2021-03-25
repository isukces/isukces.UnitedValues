using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class WeightUnitTests
    {
        [Fact]
        public void T01_Should_trim_parsed_unit()
        {
            var w  = new MassUnit("kg");
            var w2 = new MassUnit(" kg ");
            Assert.Equal(w, w2);
        }
    }
}