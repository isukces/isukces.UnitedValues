using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;


// char test ² ąćęłńóśźż
namespace iSukces.UnitedValues.Test;

public class DivTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public DivTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    // ===================== LOOP

        
    [Fact]
    public void T01_should_mul_density_by_volumeStream() {
        // density(Kg,CubicMeter) * volumeStream(CubicMeter,Second) = massStream(Kg,Second)
        var left     = new Density(30m, MassUnits.Kg, VolumeUnits.CubicMeter);
        var right    = new VolumeStream(15m, VolumeUnits.CubicMeter, TimeUnits.Second);
        var expected = new MassStream(450m, MassUnits.Kg, TimeUnits.Second);
        var result   = left * right;
        _testOutputHelper.WriteLine("Check if " + left + " * " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

    // Reverse order multiplication
    [Fact]
    public void T02_should_mul_volumeStream_by_density() {
        // volumeStream(CubicMeter,Second) * density(Kg,CubicMeter) = massStream(Kg,Second)
        var left     = new VolumeStream(15m, VolumeUnits.CubicMeter, TimeUnits.Second);
        var right    = new Density(30m, MassUnits.Kg, VolumeUnits.CubicMeter);
        var expected = new MassStream(450m, MassUnits.Kg, TimeUnits.Second);
        var result   = left * right;
        _testOutputHelper.WriteLine("Check if " + left + " * " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

    // Division 1 made from multiplication
    [Fact]
    public void T03_should_div_massStream_by_density() {
        // massStream(Kg,Second) / density(Kg,CubicMeter) = volumeStream(CubicMeter,Second)
        var left     = new MassStream(450m, MassUnits.Kg, TimeUnits.Second);
        var right    = new Density(30m, MassUnits.Kg, VolumeUnits.CubicMeter);
        var expected = new VolumeStream(15m, VolumeUnits.CubicMeter, TimeUnits.Second);
        var result   = left / right;
        _testOutputHelper.WriteLine("Check if " + left + " / " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

    // Division 2 made from multiplication
    [Fact]
    public void T04_should_div_massStream_by_volumeStream() {
        // massStream(Kg,Second) / volumeStream(CubicMeter,Second) = density(Kg,CubicMeter)
        var left     = new MassStream(450m, MassUnits.Kg, TimeUnits.Second);
        var right    = new VolumeStream(15m, VolumeUnits.CubicMeter, TimeUnits.Second);
        var expected = new Density(30m, MassUnits.Kg, VolumeUnits.CubicMeter);
        var result   = left / right;
        _testOutputHelper.WriteLine("Check if " + left + " / " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

        
    [Fact]
    public void T05_should_mul_density_by_volumeStream() {
        // density(Pound,CubicInch) * volumeStream(CubicInch,Second) = massStream(Pound,Second)
        var left     = new Density(30m, MassUnits.Pound, VolumeUnits.CubicInch);
        var right    = new VolumeStream(15m, VolumeUnits.CubicInch, TimeUnits.Second);
        var expected = new MassStream(450m, MassUnits.Pound, TimeUnits.Second);
        var result   = left * right;
        _testOutputHelper.WriteLine("Check if " + left + " * " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

    // Reverse order multiplication
    [Fact]
    public void T06_should_mul_volumeStream_by_density() {
        // volumeStream(CubicInch,Second) * density(Pound,CubicInch) = massStream(Pound,Second)
        var left     = new VolumeStream(15m, VolumeUnits.CubicInch, TimeUnits.Second);
        var right    = new Density(30m, MassUnits.Pound, VolumeUnits.CubicInch);
        var expected = new MassStream(450m, MassUnits.Pound, TimeUnits.Second);
        var result   = left * right;
        _testOutputHelper.WriteLine("Check if " + left + " * " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

        
    [Fact]
    public void T07_should_div_massStream_by_density() {
        // massStream(Tone,Second) / density(Pound,CubicInch) = volumeStream(CubicInch,Second)
        var left     = new MassStream(450m, MassUnits.Tone, TimeUnits.Second);
        var right    = new Density(30m, MassUnits.Pound, VolumeUnits.CubicInch);
        var expected = new VolumeStream(33069.339327731637108446070202m, VolumeUnits.CubicInch, TimeUnits.Second);
        var result   = left / right;
        _testOutputHelper.WriteLine("Check if " + left + " / " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

        
    [Fact]
    public void T08_should_div_massStream_by_density() {
        // massStream(Kg,Second) / density(Pound,CubicInch) = volumeStream(CubicInch,Second)
        var left     = new MassStream(500m, MassUnits.Kg, TimeUnits.Second);
        var right    = new Density(25m, MassUnits.Pound, VolumeUnits.CubicInch);
        var expected = new VolumeStream(44.092452436975516144594760270m, VolumeUnits.CubicInch, TimeUnits.Second);
        var result   = left / right;
        _testOutputHelper.WriteLine("Check if " + left + " / " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

        
    [Fact]
    public void T09_should_mul_velocity_by_time() {
        // velocity(Meter,Second) * time(Second) = length(Meter)
        var left     = new Velocity(12m, LengthUnits.Meter, TimeUnits.Second);
        var right    = new Time(25m, TimeUnits.Second);
        var expected = new Length(300m, LengthUnits.Meter);
        var result   = left * right;
        _testOutputHelper.WriteLine("Check if " + left + " * " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

    // Reverse order multiplication
    [Fact]
    public void T10_should_mul_time_by_velocity() {
        // time(Second) * velocity(Meter,Second) = length(Meter)
        var left     = new Time(25m, TimeUnits.Second);
        var right    = new Velocity(12m, LengthUnits.Meter, TimeUnits.Second);
        var expected = new Length(300m, LengthUnits.Meter);
        var result   = left * right;
        _testOutputHelper.WriteLine("Check if " + left + " * " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

    // Division 1 made from multiplication
    [Fact]
    public void T11_should_div_length_by_velocity() {
        // length(Meter) / velocity(Meter,Second) = time(Second)
        var left     = new Length(300m, LengthUnits.Meter);
        var right    = new Velocity(12m, LengthUnits.Meter, TimeUnits.Second);
        var expected = new Time(25m, TimeUnits.Second);
        var result   = left / right;
        _testOutputHelper.WriteLine("Check if " + left + " / " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

    // Division 2 made from multiplication
    [Fact]
    public void T12_should_div_length_by_time() {
        // length(Meter) / time(Second) = velocity(Meter,Second)
        var left     = new Length(300m, LengthUnits.Meter);
        var right    = new Time(25m, TimeUnits.Second);
        var expected = new Velocity(12m, LengthUnits.Meter, TimeUnits.Second);
        var result   = left / right;
        _testOutputHelper.WriteLine("Check if " + left + " / " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

        
    [Fact]
    public void T13_should_mul_velocity_by_time() {
        // velocity(Meter,Second) * time(Minute) = length(Meter)
        var left     = new Velocity(12m, LengthUnits.Meter, TimeUnits.Second);
        var right    = new Time(2m, TimeUnits.Minute);
        var expected = new Length(1440m, LengthUnits.Meter);
        var result   = left * right;
        _testOutputHelper.WriteLine("Check if " + left + " * " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

    // Reverse order multiplication
    [Fact]
    public void T14_should_mul_time_by_velocity() {
        // time(Minute) * velocity(Meter,Second) = length(Meter)
        var left     = new Time(2m, TimeUnits.Minute);
        var right    = new Velocity(12m, LengthUnits.Meter, TimeUnits.Second);
        var expected = new Length(1440m, LengthUnits.Meter);
        var result   = left * right;
        _testOutputHelper.WriteLine("Check if " + left + " * " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method

        
    [Fact]
    public void T15_should_div_length_by_velocity() {
        // length(Meter) / velocity(Meter,Minute) = time(Minute)
        var left     = new Length(300m, LengthUnits.Meter);
        var right    = new Velocity(12m, LengthUnits.Meter, TimeUnits.Minute);
        var expected = new Time(25m, TimeUnits.Minute);
        var result   = left / right;
        _testOutputHelper.WriteLine("Check if " + left + " / " + right + " = " + expected);
        Assert.Equal(expected.Value, result.Value, 12);
        Assert.Equal(expected.Unit.UnitName, result.Unit.UnitName);
    } // end of method
}     // end of class
// end of namespace


