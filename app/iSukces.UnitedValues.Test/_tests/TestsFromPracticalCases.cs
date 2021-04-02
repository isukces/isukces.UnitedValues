using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class TestsFromPracticalCases
    {
        [Fact]
        public void T01_Should_calculate_pipe_diameter()
        {
            var tz = CelsiusTemperature.FromDegree(130);
            var tp = CelsiusTemperature.FromDegree(95);

            Assert.Equal("95°C", tp.ToString());

            // J/kg*K
            var cpUnit = new SpecificHeatCapacityUnit(
                    EnergyUnits.Joule,
                    MassUnits.Kg,
                    KelvinTemperatureUnits.Degree);
            var cp = new SpecificHeatCapacity(4211, cpUnit);

            Power q = Power.FromKiloWatt(300);
            Assert.Equal("300kW", q.ToString());

            var td = tz - tp;

            EnergyMassDensity a = cp * td;
            Assert.Equal("147385J/kg", a.ToString());

            var newUnit = new EnergyMassDensityUnit(
                EnergyUnits.KiloWattHour,
                MassUnits.Tone);
            a = a.ConvertTo(newUnit);
            Assert.Equal("40.9403kWh/t", a.Round(4).ToString());

            {
                // other mul order - result should be the same
                var a1 = td * cp;
                Assert.Equal("147385J/kg", a1.ToString());
            }
            // var m = q / a;
        }
    }
}