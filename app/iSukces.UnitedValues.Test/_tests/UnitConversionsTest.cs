using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class UnitConversionsTest
    {
        [Fact]
        public void T01_Should_convert_kilometer_to_meter()
        {
            var c = new Length(3, LengthUnits.Km);
            var d = c.ConvertTo(LengthUnits.Meter);
            Assert.Equal(3000, d.Value);
            Assert.Equal("m", d.Unit.UnitName);
        }

        [Fact(Skip="Presure redefinition")]
        public void T02_Should_convert_counter_for_pressure()
        {
#if NEW_PASCAL
            var c = new Pressure(3, ForceUnits.KiloNewton, AreaUnits.SquareMeter);
            var d = c.WithCounterUnit(ForceUnits.Newton);
            Assert.Equal(3000, d.Value);
            Assert.Equal("N/m²", d.Unit.UnitName);
#endif
        }
        
        
        [Fact(Skip ="Presure redefinition")]
        public void T03_Should_convert_denominator_for_pressure()
        {
#if NEW_PASCAL
            var c = new Pressure(3, ForceUnits.KiloNewton, AreaUnits.SquareCm);
            var d = c.WithDenominatorUnit(AreaUnits.SquareMeter);
            Assert.Equal(30000, d.Value);
            Assert.Equal("kN/m²", d.Unit.UnitName);
#endif
        }
    }
}