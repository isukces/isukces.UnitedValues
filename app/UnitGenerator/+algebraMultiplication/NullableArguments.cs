using System;

namespace UnitGenerator;

[Flags]
public enum NullableArguments
{
    None  = 0,
    Left  = 1,
    Right = 2,
    Both  = Left | Right
}