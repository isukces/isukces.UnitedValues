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
        /// <param name="length">rigth factor (multiplier)</param>
        public static Volume? operator *(Area? area, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return area.Value * length;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Volume? operator *(Length? length, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return length.Value * area;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Volume? operator *(Area area, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return area * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Volume? operator *(Length length, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return length * area.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Volume? operator *(Area? area, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null || length is null)
                return null;
            return area.Value * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Volume? operator *(Length? length, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null || area is null)
                return null;
            return length.Value * area.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static Mass operator *(Area area, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario B
            var unit = new PlanarDensityUnit(planarDensity.Unit.CounterUnit, area.Unit);
            var planarDensityConverted    = planarDensity.WithDenominatorUnit(area.Unit);
            var value = area.Value * planarDensityConverted.Value;
            return new Mass(value, planarDensity.Unit.CounterUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Mass operator *(PlanarDensity planarDensity, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Mass operator *(PlanarDensity planarDensity, Area area)
            // scenario with hint
            // .Is<PlanarDensity, Area, Mass>("*")
            var planarDensityUnit = planarDensity.Unit;
            var areaConverted = area.ConvertTo(planarDensityUnit.DenominatorUnit);
            var value = planarDensity.Value * areaConverted.Value;
            return new Mass(value, planarDensityUnit.CounterUnit);
            // scenario D1
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static Mass? operator *(Area? area, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return area.Value * planarDensity;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Mass? operator *(PlanarDensity? planarDensity, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null)
                return null;
            return planarDensity.Value * area;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static Mass? operator *(Area area, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null)
                return null;
            return area * planarDensity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Mass? operator *(PlanarDensity planarDensity, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return planarDensity * area.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static Mass? operator *(Area? area, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null || planarDensity is null)
                return null;
            return area.Value * planarDensity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Mass? operator *(PlanarDensity? planarDensity, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null || area is null)
                return null;
            return planarDensity.Value * area.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static LinearDensity operator *(Area area, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario with hint
            // .Is<Area, Density, LinearDensity>("*")
            var densityUnit = density.Unit;
            var tmp1 = densityUnit.CounterUnit;
            var areaUnit = area.Unit;
            var targetRightUnit = new DensityUnit(tmp1, areaUnit.GetVolumeUnit());
            var resultUnit = new LinearDensityUnit(tmp1, areaUnit.GetLengthUnit());
            var densityConverted = density.ConvertTo(targetRightUnit);
            var value = area.Value * densityConverted.Value;
            return new LinearDensity(value, resultUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static LinearDensity operator *(Density density, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // LinearDensity operator *(Density density, Area area)
            // scenario with hint
            // .Is<Density, Area, LinearDensity>("*")
            var densityUnit = density.Unit;
            var tmp1 = densityUnit.DenominatorUnit;
            var resultUnit = new LinearDensityUnit(densityUnit.CounterUnit, tmp1.GetLengthUnit());
            var areaConverted = area.ConvertTo(tmp1.GetAreaUnit());
            var value = density.Value * areaConverted.Value;
            return new LinearDensity(value, resultUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(Area? area, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return area.Value * density;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(Density? density, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return density.Value * area;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(Area area, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return area * density.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(Density density, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return density * area.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(Area? area, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null || density is null)
                return null;
            return area.Value * density.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(Density? density, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null || area is null)
                return null;
            return density.Value * area.Value;
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
            var value = area.Value * pressureConverted.Value;
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
            // Force operator *(Pressure pressure, Area area)
            // scenario D3
            var pressureUnit = pressure.Unit;
            var areaConverted = area.ConvertTo(pressureUnit.DenominatorUnit);
            var value = pressure.Value * areaConverted.Value;
            return new Force(value, pressureUnit.CounterUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="pressure">rigth factor (multiplier)</param>
        public static Force? operator *(Area? area, Pressure pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return area.Value * pressure;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="pressure">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Force? operator *(Pressure? pressure, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (pressure is null)
                return null;
            return pressure.Value * area;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="pressure">rigth factor (multiplier)</param>
        public static Force? operator *(Area area, Pressure? pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (pressure is null)
                return null;
            return area * pressure.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="pressure">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Force? operator *(Pressure pressure, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return pressure * area.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="area">left factor (multiplicand)</param>
        /// <param name="pressure">rigth factor (multiplier)</param>
        public static Force? operator *(Area? area, Pressure? pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null || pressure is null)
                return null;
            return area.Value * pressure.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="pressure">left factor (multiplicand)</param>
        /// <param name="area">rigth factor (multiplier)</param>
        public static Force? operator *(Pressure? pressure, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (pressure is null || area is null)
                return null;
            return pressure.Value * area.Value;
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

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="area">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(Area? area, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return area.Value / length;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="area">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(Area area, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return area / length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="area">a dividend (counter) - a value that is being divided</param>
        /// <param name="length">a divisor (denominator) - a value which dividend is divided by</param>
        public static Length? operator /(Area? area, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null || length is null)
                return null;
            return area.Value / length.Value;
        }

    }
}
