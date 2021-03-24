// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct Area
    {
        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Volume operator *(Area area, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRelatedUnits
            // scenario C
            var rightUnit = GlobalUnitRegistry.Relations.GetOrThrow<AreaUnit, LengthUnit>(area.Unit);
            var resultUnit = GlobalUnitRegistry.Relations.GetOrThrow<AreaUnit, VolumeUnit>(area.Unit);
            var lengthConverted = length.ConvertTo(rightUnit);
            var value = area.Value * lengthConverted.Value;
            return new Volume(value, resultUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Volume operator *(Length length, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRelatedUnits
            // scenario C
            var rightUnit = GlobalUnitRegistry.Relations.GetOrThrow<LengthUnit, AreaUnit>(length.Unit);
            var resultUnit = GlobalUnitRegistry.Relations.GetOrThrow<LengthUnit, VolumeUnit>(length.Unit);
            var areaConverted = area.ConvertTo(rightUnit);
            var value = length.Value * areaConverted.Value;
            return new Volume(value, resultUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="pressure">rigth factor (multiplier)</param>
        public static Force operator *(Area area, Pressure pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario B
            var unit = new PressureUnit(pressure.Unit.CounterUnit, area.Unit);
            var pressureConverted    = pressure.WithDenominatorUnit(area.Unit);
            var value = area.Value / pressureConverted.Value;
            return new Force(value, pressure.Unit.CounterUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="pressure">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Force operator *(Pressure pressure, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // area unit will be taken from denominator of pressure unit
            // scenario D
            var areaConverted = area.ConvertTo(pressure.Unit.DenominatorUnit);
            var value = areaConverted.Value * pressure.Value;
            return new Force(value, pressure.Unit.CounterUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="area">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length operator /(Area area, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRelatedUnits
            // scenario C
            var newUnit = GlobalUnitRegistry.Relations.GetOrThrow<AreaUnit, LengthUnit>(area.Unit);
            var lengthConverted = length.ConvertTo(newUnit);
            var value = area.Value / lengthConverted.Value;
            return new Length(value, newUnit);
        }

    }
}
