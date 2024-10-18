using Xunit;

namespace iSukces.UnitedValues.Test;

public class SampleValues
{
    [Fact]
    public void T01_Should_create()
    {
        // kiloWatt
        var power        = Power.FromKiloWatt(123);
        var theSamePower = new Power(123, PowerUnits.KiloWatt);
        // Temperature
        var tempC = CelsiusTemperature.FromDegree(23);
        var tempK = KelvinTemperature.FromDegree(300);
        // length
        var meters    = Length.FromMeter(10);
        var miliMeter = Length.FromMilimeters(45);
        // density kg/m³
        var density = new Density(23, MassUnits.Kg, VolumeUnits.CubicMeter);
        // stream [m³/s] [m³/h]
        var stream1 = new VolumeStream(34, VolumeUnits.CubicMeter, TimeUnits.Second);
        var stream2 = new VolumeStream(34, VolumeUnits.CubicMeter, TimeUnits.Hour);
        // [J/kg*K] is supported
        // [kJ/kg*C] is not supported
        var specificHeatCapacityUnit = new SpecificHeatCapacityUnit(
            EnergyUnits.Joule,
            MassUnits.Kg,
            KelvinTemperatureUnits.Degree);
        var waterSpecificHeatCapacity = new SpecificHeatCapacity(4211, specificHeatCapacityUnit);


        var velocity1 = Velocity.FromMeterPerSecond(12);
        var velocity2 = new Velocity(2, LengthUnits.Feet, TimeUnits.Minute);

        var pressure = new Pressure(123, PressureUnits.KiloPascal);
    }
}