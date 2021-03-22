using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class MulAlgebraTests
    {
        [Fact]
        public void T01_Should_divide_area_by_length()
        {
            var area     = Area.FromKm(2);
            var length   = Length.FromMeter(10);
            var result   = area / length;
            var expected = Length.FromKm(200);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void T02_Should_multiply_km_by_m()
        {
            var kmLength    = Length.FromKm(200);
            var meterLength = Length.FromMeter(10);
            var result      = kmLength * meterLength;
            var area        = Area.FromKm(2);
            Assert.Equal(area, result);
        }

        [Fact]
        public void T03_Should_multiply_m_by_km()
        {
            var kmLength    = Length.FromKm(200);
            var meterLength = Length.FromMeter(10);
            var result      = meterLength * kmLength;
            var area        = Area.FromMeter(2_000_000);
            Assert.Equal(area, result);
        }
    }
}