using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class TestsFromPracticalCases
    {
        [Fact]
        public void T01_Should_calculate_pipe_diameter()
        {
            var tempSupply = CelsiusTemperature.FromDegree(130);
            var tempReturn = CelsiusTemperature.FromDegree(95);

            Assert.Equal("95°C", tempReturn.ToString());

            // J/kg*K
            var waterSpecificHeatCapacity = new SpecificHeatCapacityUnit(
                EnergyUnits.Joule,
                MassUnits.Kg,
                KelvinTemperatureUnits.Degree);
            var cp = new SpecificHeatCapacity(4211, waterSpecificHeatCapacity);

            var requestedPower = Power.FromKiloWatt(300);
            Assert.Equal("300kW", requestedPower.ToString());

            var tempDifference = tempSupply - tempReturn;

            var energyDensity = cp * tempDifference;
            Assert.Equal("147385J/kg", energyDensity.ToString());

            var newUnit       = EnergyMassDensityUnits.KiloWattHourPerTone;
            energyDensity = energyDensity.ConvertTo(newUnit);
            Assert.Equal("40.9403kWh/t", energyDensity.Round(4).ToString());

            {
                // other mul order - result should be the same
                var a1 = tempDifference * cp;
                Assert.Equal("147385J/kg", a1.ToString());
            }

            // ============ mass stream
            var massStream = requestedPower / energyDensity;
            Assert.Equal(7.3277470570275129762187468138m, massStream.Value, 10);
            Assert.Equal("t/h", massStream.Unit.UnitName);

            var waterDensity = new Density(961.9m, MassUnits.Kg, VolumeUnits.CubicMeter);
            var volumeStream  = massStream / waterDensity;

            Assert.Equal(7.6179925741007516126611360992m, volumeStream.Value, 10);
            Assert.Equal("m³/h", volumeStream.Unit.UnitName);

            //var liquidSpeed = new Velocity(1, LengthUnits.Meter, TimeUnits.Second);
            var liquidSpeed = Velocity.FromMeterPerSecond(1);
            Assert.Equal(1, liquidSpeed.Value, 10);
            Assert.Equal("m/s", liquidSpeed.Unit.UnitName);


            var pipeArea = volumeStream / liquidSpeed;
            Assert.Equal(0.0021161090483613198924058713m, pipeArea.Value, 10);
            Assert.Equal("m²", pipeArea.Unit.UnitName);

            var diameter = pipeArea.GetCircleDiameter();
            Assert.Equal(0.0519067791463266m, diameter.Value, 10);
            Assert.Equal("m", diameter.Unit.UnitName);

            diameter = diameter.ConvertTo(LengthUnits.Mm);
            Assert.Equal(51.9067791463266m, diameter.Value, 10);
        }
        
        
    }
}