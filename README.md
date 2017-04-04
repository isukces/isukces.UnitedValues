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

## Passing arguments in different units into methods


```
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

