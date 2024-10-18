using System;

namespace UnitGenerator;

[Flags]
public enum CommonPrefixes
{
    Kilo  = 1,
    Mega  = 2,
    Giga  = 4,
    Mili  = 8,
    Micro = 16
}