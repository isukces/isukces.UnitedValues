// ReSharper disable All
using System;

namespace iSukces.UnitedValues
{
    // Type=ValueTypeName=Acceleration, UnitTypeName=AccelerationUnit, UnitContainerTypeName=AccelerationUnits, CounterUnit=Meter, DenominatorUnit=SquareSecond, TargetPropertyName=MetersPerSquareSeconds
    public partial class AccelerationUnits
    {
        /// <summary>
        /// represents acceleration unit 'm/s²'
        /// </summary>
        public static readonly AccelerationUnit MetersPerSquareSeconds = new AccelerationUnit(LengthUnits.Meter, SquareTimeUnits.SquareSecond);

    }
}
