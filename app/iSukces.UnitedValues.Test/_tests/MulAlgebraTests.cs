using Xunit;

namespace iSukces.UnitedValues.Test
{
    [Collection("Algebra")]
    public class MulAlgebraTests
    {
        [Fact]
        public void T01_Should_divide_area_by_length()
        {
            var area     = Area.FromSquareKilometers(2);
            var length   = Length.FromMeter(10);
            var result   = area / length;
            var expected = Length.FromKilometers(200);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void T02_Should_multiply_km_by_m()
        {
            var kmLength    = Length.FromKilometers(200);
            var meterLength = Length.FromMeter(10);
            var result      = kmLength * meterLength;
            var area        = Area.FromSquareKilometers(2);
            Assert.Equal(area, result);
        }

        [Fact]
        public void T03_Should_multiply_m_by_km()
        {
            var kmLength    = Length.FromKilometers(200);
            var meterLength = Length.FromMeter(10);
            var result      = meterLength * kmLength;
            var area        = Area.FromSquareMeter(2_000_000);
            Assert.Equal(area, result);
        }


        [Fact]
        public void T04_Should_divide_newton_by_square_meter()
        {
            var force = new Force(8, ForceUnits.Newton);
            var area  = Area.FromSquareMeter(4);

            var result   = force / area;
            var expected = new Pressure(2, force.Unit, area.Unit);

            Assert.Equal(expected, result);
        }

        [Fact(Skip = "Pressure redefinition")]
        public void T05_Should_multiply_kilopascal_by_square_centimeter()
        {
            #if NEW_PRESSURE

            var pressure = new Pressure(2, ForceUnits.KiloNewton, AreaUnits.SquareMeter);
            var area     = Area.FromSquareCentimeters(4);
            var result   = pressure * area;

            var expected = new Force(0.0008m, ForceUnits.KiloNewton);
            Assert.Equal(expected, result);
            result   = result.ConvertTo(ForceUnits.Newton);
            expected = new Force(0.8m, ForceUnits.Newton);
            Assert.Equal(expected, result);

            #endif
        }
        
        [Fact]
        public void T06_Should_divide_kilonewton_by_pascal()
        {
            var force    = new Force(4, ForceUnits.KiloNewton);
            var pressure = new Pressure(2, ForceUnits.Newton, AreaUnits.SquareMeter);
            var area     = force / pressure;

            var expected = new Area(2000, AreaUnits.SquareMeter);
            Assert.Equal(expected, area);
        }
    }
}