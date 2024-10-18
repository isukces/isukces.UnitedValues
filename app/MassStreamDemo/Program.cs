using System;
using iSukces.UnitedValues;

namespace MassStreamDemo;

class Program
{
    static void Main(string[] args)
    {
        var stream = new MassStream(5, MassUnits.Tone, TimeUnits.Hour);
        Console.WriteLine("stream = " + stream);
            
        stream = stream.WithCounterUnit(MassUnits.Kg);
        Console.WriteLine("stream = " + stream);

        stream = stream.WithDenominatorUnit(TimeUnits.Second)
            .Round(3);
        Console.WriteLine("stream = " + stream);
    }
}