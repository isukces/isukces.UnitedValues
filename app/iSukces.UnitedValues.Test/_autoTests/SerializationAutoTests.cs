using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;


// char test ² ąćęłńóśźż

namespace iSukces.UnitedValues.Test;

public class SerializationTests
{
    public SerializationTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [InlineData("45.87m/s²", "45.87m/s²", "LengthUnits.Meter", "SquareTimeUnits.SquareSecond")]
    [InlineData("45.87m/s²", " 45.87   m/s²     ", "LengthUnits.Meter", "SquareTimeUnits.SquareSecond")]
    [InlineData("45.87m/s²", " 45.8700   m/s²     ", "LengthUnits.Meter", "SquareTimeUnits.SquareSecond")]
    [InlineData("45.87m/s²", "45.87m/ s²", "LengthUnits.Meter", "SquareTimeUnits.SquareSecond")]
    [InlineData("45.87m/s²", " 45.87   m/ s²     ", "LengthUnits.Meter", "SquareTimeUnits.SquareSecond")]
    [InlineData("45.87m/s²", " 45.8700   m/ s²     ", "LengthUnits.Meter", "SquareTimeUnits.SquareSecond")]
    [InlineData("45.87m/h²", "45.87m/h²", "LengthUnits.Meter", "SquareTimeUnits.SquareHour")]
    [InlineData("45.87m/h²", " 45.87   m/h²     ", "LengthUnits.Meter", "SquareTimeUnits.SquareHour")]
    [InlineData("45.87m/h²", " 45.8700   m/h²     ", "LengthUnits.Meter", "SquareTimeUnits.SquareHour")]
    [InlineData("45.87m/h²", "45.87m/ h²", "LengthUnits.Meter", "SquareTimeUnits.SquareHour")]
    [InlineData("45.87m/h²", " 45.87   m/ h²     ", "LengthUnits.Meter", "SquareTimeUnits.SquareHour")]
    [InlineData("45.87m/h²", " 45.8700   m/ h²     ", "LengthUnits.Meter", "SquareTimeUnits.SquareHour")]
    [InlineData("45.87yd/s²", "45.87yd/s²", "LengthUnits.Yard", "SquareTimeUnits.SquareSecond")]
    [InlineData("45.87yd/s²", " 45.87   yd/s²     ", "LengthUnits.Yard", "SquareTimeUnits.SquareSecond")]
    [InlineData("45.87yd/s²", " 45.8700   yd/s²     ", "LengthUnits.Yard", "SquareTimeUnits.SquareSecond")]
    [InlineData("45.87yd/s²", "45.87yd/ s²", "LengthUnits.Yard", "SquareTimeUnits.SquareSecond")]
    [InlineData("45.87yd/s²", " 45.87   yd/ s²     ", "LengthUnits.Yard", "SquareTimeUnits.SquareSecond")]
    [InlineData("45.87yd/s²", " 45.8700   yd/ s²     ", "LengthUnits.Yard", "SquareTimeUnits.SquareSecond")]
    [InlineData("45.87yd/h²", "45.87yd/h²", "LengthUnits.Yard", "SquareTimeUnits.SquareHour")]
    [InlineData("45.87yd/h²", " 45.87   yd/h²     ", "LengthUnits.Yard", "SquareTimeUnits.SquareHour")]
    [InlineData("45.87yd/h²", " 45.8700   yd/h²     ", "LengthUnits.Yard", "SquareTimeUnits.SquareHour")]
    [InlineData("45.87yd/h²", "45.87yd/ h²", "LengthUnits.Yard", "SquareTimeUnits.SquareHour")]
    [InlineData("45.87yd/h²", " 45.87   yd/ h²     ", "LengthUnits.Yard", "SquareTimeUnits.SquareHour")]
    [InlineData("45.87yd/h²", " 45.8700   yd/ h²     ", "LengthUnits.Yard", "SquareTimeUnits.SquareHour")]
    [Theory]
    public void T01_Should_deserialize_Acceleration(string expected, string jsonToDeserialize, string theLengthUnits, string theSquareTimeUnits)
    {
        var u1 = TestUtils.LoadUnit<LengthUnit>(theLengthUnits);
        var u2 = TestUtils.LoadUnit<SquareTimeUnit>(theSquareTimeUnits);
        // serialization
        var obj = new Acceleration(45.87m, u1, u2);
        expected = "\"" + expected + "\"";
        var json = JsonConvert.SerializeObject(obj);
        _testOutputHelper.WriteLine("serialized to " + json);
        Assert.Equal(expected, json);
        // deserialization
        jsonToDeserialize = "\"" + jsonToDeserialize + "\""; 
        _testOutputHelper.WriteLine("Try deserialize " +jsonToDeserialize);
        var deserialized = JsonConvert.DeserializeObject<Acceleration>(jsonToDeserialize);
        Assert.Equal(obj.Value, deserialized.Value);
        Assert.Equal(obj.Unit, deserialized.Unit);
    }

    [InlineData("45.87kg/m³", "45.87kg/m³", "MassUnits.Kg", "VolumeUnits.CubicMeter")]
    [InlineData("45.87kg/m³", " 45.87   kg/m³     ", "MassUnits.Kg", "VolumeUnits.CubicMeter")]
    [InlineData("45.87kg/m³", " 45.8700   kg/m³     ", "MassUnits.Kg", "VolumeUnits.CubicMeter")]
    [InlineData("45.87kg/m³", "45.87kg/ m³", "MassUnits.Kg", "VolumeUnits.CubicMeter")]
    [InlineData("45.87kg/m³", " 45.87   kg/ m³     ", "MassUnits.Kg", "VolumeUnits.CubicMeter")]
    [InlineData("45.87kg/m³", " 45.8700   kg/ m³     ", "MassUnits.Kg", "VolumeUnits.CubicMeter")]
    [InlineData("45.87kg/yd³", "45.87kg/yd³", "MassUnits.Kg", "VolumeUnits.CubicYard")]
    [InlineData("45.87kg/yd³", " 45.87   kg/yd³     ", "MassUnits.Kg", "VolumeUnits.CubicYard")]
    [InlineData("45.87kg/yd³", " 45.8700   kg/yd³     ", "MassUnits.Kg", "VolumeUnits.CubicYard")]
    [InlineData("45.87kg/yd³", "45.87kg/ yd³", "MassUnits.Kg", "VolumeUnits.CubicYard")]
    [InlineData("45.87kg/yd³", " 45.87   kg/ yd³     ", "MassUnits.Kg", "VolumeUnits.CubicYard")]
    [InlineData("45.87kg/yd³", " 45.8700   kg/ yd³     ", "MassUnits.Kg", "VolumeUnits.CubicYard")]
    [InlineData("45.87oz/m³", "45.87oz/m³", "MassUnits.Ounce", "VolumeUnits.CubicMeter")]
    [InlineData("45.87oz/m³", " 45.87   oz/m³     ", "MassUnits.Ounce", "VolumeUnits.CubicMeter")]
    [InlineData("45.87oz/m³", " 45.8700   oz/m³     ", "MassUnits.Ounce", "VolumeUnits.CubicMeter")]
    [InlineData("45.87oz/m³", "45.87oz/ m³", "MassUnits.Ounce", "VolumeUnits.CubicMeter")]
    [InlineData("45.87oz/m³", " 45.87   oz/ m³     ", "MassUnits.Ounce", "VolumeUnits.CubicMeter")]
    [InlineData("45.87oz/m³", " 45.8700   oz/ m³     ", "MassUnits.Ounce", "VolumeUnits.CubicMeter")]
    [InlineData("45.87oz/yd³", "45.87oz/yd³", "MassUnits.Ounce", "VolumeUnits.CubicYard")]
    [InlineData("45.87oz/yd³", " 45.87   oz/yd³     ", "MassUnits.Ounce", "VolumeUnits.CubicYard")]
    [InlineData("45.87oz/yd³", " 45.8700   oz/yd³     ", "MassUnits.Ounce", "VolumeUnits.CubicYard")]
    [InlineData("45.87oz/yd³", "45.87oz/ yd³", "MassUnits.Ounce", "VolumeUnits.CubicYard")]
    [InlineData("45.87oz/yd³", " 45.87   oz/ yd³     ", "MassUnits.Ounce", "VolumeUnits.CubicYard")]
    [InlineData("45.87oz/yd³", " 45.8700   oz/ yd³     ", "MassUnits.Ounce", "VolumeUnits.CubicYard")]
    [InlineData("45.87lbs/m³", "45.87lbs/m³", "MassUnits.Pound", "VolumeUnits.CubicMeter")]
    [InlineData("45.87lbs/m³", " 45.87   lbs/m³     ", "MassUnits.Pound", "VolumeUnits.CubicMeter")]
    [InlineData("45.87lbs/m³", " 45.8700   lbs/m³     ", "MassUnits.Pound", "VolumeUnits.CubicMeter")]
    [InlineData("45.87lbs/m³", "45.87lbs/ m³", "MassUnits.Pound", "VolumeUnits.CubicMeter")]
    [InlineData("45.87lbs/m³", " 45.87   lbs/ m³     ", "MassUnits.Pound", "VolumeUnits.CubicMeter")]
    [InlineData("45.87lbs/m³", " 45.8700   lbs/ m³     ", "MassUnits.Pound", "VolumeUnits.CubicMeter")]
    [InlineData("45.87lbs/yd³", "45.87lbs/yd³", "MassUnits.Pound", "VolumeUnits.CubicYard")]
    [InlineData("45.87lbs/yd³", " 45.87   lbs/yd³     ", "MassUnits.Pound", "VolumeUnits.CubicYard")]
    [InlineData("45.87lbs/yd³", " 45.8700   lbs/yd³     ", "MassUnits.Pound", "VolumeUnits.CubicYard")]
    [InlineData("45.87lbs/yd³", "45.87lbs/ yd³", "MassUnits.Pound", "VolumeUnits.CubicYard")]
    [InlineData("45.87lbs/yd³", " 45.87   lbs/ yd³     ", "MassUnits.Pound", "VolumeUnits.CubicYard")]
    [InlineData("45.87lbs/yd³", " 45.8700   lbs/ yd³     ", "MassUnits.Pound", "VolumeUnits.CubicYard")]
    [Theory]
    public void T02_Should_deserialize_Density(string expected, string jsonToDeserialize, string theMassUnits, string theVolumeUnits)
    {
        var u1 = TestUtils.LoadUnit<MassUnit>(theMassUnits);
        var u2 = TestUtils.LoadUnit<VolumeUnit>(theVolumeUnits);
        // serialization
        var obj = new Density(45.87m, u1, u2);
        expected = "\"" + expected + "\"";
        var json = JsonConvert.SerializeObject(obj);
        _testOutputHelper.WriteLine("serialized to " + json);
        Assert.Equal(expected, json);
        // deserialization
        jsonToDeserialize = "\"" + jsonToDeserialize + "\""; 
        _testOutputHelper.WriteLine("Try deserialize " +jsonToDeserialize);
        var deserialized = JsonConvert.DeserializeObject<Density>(jsonToDeserialize);
        Assert.Equal(obj.Value, deserialized.Value);
        Assert.Equal(obj.Unit, deserialized.Unit);
    }

    [InlineData("45.87J/kg", "45.87J/kg", "EnergyUnits.Joule", "MassUnits.Kg")]
    [InlineData("45.87J/kg", " 45.87   J/kg     ", "EnergyUnits.Joule", "MassUnits.Kg")]
    [InlineData("45.87J/kg", " 45.8700   J/kg     ", "EnergyUnits.Joule", "MassUnits.Kg")]
    [InlineData("45.87J/kg", "45.87J/ kg", "EnergyUnits.Joule", "MassUnits.Kg")]
    [InlineData("45.87J/kg", " 45.87   J/ kg     ", "EnergyUnits.Joule", "MassUnits.Kg")]
    [InlineData("45.87J/kg", " 45.8700   J/ kg     ", "EnergyUnits.Joule", "MassUnits.Kg")]
    [InlineData("45.87J/oz", "45.87J/oz", "EnergyUnits.Joule", "MassUnits.Ounce")]
    [InlineData("45.87J/oz", " 45.87   J/oz     ", "EnergyUnits.Joule", "MassUnits.Ounce")]
    [InlineData("45.87J/oz", " 45.8700   J/oz     ", "EnergyUnits.Joule", "MassUnits.Ounce")]
    [InlineData("45.87J/oz", "45.87J/ oz", "EnergyUnits.Joule", "MassUnits.Ounce")]
    [InlineData("45.87J/oz", " 45.87   J/ oz     ", "EnergyUnits.Joule", "MassUnits.Ounce")]
    [InlineData("45.87J/oz", " 45.8700   J/ oz     ", "EnergyUnits.Joule", "MassUnits.Ounce")]
    [InlineData("45.87J/lbs", "45.87J/lbs", "EnergyUnits.Joule", "MassUnits.Pound")]
    [InlineData("45.87J/lbs", " 45.87   J/lbs     ", "EnergyUnits.Joule", "MassUnits.Pound")]
    [InlineData("45.87J/lbs", " 45.8700   J/lbs     ", "EnergyUnits.Joule", "MassUnits.Pound")]
    [InlineData("45.87J/lbs", "45.87J/ lbs", "EnergyUnits.Joule", "MassUnits.Pound")]
    [InlineData("45.87J/lbs", " 45.87   J/ lbs     ", "EnergyUnits.Joule", "MassUnits.Pound")]
    [InlineData("45.87J/lbs", " 45.8700   J/ lbs     ", "EnergyUnits.Joule", "MassUnits.Pound")]
    [Theory]
    public void T03_Should_deserialize_EnergyMassDensity(string expected, string jsonToDeserialize, string theEnergyUnits, string theMassUnits)
    {
        var u1 = TestUtils.LoadUnit<EnergyUnit>(theEnergyUnits);
        var u2 = TestUtils.LoadUnit<MassUnit>(theMassUnits);
        // serialization
        var obj = new EnergyMassDensity(45.87m, u1, u2);
        expected = "\"" + expected + "\"";
        var json = JsonConvert.SerializeObject(obj);
        _testOutputHelper.WriteLine("serialized to " + json);
        Assert.Equal(expected, json);
        // deserialization
        jsonToDeserialize = "\"" + jsonToDeserialize + "\""; 
        _testOutputHelper.WriteLine("Try deserialize " +jsonToDeserialize);
        var deserialized = JsonConvert.DeserializeObject<EnergyMassDensity>(jsonToDeserialize);
        Assert.Equal(obj.Value, deserialized.Value);
        Assert.Equal(obj.Unit, deserialized.Unit);
    }

    [InlineData("45.87kg/m", "45.87kg/m", "MassUnits.Kg", "LengthUnits.Meter")]
    [InlineData("45.87kg/m", " 45.87   kg/m     ", "MassUnits.Kg", "LengthUnits.Meter")]
    [InlineData("45.87kg/m", " 45.8700   kg/m     ", "MassUnits.Kg", "LengthUnits.Meter")]
    [InlineData("45.87kg/m", "45.87kg/ m", "MassUnits.Kg", "LengthUnits.Meter")]
    [InlineData("45.87kg/m", " 45.87   kg/ m     ", "MassUnits.Kg", "LengthUnits.Meter")]
    [InlineData("45.87kg/m", " 45.8700   kg/ m     ", "MassUnits.Kg", "LengthUnits.Meter")]
    [InlineData("45.87kg/yd", "45.87kg/yd", "MassUnits.Kg", "LengthUnits.Yard")]
    [InlineData("45.87kg/yd", " 45.87   kg/yd     ", "MassUnits.Kg", "LengthUnits.Yard")]
    [InlineData("45.87kg/yd", " 45.8700   kg/yd     ", "MassUnits.Kg", "LengthUnits.Yard")]
    [InlineData("45.87kg/yd", "45.87kg/ yd", "MassUnits.Kg", "LengthUnits.Yard")]
    [InlineData("45.87kg/yd", " 45.87   kg/ yd     ", "MassUnits.Kg", "LengthUnits.Yard")]
    [InlineData("45.87kg/yd", " 45.8700   kg/ yd     ", "MassUnits.Kg", "LengthUnits.Yard")]
    [InlineData("45.87oz/m", "45.87oz/m", "MassUnits.Ounce", "LengthUnits.Meter")]
    [InlineData("45.87oz/m", " 45.87   oz/m     ", "MassUnits.Ounce", "LengthUnits.Meter")]
    [InlineData("45.87oz/m", " 45.8700   oz/m     ", "MassUnits.Ounce", "LengthUnits.Meter")]
    [InlineData("45.87oz/m", "45.87oz/ m", "MassUnits.Ounce", "LengthUnits.Meter")]
    [InlineData("45.87oz/m", " 45.87   oz/ m     ", "MassUnits.Ounce", "LengthUnits.Meter")]
    [InlineData("45.87oz/m", " 45.8700   oz/ m     ", "MassUnits.Ounce", "LengthUnits.Meter")]
    [InlineData("45.87oz/yd", "45.87oz/yd", "MassUnits.Ounce", "LengthUnits.Yard")]
    [InlineData("45.87oz/yd", " 45.87   oz/yd     ", "MassUnits.Ounce", "LengthUnits.Yard")]
    [InlineData("45.87oz/yd", " 45.8700   oz/yd     ", "MassUnits.Ounce", "LengthUnits.Yard")]
    [InlineData("45.87oz/yd", "45.87oz/ yd", "MassUnits.Ounce", "LengthUnits.Yard")]
    [InlineData("45.87oz/yd", " 45.87   oz/ yd     ", "MassUnits.Ounce", "LengthUnits.Yard")]
    [InlineData("45.87oz/yd", " 45.8700   oz/ yd     ", "MassUnits.Ounce", "LengthUnits.Yard")]
    [InlineData("45.87lbs/m", "45.87lbs/m", "MassUnits.Pound", "LengthUnits.Meter")]
    [InlineData("45.87lbs/m", " 45.87   lbs/m     ", "MassUnits.Pound", "LengthUnits.Meter")]
    [InlineData("45.87lbs/m", " 45.8700   lbs/m     ", "MassUnits.Pound", "LengthUnits.Meter")]
    [InlineData("45.87lbs/m", "45.87lbs/ m", "MassUnits.Pound", "LengthUnits.Meter")]
    [InlineData("45.87lbs/m", " 45.87   lbs/ m     ", "MassUnits.Pound", "LengthUnits.Meter")]
    [InlineData("45.87lbs/m", " 45.8700   lbs/ m     ", "MassUnits.Pound", "LengthUnits.Meter")]
    [InlineData("45.87lbs/yd", "45.87lbs/yd", "MassUnits.Pound", "LengthUnits.Yard")]
    [InlineData("45.87lbs/yd", " 45.87   lbs/yd     ", "MassUnits.Pound", "LengthUnits.Yard")]
    [InlineData("45.87lbs/yd", " 45.8700   lbs/yd     ", "MassUnits.Pound", "LengthUnits.Yard")]
    [InlineData("45.87lbs/yd", "45.87lbs/ yd", "MassUnits.Pound", "LengthUnits.Yard")]
    [InlineData("45.87lbs/yd", " 45.87   lbs/ yd     ", "MassUnits.Pound", "LengthUnits.Yard")]
    [InlineData("45.87lbs/yd", " 45.8700   lbs/ yd     ", "MassUnits.Pound", "LengthUnits.Yard")]
    [Theory]
    public void T04_Should_deserialize_LinearDensity(string expected, string jsonToDeserialize, string theMassUnits, string theLengthUnits)
    {
        var u1 = TestUtils.LoadUnit<MassUnit>(theMassUnits);
        var u2 = TestUtils.LoadUnit<LengthUnit>(theLengthUnits);
        // serialization
        var obj = new LinearDensity(45.87m, u1, u2);
        expected = "\"" + expected + "\"";
        var json = JsonConvert.SerializeObject(obj);
        _testOutputHelper.WriteLine("serialized to " + json);
        Assert.Equal(expected, json);
        // deserialization
        jsonToDeserialize = "\"" + jsonToDeserialize + "\""; 
        _testOutputHelper.WriteLine("Try deserialize " +jsonToDeserialize);
        var deserialized = JsonConvert.DeserializeObject<LinearDensity>(jsonToDeserialize);
        Assert.Equal(obj.Value, deserialized.Value);
        Assert.Equal(obj.Unit, deserialized.Unit);
    }

    [InlineData("45.87N/m", "45.87N/m", "ForceUnits.Newton", "LengthUnits.Meter")]
    [InlineData("45.87N/m", " 45.87   N/m     ", "ForceUnits.Newton", "LengthUnits.Meter")]
    [InlineData("45.87N/m", " 45.8700   N/m     ", "ForceUnits.Newton", "LengthUnits.Meter")]
    [InlineData("45.87N/m", "45.87N/ m", "ForceUnits.Newton", "LengthUnits.Meter")]
    [InlineData("45.87N/m", " 45.87   N/ m     ", "ForceUnits.Newton", "LengthUnits.Meter")]
    [InlineData("45.87N/m", " 45.8700   N/ m     ", "ForceUnits.Newton", "LengthUnits.Meter")]
    [InlineData("45.87N/yd", "45.87N/yd", "ForceUnits.Newton", "LengthUnits.Yard")]
    [InlineData("45.87N/yd", " 45.87   N/yd     ", "ForceUnits.Newton", "LengthUnits.Yard")]
    [InlineData("45.87N/yd", " 45.8700   N/yd     ", "ForceUnits.Newton", "LengthUnits.Yard")]
    [InlineData("45.87N/yd", "45.87N/ yd", "ForceUnits.Newton", "LengthUnits.Yard")]
    [InlineData("45.87N/yd", " 45.87   N/ yd     ", "ForceUnits.Newton", "LengthUnits.Yard")]
    [InlineData("45.87N/yd", " 45.8700   N/ yd     ", "ForceUnits.Newton", "LengthUnits.Yard")]
    [Theory]
    public void T05_Should_deserialize_LinearForce(string expected, string jsonToDeserialize, string theForceUnits, string theLengthUnits)
    {
        var u1 = TestUtils.LoadUnit<ForceUnit>(theForceUnits);
        var u2 = TestUtils.LoadUnit<LengthUnit>(theLengthUnits);
        // serialization
        var obj = new LinearForce(45.87m, u1, u2);
        expected = "\"" + expected + "\"";
        var json = JsonConvert.SerializeObject(obj);
        _testOutputHelper.WriteLine("serialized to " + json);
        Assert.Equal(expected, json);
        // deserialization
        jsonToDeserialize = "\"" + jsonToDeserialize + "\""; 
        _testOutputHelper.WriteLine("Try deserialize " +jsonToDeserialize);
        var deserialized = JsonConvert.DeserializeObject<LinearForce>(jsonToDeserialize);
        Assert.Equal(obj.Value, deserialized.Value);
        Assert.Equal(obj.Unit, deserialized.Unit);
    }

    [InlineData("45.87kg/s", "45.87kg/s", "MassUnits.Kg", "TimeUnits.Second")]
    [InlineData("45.87kg/s", " 45.87   kg/s     ", "MassUnits.Kg", "TimeUnits.Second")]
    [InlineData("45.87kg/s", " 45.8700   kg/s     ", "MassUnits.Kg", "TimeUnits.Second")]
    [InlineData("45.87kg/s", "45.87kg/ s", "MassUnits.Kg", "TimeUnits.Second")]
    [InlineData("45.87kg/s", " 45.87   kg/ s     ", "MassUnits.Kg", "TimeUnits.Second")]
    [InlineData("45.87kg/s", " 45.8700   kg/ s     ", "MassUnits.Kg", "TimeUnits.Second")]
    [InlineData("45.87kg/min", "45.87kg/min", "MassUnits.Kg", "TimeUnits.Minute")]
    [InlineData("45.87kg/min", " 45.87   kg/min     ", "MassUnits.Kg", "TimeUnits.Minute")]
    [InlineData("45.87kg/min", " 45.8700   kg/min     ", "MassUnits.Kg", "TimeUnits.Minute")]
    [InlineData("45.87kg/min", "45.87kg/ min", "MassUnits.Kg", "TimeUnits.Minute")]
    [InlineData("45.87kg/min", " 45.87   kg/ min     ", "MassUnits.Kg", "TimeUnits.Minute")]
    [InlineData("45.87kg/min", " 45.8700   kg/ min     ", "MassUnits.Kg", "TimeUnits.Minute")]
    [InlineData("45.87kg/h", "45.87kg/h", "MassUnits.Kg", "TimeUnits.Hour")]
    [InlineData("45.87kg/h", " 45.87   kg/h     ", "MassUnits.Kg", "TimeUnits.Hour")]
    [InlineData("45.87kg/h", " 45.8700   kg/h     ", "MassUnits.Kg", "TimeUnits.Hour")]
    [InlineData("45.87kg/h", "45.87kg/ h", "MassUnits.Kg", "TimeUnits.Hour")]
    [InlineData("45.87kg/h", " 45.87   kg/ h     ", "MassUnits.Kg", "TimeUnits.Hour")]
    [InlineData("45.87kg/h", " 45.8700   kg/ h     ", "MassUnits.Kg", "TimeUnits.Hour")]
    [InlineData("45.87oz/s", "45.87oz/s", "MassUnits.Ounce", "TimeUnits.Second")]
    [InlineData("45.87oz/s", " 45.87   oz/s     ", "MassUnits.Ounce", "TimeUnits.Second")]
    [InlineData("45.87oz/s", " 45.8700   oz/s     ", "MassUnits.Ounce", "TimeUnits.Second")]
    [InlineData("45.87oz/s", "45.87oz/ s", "MassUnits.Ounce", "TimeUnits.Second")]
    [InlineData("45.87oz/s", " 45.87   oz/ s     ", "MassUnits.Ounce", "TimeUnits.Second")]
    [InlineData("45.87oz/s", " 45.8700   oz/ s     ", "MassUnits.Ounce", "TimeUnits.Second")]
    [InlineData("45.87oz/min", "45.87oz/min", "MassUnits.Ounce", "TimeUnits.Minute")]
    [InlineData("45.87oz/min", " 45.87   oz/min     ", "MassUnits.Ounce", "TimeUnits.Minute")]
    [InlineData("45.87oz/min", " 45.8700   oz/min     ", "MassUnits.Ounce", "TimeUnits.Minute")]
    [InlineData("45.87oz/min", "45.87oz/ min", "MassUnits.Ounce", "TimeUnits.Minute")]
    [InlineData("45.87oz/min", " 45.87   oz/ min     ", "MassUnits.Ounce", "TimeUnits.Minute")]
    [InlineData("45.87oz/min", " 45.8700   oz/ min     ", "MassUnits.Ounce", "TimeUnits.Minute")]
    [InlineData("45.87oz/h", "45.87oz/h", "MassUnits.Ounce", "TimeUnits.Hour")]
    [InlineData("45.87oz/h", " 45.87   oz/h     ", "MassUnits.Ounce", "TimeUnits.Hour")]
    [InlineData("45.87oz/h", " 45.8700   oz/h     ", "MassUnits.Ounce", "TimeUnits.Hour")]
    [InlineData("45.87oz/h", "45.87oz/ h", "MassUnits.Ounce", "TimeUnits.Hour")]
    [InlineData("45.87oz/h", " 45.87   oz/ h     ", "MassUnits.Ounce", "TimeUnits.Hour")]
    [InlineData("45.87oz/h", " 45.8700   oz/ h     ", "MassUnits.Ounce", "TimeUnits.Hour")]
    [InlineData("45.87lbs/s", "45.87lbs/s", "MassUnits.Pound", "TimeUnits.Second")]
    [InlineData("45.87lbs/s", " 45.87   lbs/s     ", "MassUnits.Pound", "TimeUnits.Second")]
    [InlineData("45.87lbs/s", " 45.8700   lbs/s     ", "MassUnits.Pound", "TimeUnits.Second")]
    [InlineData("45.87lbs/s", "45.87lbs/ s", "MassUnits.Pound", "TimeUnits.Second")]
    [InlineData("45.87lbs/s", " 45.87   lbs/ s     ", "MassUnits.Pound", "TimeUnits.Second")]
    [InlineData("45.87lbs/s", " 45.8700   lbs/ s     ", "MassUnits.Pound", "TimeUnits.Second")]
    [InlineData("45.87lbs/min", "45.87lbs/min", "MassUnits.Pound", "TimeUnits.Minute")]
    [InlineData("45.87lbs/min", " 45.87   lbs/min     ", "MassUnits.Pound", "TimeUnits.Minute")]
    [InlineData("45.87lbs/min", " 45.8700   lbs/min     ", "MassUnits.Pound", "TimeUnits.Minute")]
    [InlineData("45.87lbs/min", "45.87lbs/ min", "MassUnits.Pound", "TimeUnits.Minute")]
    [InlineData("45.87lbs/min", " 45.87   lbs/ min     ", "MassUnits.Pound", "TimeUnits.Minute")]
    [InlineData("45.87lbs/min", " 45.8700   lbs/ min     ", "MassUnits.Pound", "TimeUnits.Minute")]
    [InlineData("45.87lbs/h", "45.87lbs/h", "MassUnits.Pound", "TimeUnits.Hour")]
    [InlineData("45.87lbs/h", " 45.87   lbs/h     ", "MassUnits.Pound", "TimeUnits.Hour")]
    [InlineData("45.87lbs/h", " 45.8700   lbs/h     ", "MassUnits.Pound", "TimeUnits.Hour")]
    [InlineData("45.87lbs/h", "45.87lbs/ h", "MassUnits.Pound", "TimeUnits.Hour")]
    [InlineData("45.87lbs/h", " 45.87   lbs/ h     ", "MassUnits.Pound", "TimeUnits.Hour")]
    [InlineData("45.87lbs/h", " 45.8700   lbs/ h     ", "MassUnits.Pound", "TimeUnits.Hour")]
    [Theory]
    public void T06_Should_deserialize_MassStream(string expected, string jsonToDeserialize, string theMassUnits, string theTimeUnits)
    {
        var u1 = TestUtils.LoadUnit<MassUnit>(theMassUnits);
        var u2 = TestUtils.LoadUnit<TimeUnit>(theTimeUnits);
        // serialization
        var obj = new MassStream(45.87m, u1, u2);
        expected = "\"" + expected + "\"";
        var json = JsonConvert.SerializeObject(obj);
        _testOutputHelper.WriteLine("serialized to " + json);
        Assert.Equal(expected, json);
        // deserialization
        jsonToDeserialize = "\"" + jsonToDeserialize + "\""; 
        _testOutputHelper.WriteLine("Try deserialize " +jsonToDeserialize);
        var deserialized = JsonConvert.DeserializeObject<MassStream>(jsonToDeserialize);
        Assert.Equal(obj.Value, deserialized.Value);
        Assert.Equal(obj.Unit, deserialized.Unit);
    }

    [InlineData("45.87kg/m²", "45.87kg/m²", "MassUnits.Kg", "AreaUnits.SquareMeter")]
    [InlineData("45.87kg/m²", " 45.87   kg/m²     ", "MassUnits.Kg", "AreaUnits.SquareMeter")]
    [InlineData("45.87kg/m²", " 45.8700   kg/m²     ", "MassUnits.Kg", "AreaUnits.SquareMeter")]
    [InlineData("45.87kg/m²", "45.87kg/ m²", "MassUnits.Kg", "AreaUnits.SquareMeter")]
    [InlineData("45.87kg/m²", " 45.87   kg/ m²     ", "MassUnits.Kg", "AreaUnits.SquareMeter")]
    [InlineData("45.87kg/m²", " 45.8700   kg/ m²     ", "MassUnits.Kg", "AreaUnits.SquareMeter")]
    [InlineData("45.87kg/inch²", "45.87kg/inch²", "MassUnits.Kg", "AreaUnits.SquareInch")]
    [InlineData("45.87kg/inch²", " 45.87   kg/inch²     ", "MassUnits.Kg", "AreaUnits.SquareInch")]
    [InlineData("45.87kg/inch²", " 45.8700   kg/inch²     ", "MassUnits.Kg", "AreaUnits.SquareInch")]
    [InlineData("45.87kg/inch²", "45.87kg/ inch²", "MassUnits.Kg", "AreaUnits.SquareInch")]
    [InlineData("45.87kg/inch²", " 45.87   kg/ inch²     ", "MassUnits.Kg", "AreaUnits.SquareInch")]
    [InlineData("45.87kg/inch²", " 45.8700   kg/ inch²     ", "MassUnits.Kg", "AreaUnits.SquareInch")]
    [InlineData("45.87oz/m²", "45.87oz/m²", "MassUnits.Ounce", "AreaUnits.SquareMeter")]
    [InlineData("45.87oz/m²", " 45.87   oz/m²     ", "MassUnits.Ounce", "AreaUnits.SquareMeter")]
    [InlineData("45.87oz/m²", " 45.8700   oz/m²     ", "MassUnits.Ounce", "AreaUnits.SquareMeter")]
    [InlineData("45.87oz/m²", "45.87oz/ m²", "MassUnits.Ounce", "AreaUnits.SquareMeter")]
    [InlineData("45.87oz/m²", " 45.87   oz/ m²     ", "MassUnits.Ounce", "AreaUnits.SquareMeter")]
    [InlineData("45.87oz/m²", " 45.8700   oz/ m²     ", "MassUnits.Ounce", "AreaUnits.SquareMeter")]
    [InlineData("45.87oz/inch²", "45.87oz/inch²", "MassUnits.Ounce", "AreaUnits.SquareInch")]
    [InlineData("45.87oz/inch²", " 45.87   oz/inch²     ", "MassUnits.Ounce", "AreaUnits.SquareInch")]
    [InlineData("45.87oz/inch²", " 45.8700   oz/inch²     ", "MassUnits.Ounce", "AreaUnits.SquareInch")]
    [InlineData("45.87oz/inch²", "45.87oz/ inch²", "MassUnits.Ounce", "AreaUnits.SquareInch")]
    [InlineData("45.87oz/inch²", " 45.87   oz/ inch²     ", "MassUnits.Ounce", "AreaUnits.SquareInch")]
    [InlineData("45.87oz/inch²", " 45.8700   oz/ inch²     ", "MassUnits.Ounce", "AreaUnits.SquareInch")]
    [InlineData("45.87lbs/m²", "45.87lbs/m²", "MassUnits.Pound", "AreaUnits.SquareMeter")]
    [InlineData("45.87lbs/m²", " 45.87   lbs/m²     ", "MassUnits.Pound", "AreaUnits.SquareMeter")]
    [InlineData("45.87lbs/m²", " 45.8700   lbs/m²     ", "MassUnits.Pound", "AreaUnits.SquareMeter")]
    [InlineData("45.87lbs/m²", "45.87lbs/ m²", "MassUnits.Pound", "AreaUnits.SquareMeter")]
    [InlineData("45.87lbs/m²", " 45.87   lbs/ m²     ", "MassUnits.Pound", "AreaUnits.SquareMeter")]
    [InlineData("45.87lbs/m²", " 45.8700   lbs/ m²     ", "MassUnits.Pound", "AreaUnits.SquareMeter")]
    [InlineData("45.87lbs/inch²", "45.87lbs/inch²", "MassUnits.Pound", "AreaUnits.SquareInch")]
    [InlineData("45.87lbs/inch²", " 45.87   lbs/inch²     ", "MassUnits.Pound", "AreaUnits.SquareInch")]
    [InlineData("45.87lbs/inch²", " 45.8700   lbs/inch²     ", "MassUnits.Pound", "AreaUnits.SquareInch")]
    [InlineData("45.87lbs/inch²", "45.87lbs/ inch²", "MassUnits.Pound", "AreaUnits.SquareInch")]
    [InlineData("45.87lbs/inch²", " 45.87   lbs/ inch²     ", "MassUnits.Pound", "AreaUnits.SquareInch")]
    [InlineData("45.87lbs/inch²", " 45.8700   lbs/ inch²     ", "MassUnits.Pound", "AreaUnits.SquareInch")]
    [Theory]
    public void T07_Should_deserialize_PlanarDensity(string expected, string jsonToDeserialize, string theMassUnits, string theAreaUnits)
    {
        var u1 = TestUtils.LoadUnit<MassUnit>(theMassUnits);
        var u2 = TestUtils.LoadUnit<AreaUnit>(theAreaUnits);
        // serialization
        var obj = new PlanarDensity(45.87m, u1, u2);
        expected = "\"" + expected + "\"";
        var json = JsonConvert.SerializeObject(obj);
        _testOutputHelper.WriteLine("serialized to " + json);
        Assert.Equal(expected, json);
        // deserialization
        jsonToDeserialize = "\"" + jsonToDeserialize + "\""; 
        _testOutputHelper.WriteLine("Try deserialize " +jsonToDeserialize);
        var deserialized = JsonConvert.DeserializeObject<PlanarDensity>(jsonToDeserialize);
        Assert.Equal(obj.Value, deserialized.Value);
        Assert.Equal(obj.Unit, deserialized.Unit);
    }

    [InlineData("45.87Pa", "45.87N/m²", "ForceUnits.Newton", "AreaUnits.SquareMeter")]
    [InlineData("45.87Pa", " 45.87   N/m²     ", "ForceUnits.Newton", "AreaUnits.SquareMeter")]
    [InlineData("45.87Pa", " 45.8700   N/m²     ", "ForceUnits.Newton", "AreaUnits.SquareMeter")]
    [InlineData("45.87Pa", "45.87N/ m²", "ForceUnits.Newton", "AreaUnits.SquareMeter")]
    [InlineData("45.87Pa", " 45.87   N/ m²     ", "ForceUnits.Newton", "AreaUnits.SquareMeter")]
    [InlineData("45.87Pa", " 45.8700   N/ m²     ", "ForceUnits.Newton", "AreaUnits.SquareMeter")]
    [InlineData("45.87N/inch²", "45.87N/inch²", "ForceUnits.Newton", "AreaUnits.SquareInch")]
    [InlineData("45.87N/inch²", " 45.87   N/inch²     ", "ForceUnits.Newton", "AreaUnits.SquareInch")]
    [InlineData("45.87N/inch²", " 45.8700   N/inch²     ", "ForceUnits.Newton", "AreaUnits.SquareInch")]
    [InlineData("45.87N/inch²", "45.87N/ inch²", "ForceUnits.Newton", "AreaUnits.SquareInch")]
    [InlineData("45.87N/inch²", " 45.87   N/ inch²     ", "ForceUnits.Newton", "AreaUnits.SquareInch")]
    [InlineData("45.87N/inch²", " 45.8700   N/ inch²     ", "ForceUnits.Newton", "AreaUnits.SquareInch")]
    [Theory]
    public void T08_Should_deserialize_Pressure(string expected, string jsonToDeserialize, string theForceUnits, string theAreaUnits)
    {
        var u1 = TestUtils.LoadUnit<ForceUnit>(theForceUnits);
        var u2 = TestUtils.LoadUnit<AreaUnit>(theAreaUnits);
        // serialization
        var obj = new Pressure(45.87m, u1, u2);
        expected = "\"" + expected + "\"";
        var json = JsonConvert.SerializeObject(obj);
        _testOutputHelper.WriteLine("serialized to " + json);
        Assert.Equal(expected, json);
        // deserialization
        jsonToDeserialize = "\"" + jsonToDeserialize + "\""; 
        _testOutputHelper.WriteLine("Try deserialize " +jsonToDeserialize);
        var deserialized = JsonConvert.DeserializeObject<Pressure>(jsonToDeserialize);
        Assert.Equal(obj.Value, deserialized.Value);

        var expectedUnit = obj.Unit.UnitName == "Pa" ? "N/m²" : obj.Unit.UnitName;
        Assert.Equal(expectedUnit, deserialized.Unit.UnitName);
    }

    [InlineData("45.87m³/s", "45.87m³/s", "VolumeUnits.CubicMeter", "TimeUnits.Second")]
    [InlineData("45.87m³/s", " 45.87   m³/s     ", "VolumeUnits.CubicMeter", "TimeUnits.Second")]
    [InlineData("45.87m³/s", " 45.8700   m³/s     ", "VolumeUnits.CubicMeter", "TimeUnits.Second")]
    [InlineData("45.87m³/s", "45.87m³/ s", "VolumeUnits.CubicMeter", "TimeUnits.Second")]
    [InlineData("45.87m³/s", " 45.87   m³/ s     ", "VolumeUnits.CubicMeter", "TimeUnits.Second")]
    [InlineData("45.87m³/s", " 45.8700   m³/ s     ", "VolumeUnits.CubicMeter", "TimeUnits.Second")]
    [InlineData("45.87m³/min", "45.87m³/min", "VolumeUnits.CubicMeter", "TimeUnits.Minute")]
    [InlineData("45.87m³/min", " 45.87   m³/min     ", "VolumeUnits.CubicMeter", "TimeUnits.Minute")]
    [InlineData("45.87m³/min", " 45.8700   m³/min     ", "VolumeUnits.CubicMeter", "TimeUnits.Minute")]
    [InlineData("45.87m³/min", "45.87m³/ min", "VolumeUnits.CubicMeter", "TimeUnits.Minute")]
    [InlineData("45.87m³/min", " 45.87   m³/ min     ", "VolumeUnits.CubicMeter", "TimeUnits.Minute")]
    [InlineData("45.87m³/min", " 45.8700   m³/ min     ", "VolumeUnits.CubicMeter", "TimeUnits.Minute")]
    [InlineData("45.87m³/h", "45.87m³/h", "VolumeUnits.CubicMeter", "TimeUnits.Hour")]
    [InlineData("45.87m³/h", " 45.87   m³/h     ", "VolumeUnits.CubicMeter", "TimeUnits.Hour")]
    [InlineData("45.87m³/h", " 45.8700   m³/h     ", "VolumeUnits.CubicMeter", "TimeUnits.Hour")]
    [InlineData("45.87m³/h", "45.87m³/ h", "VolumeUnits.CubicMeter", "TimeUnits.Hour")]
    [InlineData("45.87m³/h", " 45.87   m³/ h     ", "VolumeUnits.CubicMeter", "TimeUnits.Hour")]
    [InlineData("45.87m³/h", " 45.8700   m³/ h     ", "VolumeUnits.CubicMeter", "TimeUnits.Hour")]
    [InlineData("45.87yd³/s", "45.87yd³/s", "VolumeUnits.CubicYard", "TimeUnits.Second")]
    [InlineData("45.87yd³/s", " 45.87   yd³/s     ", "VolumeUnits.CubicYard", "TimeUnits.Second")]
    [InlineData("45.87yd³/s", " 45.8700   yd³/s     ", "VolumeUnits.CubicYard", "TimeUnits.Second")]
    [InlineData("45.87yd³/s", "45.87yd³/ s", "VolumeUnits.CubicYard", "TimeUnits.Second")]
    [InlineData("45.87yd³/s", " 45.87   yd³/ s     ", "VolumeUnits.CubicYard", "TimeUnits.Second")]
    [InlineData("45.87yd³/s", " 45.8700   yd³/ s     ", "VolumeUnits.CubicYard", "TimeUnits.Second")]
    [InlineData("45.87yd³/min", "45.87yd³/min", "VolumeUnits.CubicYard", "TimeUnits.Minute")]
    [InlineData("45.87yd³/min", " 45.87   yd³/min     ", "VolumeUnits.CubicYard", "TimeUnits.Minute")]
    [InlineData("45.87yd³/min", " 45.8700   yd³/min     ", "VolumeUnits.CubicYard", "TimeUnits.Minute")]
    [InlineData("45.87yd³/min", "45.87yd³/ min", "VolumeUnits.CubicYard", "TimeUnits.Minute")]
    [InlineData("45.87yd³/min", " 45.87   yd³/ min     ", "VolumeUnits.CubicYard", "TimeUnits.Minute")]
    [InlineData("45.87yd³/min", " 45.8700   yd³/ min     ", "VolumeUnits.CubicYard", "TimeUnits.Minute")]
    [InlineData("45.87yd³/h", "45.87yd³/h", "VolumeUnits.CubicYard", "TimeUnits.Hour")]
    [InlineData("45.87yd³/h", " 45.87   yd³/h     ", "VolumeUnits.CubicYard", "TimeUnits.Hour")]
    [InlineData("45.87yd³/h", " 45.8700   yd³/h     ", "VolumeUnits.CubicYard", "TimeUnits.Hour")]
    [InlineData("45.87yd³/h", "45.87yd³/ h", "VolumeUnits.CubicYard", "TimeUnits.Hour")]
    [InlineData("45.87yd³/h", " 45.87   yd³/ h     ", "VolumeUnits.CubicYard", "TimeUnits.Hour")]
    [InlineData("45.87yd³/h", " 45.8700   yd³/ h     ", "VolumeUnits.CubicYard", "TimeUnits.Hour")]
    [Theory]
    public void T09_Should_deserialize_VolumeStream(string expected, string jsonToDeserialize, string theVolumeUnits, string theTimeUnits)
    {
        var u1 = TestUtils.LoadUnit<VolumeUnit>(theVolumeUnits);
        var u2 = TestUtils.LoadUnit<TimeUnit>(theTimeUnits);
        // serialization
        var obj = new VolumeStream(45.87m, u1, u2);
        expected = "\"" + expected + "\"";
        var json = JsonConvert.SerializeObject(obj);
        _testOutputHelper.WriteLine("serialized to " + json);
        Assert.Equal(expected, json);
        // deserialization
        jsonToDeserialize = "\"" + jsonToDeserialize + "\""; 
        _testOutputHelper.WriteLine("Try deserialize " +jsonToDeserialize);
        var deserialized = JsonConvert.DeserializeObject<VolumeStream>(jsonToDeserialize);
        Assert.Equal(obj.Value, deserialized.Value);
        Assert.Equal(obj.Unit, deserialized.Unit);
    }


    private readonly ITestOutputHelper _testOutputHelper;
}
