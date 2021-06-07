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
    }
}
