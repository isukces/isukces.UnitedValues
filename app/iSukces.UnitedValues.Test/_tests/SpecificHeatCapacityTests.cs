using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class SpecificHeatCapacityTests
    {
        [Fact]
        public void T01_Should_decompose_SpecificHeatCapacity_unit()
        {
            var specificHeatCapacity = new SpecificHeatCapacity(50,
                EnergyUnits.Joule, MassUnits.Kg, KelvinTemperatureUnits.Degree);
            var dec = specificHeatCapacity.Unit.Decompose();
            Assert.Equal(3, dec.Count);
            Assert.Equal("J", dec[0].ToString());
            Assert.Equal("kg^-1", dec[1].ToString());
            Assert.Equal("K^-1", dec[2].ToString());
        }

        [Fact]
        public void T02a_Should_div_EnergyMassDensity_by_SpecificHeatCapacity()
        {
            // public static DeltaKelvinTemperature operator /(EnergyMassDensity energyMassDensity, SpecificHeatCapacity specificHeatCapacity)
            var energyMassDensity = new EnergyMassDensity(200, EnergyUnits.Joule, MassUnits.Kg);
            var specificHeatCapacity = new SpecificHeatCapacity(50,
                EnergyUnits.Joule, MassUnits.Kg, KelvinTemperatureUnits.Degree);

            var d = energyMassDensity / specificHeatCapacity;
            Assert.Equal(4, d.Value);
            Assert.Equal("K", d.Unit.UnitName);
        }

        [Fact]
        public void T02b_Should_div_EnergyMassDensity_by_SpecificHeatCapacity()
        {
            // public static DeltaKelvinTemperature operator /(EnergyMassDensity energyMassDensity, SpecificHeatCapacity specificHeatCapacity)
            var energyMassDensity = new EnergyMassDensity(200, EnergyUnits.KiloJoule, MassUnits.Kg);
            var specificHeatCapacity = new SpecificHeatCapacity(50, EnergyUnits.Joule,
                MassUnits.Kg, KelvinTemperatureUnits.Degree);

            var d = energyMassDensity / specificHeatCapacity;
            Assert.Equal(4000, d.Value);
            Assert.Equal("K", d.Unit.UnitName);
        }
    }
}