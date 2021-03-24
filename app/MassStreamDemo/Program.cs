using System;
using iSukces.UnitedValues;

namespace MassStreamDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = new MassStream(5, WeightUnits.Tone, TimeUnits.Hour);
            Console.WriteLine("stream = " + stream);
            
            stream = stream.WithCounterUnit(WeightUnits.Kg);
            Console.WriteLine("stream = " + stream);

            stream = stream.WithDenominatorUnit(TimeUnits.Second);
            Console.WriteLine("stream = " + stream);
        }
    }
}