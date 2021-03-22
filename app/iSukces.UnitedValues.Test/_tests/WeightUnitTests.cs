using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class WeightUnitTests
    {
        [Fact]
        public void T01_Should_trim_parsed_unit()
        {
            var w  = new WeightUnit("kg");
            var w2 = new WeightUnit(" kg ");
            Assert.Equal(w, w2);
        }
    }
}