using System.Collections.Generic;
using Xunit;

namespace iSukces.UnitedValues.Test
{
    public class PowerAndEnergyTests
    {
        [Fact]
        public void T01_Should_calulate_power_from_energy_and_time()
        {
            var energy = Energy.FromJoule(60);
            var time   = Time.FromSecond(3);
            var power  = energy / time;
            Assert.Equal(20, power.Value);
            Assert.Equal("W", power.Unit.UnitName);
        }
        
        [Fact]
        public void T02_Should_calulate_power_from_energy_and_time()
        {
            var energy = Energy.FromJoule(60).ConvertTo(EnergyUnits.KiloWattHour);
            var time   = Time.FromSecond(3);
            var power  = energy / time;
            Assert.Equal("kW", power.Unit.UnitName);
            power = power.ConvertTo(PowerUnits.Watt);
            Assert.Equal(20, power.Value, 8);
        }
        
        [Fact]
        public void T03_Should_calulate_power_from_energy_and_time()
        {
            var energy = Energy.FromJoule(60).ConvertTo(EnergyUnits.KiloWattHour);
            var time   = Time.FromSecond(3).ConvertTo(TimeUnits.Minute);
            var power  = energy / time;
            Assert.Equal("kW", power.Unit.UnitName);
            power = power.ConvertTo(PowerUnits.Watt);
            Assert.Equal(20, power.Value, 8);
        }

        [Fact]
        public void T04_Should_calulate_power_from_energy_and_time()
        {
            var energy = Energy.FromJoule(60).ConvertTo(EnergyUnits.KiloCalorie);
            var time   = Time.FromSecond(3).ConvertTo(TimeUnits.Minute);
            var power  = energy / time;
            Assert.Equal("W", power.Unit.UnitName);
            //power = power.ConvertTo(PowerUnits.Watt);
            Assert.Equal(20, power.Value, 8);
        }

    }
}