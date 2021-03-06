# United Values

In simple words it helps to calculate values that have attached units like length, area or density.

Performing calculations with decimals or double types we can (and in fact we really do) a lot of mistakes like below

## Adding or substracting values with incompatible units 

Original code 
```csharp
decimal lengthInMm = 10;
decimal lengthInMeters = 10;
Console.WriteLine(lengthInMm + lengthInMeters); // WRONG RESULT 20
```
Can be transformed into

```csharp
Length lengthInMm = new Length(10, LengthUnits.Mm);
Length lengthInMeters = new Length(10, LengthUnits.Meter);           
Console.WriteLine(lengthInMm + lengthInMeters); // PROPER RESULT 10010,00 mm
Console.WriteLine(lengthInMeters + lengthInMm); // PROPER RESULT 10,01 m
```

While adding or subtracting values with different units result has always unit derived from first argument.

## Passing arguments with different units into methods


```csharp
static bool IsLongerThan2Meters(decimal length)
{
    // silently expects length in meters
    return length > 2;
}
...
decimal lengthInMm = 10;
decimal lengthInMeters = 10;
Console.WriteLine(lengthInMm); // WRONG USE
Console.WriteLine(lengthInMm);
```
Can be transformed into
```
static bool IsLongerThan2Meters(Length length)
{
    return length > new Length(2, LengthUnits.Meter);
}
...
Length lengthInMm = new Length(10, LengthUnits.Mm);
Length lengthInMeters = new Length(10, LengthUnits.Meter);
Console.WriteLine(IsLongerThan2Meters(lengthInMeters)); // TRUE
Console.WriteLine(IsLongerThan2Meters(lengthInMm)); // FALSE
```

## Sample values
```csharp
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
var waterSpecificHeatCapacity = new SpecificHeatCapacity(4211, specificHeatCapacityUnit);```
