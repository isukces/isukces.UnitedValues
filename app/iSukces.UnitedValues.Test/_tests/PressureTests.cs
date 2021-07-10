using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class PressureTests
    {
        [Fact]
        public void T01_Should_create_pressure_drop()
        {
            var p  = Pressure.FromKiloPascal(12);
            var pd = new PressureDrop(1.5m, PressureUnits.Pascal, LengthUnits.Meter);

            var pd1 = PressureDrop.FromPascalPerMeter(13.4m);
            Assert.Equal(PressureUnits.Pascal, pd1.Unit.CounterUnit);
            Assert.Equal(LengthUnits.Meter, pd1.Unit.DenominatorUnit);
        }


        [Fact]
        public void T02_Should_multiply_length_and_pressure()
        {
            Length   dzp      = Length.FromMeter(10);
            Pressure pressure = Pressure.FromKiloPascal(12);
            var      mul      = pressure * dzp;
            Assert.Equal(120000, mul.Value);
            Assert.Equal("N", mul.Unit.CounterUnit.UnitName);
            Assert.Equal("m", mul.Unit.DenominatorUnit.UnitName);
        }


        [Fact]
        public void T03_Should_multiply_length_and_pressure()
        {
            Length   dzp      = Length.FromMeter(10).ConvertTo(LengthUnits.Dm);
            Pressure pressure = Pressure.FromKiloPascal(12);
            var      mul      = pressure * dzp;
            Assert.Equal(120000, mul.Value);
            Assert.Equal("N", mul.Unit.CounterUnit.UnitName);
            Assert.Equal("m", mul.Unit.DenominatorUnit.UnitName);
        }
    }
}
