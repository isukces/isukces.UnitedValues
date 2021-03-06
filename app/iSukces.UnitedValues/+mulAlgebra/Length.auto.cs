// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct Length
    {
        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="leftFactor">left factor (multiplicand)</param>
        /// <param name="rightFactor">rigth factor (multiplier)</param>
        public static Area operator *(Length leftFactor, Length rightFactor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRelatedUnits
            // scenario C
            var rightUnit = GlobalUnitRegistry.Relations.GetOrThrow<LengthUnit, LengthUnit>(leftFactor.Unit);
            var resultUnit = GlobalUnitRegistry.Relations.GetOrThrow<LengthUnit, AreaUnit>(leftFactor.Unit);
            var rightFactorConverted = rightFactor.ConvertTo(rightUnit);
            var value = leftFactor.Value * rightFactorConverted.Value;
            return new Area(value, resultUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="leftFactor">left factor (multiplicand)</param>
        /// <param name="rightFactor">rigth factor (multiplier)</param>
        public static Area? operator *(Length? leftFactor, Length rightFactor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (leftFactor is null)
                return null;
            return leftFactor.Value * rightFactor;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="leftFactor">left factor (multiplicand)</param>
        /// <param name="rightFactor">rigth factor (multiplier)</param>
        public static Area? operator *(Length leftFactor, Length? rightFactor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (rightFactor is null)
                return null;
            return leftFactor * rightFactor.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="leftFactor">left factor (multiplicand)</param>
        /// <param name="rightFactor">rigth factor (multiplier)</param>
        public static Area? operator *(Length? leftFactor, Length? rightFactor)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (leftFactor is null || rightFactor is null)
                return null;
            return leftFactor.Value * rightFactor.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearDensity">rigth factor (multiplier)</param>
        public static Mass operator *(Length length, LinearDensity linearDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario B
            var unit = new LinearDensityUnit(linearDensity.Unit.CounterUnit, length.Unit);
            var linearDensityConverted    = linearDensity.WithDenominatorUnit(length.Unit);
            var value = length.Value * linearDensityConverted.Value;
            return new Mass(value, linearDensity.Unit.CounterUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Mass operator *(LinearDensity linearDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Mass operator *(LinearDensity linearDensity, Length length)
            // scenario with hint
            // .Is<LinearDensity, Length, Mass>("*")
            // hint location GetBasicOperatorHints, line 31
            var linearDensityUnit = linearDensity.Unit;
            var lengthConverted = length.ConvertTo(linearDensityUnit.DenominatorUnit);
            var value = linearDensity.Value * lengthConverted.Value;
            return new Mass(value, linearDensityUnit.CounterUnit);
            // scenario D1
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearDensity">rigth factor (multiplier)</param>
        public static Mass? operator *(Length? length, LinearDensity linearDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return length.Value * linearDensity;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Mass? operator *(LinearDensity? linearDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null)
                return null;
            return linearDensity.Value * length;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearDensity">rigth factor (multiplier)</param>
        public static Mass? operator *(Length length, LinearDensity? linearDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null)
                return null;
            return length * linearDensity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Mass? operator *(LinearDensity linearDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return linearDensity * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearDensity">rigth factor (multiplier)</param>
        public static Mass? operator *(Length? length, LinearDensity? linearDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null || linearDensity is null)
                return null;
            return length.Value * linearDensity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Mass? operator *(LinearDensity? linearDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearDensity is null || length is null)
                return null;
            return linearDensity.Value * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static LinearDensity operator *(Length length, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario with hint
            // .Is<Length, PlanarDensity, LinearDensity>("*")
            // hint location GetBasicOperatorHints, line 31
            var planarDensityUnit = planarDensity.Unit;
            var tmp1 = planarDensityUnit.CounterUnit;
            var lengthUnit = length.Unit;
            var targetRightUnit = new PlanarDensityUnit(tmp1, lengthUnit.GetAreaUnit());
            var resultUnit = new LinearDensityUnit(tmp1, lengthUnit);
            var planarDensityConverted = planarDensity.ConvertTo(targetRightUnit);
            var value = length.Value * planarDensityConverted.Value;
            return new LinearDensity(value, resultUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static LinearDensity operator *(PlanarDensity planarDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // LinearDensity operator *(PlanarDensity planarDensity, Length length)
            // scenario with hint
            // .Is<PlanarDensity, Length, LinearDensity>("*")
            // hint location GetBasicOperatorHints, line 31
            var planarDensityUnit = planarDensity.Unit;
            var tmp1 = planarDensityUnit.DenominatorUnit;
            var tmp2 = tmp1.GetLengthUnit();
            var resultUnit = new LinearDensityUnit(planarDensityUnit.CounterUnit, tmp2);
            var lengthConverted = length.ConvertTo(tmp2);
            var value = planarDensity.Value * lengthConverted.Value;
            return new LinearDensity(value, resultUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(Length? length, PlanarDensity planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return length.Value * planarDensity;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(PlanarDensity? planarDensity, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null)
                return null;
            return planarDensity.Value * length;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(Length length, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null)
                return null;
            return length * planarDensity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(PlanarDensity planarDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return planarDensity * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="planarDensity">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(Length? length, PlanarDensity? planarDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null || planarDensity is null)
                return null;
            return length.Value * planarDensity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="planarDensity">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static LinearDensity? operator *(PlanarDensity? planarDensity, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (planarDensity is null || length is null)
                return null;
            return planarDensity.Value * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static PlanarDensity operator *(Length length, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario with hint
            // .Is<Length, Density, PlanarDensity>("*")
            // hint location GetBasicOperatorHints, line 31
            var densityUnit = density.Unit;
            var tmp1 = densityUnit.CounterUnit;
            var lengthUnit = length.Unit;
            var targetRightUnit = new DensityUnit(tmp1, lengthUnit.GetVolumeUnit());
            var resultUnit = new PlanarDensityUnit(tmp1, lengthUnit.GetAreaUnit());
            var densityConverted = density.ConvertTo(targetRightUnit);
            var value = length.Value * densityConverted.Value;
            return new PlanarDensity(value, resultUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static PlanarDensity operator *(Density density, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // PlanarDensity operator *(Density density, Length length)
            // scenario with hint
            // .Is<Density, Length, PlanarDensity>("*")
            // hint location GetBasicOperatorHints, line 31
            var densityUnit = density.Unit;
            var tmp1 = densityUnit.DenominatorUnit;
            var resultUnit = new PlanarDensityUnit(densityUnit.CounterUnit, tmp1.GetAreaUnit());
            var lengthConverted = length.ConvertTo(tmp1.GetLengthUnit());
            var value = density.Value * lengthConverted.Value;
            return new PlanarDensity(value, resultUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static PlanarDensity? operator *(Length? length, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return length.Value * density;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static PlanarDensity? operator *(Density? density, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return density.Value * length;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static PlanarDensity? operator *(Length length, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return length * density.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static PlanarDensity? operator *(Density density, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return density * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static PlanarDensity? operator *(Length? length, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null || density is null)
                return null;
            return length.Value * density.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static PlanarDensity? operator *(Density? density, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null || length is null)
                return null;
            return density.Value * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="pressure">rigth factor (multiplier)</param>
        public static LinearForce operator *(Length length, Pressure pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<Length, Pressure, LinearForce>("*")
            // hint location HandleCreateOperatorCode, line 19 Def_LinearForce_Length_Pressure
            var leftConverted = length.ConvertTo(LengthUnits.Meter);
            var rightConverted = pressure.ConvertTo(PressureUnits.Pascal);
            var value = leftConverted.Value * rightConverted.Value;
            return new LinearForce(value, new LinearForceUnit(ForceUnits.Newton, LengthUnits.Meter));
            // scenario F3
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="pressure">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static LinearForce operator *(Pressure pressure, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<Pressure, Length, LinearForce>("*")
            // hint location HandleCreateOperatorCode, line 35 Def_LinearForce_Length_Pressure
            var leftConverted = pressure.ConvertTo(PressureUnits.Pascal);
            var rightConverted = length.ConvertTo(LengthUnits.Meter);
            var value = leftConverted.Value * rightConverted.Value;
            return new LinearForce(value, new LinearForceUnit(ForceUnits.Newton, LengthUnits.Meter));
            // scenario F3
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="pressure">rigth factor (multiplier)</param>
        public static LinearForce? operator *(Length? length, Pressure pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return length.Value * pressure;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="pressure">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static LinearForce? operator *(Pressure? pressure, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (pressure is null)
                return null;
            return pressure.Value * length;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="pressure">rigth factor (multiplier)</param>
        public static LinearForce? operator *(Length length, Pressure? pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (pressure is null)
                return null;
            return length * pressure.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="pressure">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static LinearForce? operator *(Pressure pressure, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return pressure * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="pressure">rigth factor (multiplier)</param>
        public static LinearForce? operator *(Length? length, Pressure? pressure)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null || pressure is null)
                return null;
            return length.Value * pressure.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="pressure">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static LinearForce? operator *(Pressure? pressure, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (pressure is null || length is null)
                return null;
            return pressure.Value * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearForce">rigth factor (multiplier)</param>
        public static Force operator *(Length length, LinearForce linearForce)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario B
            var unit = new LinearForceUnit(linearForce.Unit.CounterUnit, length.Unit);
            var linearForceConverted    = linearForce.WithDenominatorUnit(length.Unit);
            var value = length.Value * linearForceConverted.Value;
            return new Force(value, linearForce.Unit.CounterUnit);
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearForce">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Force operator *(LinearForce linearForce, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Force operator *(LinearForce linearForce, Length length)
            // scenario with hint
            // hint location HandleCreateOperatorCode, line 28 Def_Force_Length_LinearForce
            var lengthConverted = length.ConvertTo(linearForce.Unit.DenominatorUnit);
            var value = linearForce.Value * lengthConverted.Value;
            return new Force(value, linearForce.Unit.CounterUnit);
            // scenario D1
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearForce">rigth factor (multiplier)</param>
        public static Force? operator *(Length? length, LinearForce linearForce)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return length.Value * linearForce;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearForce">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Force? operator *(LinearForce? linearForce, Length length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null)
                return null;
            return linearForce.Value * length;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearForce">rigth factor (multiplier)</param>
        public static Force? operator *(Length length, LinearForce? linearForce)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null)
                return null;
            return length * linearForce.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearForce">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Force? operator *(LinearForce linearForce, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return linearForce * length.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="length">left factor (multiplicand)</param>
        /// <param name="linearForce">rigth factor (multiplier)</param>
        public static Force? operator *(Length? length, LinearForce? linearForce)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null || linearForce is null)
                return null;
            return length.Value * linearForce.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="linearForce">left factor (multiplicand)</param>
        /// <param name="length">rigth factor (multiplier)</param>
        public static Force? operator *(LinearForce? linearForce, Length? length)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (linearForce is null || length is null)
                return null;
            return linearForce.Value * length.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="length">a dividend (counter) - a value that is being divided</param>
        /// <param name="time">a divisor (denominator) - a value which dividend is divided by</param>
        public static Velocity operator /(Length length, Time time)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<Length, Time, Velocity>("/")
            // hint location GetBasicOperatorHints, line 31
            var resultUnit = new VelocityUnit(length.Unit, time.Unit);
            var value = length.Value / time.Value;
            return new Velocity(value, resultUnit);
            // scenario F3
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="length">a dividend (counter) - a value that is being divided</param>
        /// <param name="velocity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Time operator /(Length length, Velocity velocity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario A
            // velocity unit will be synchronized with length unit
            var unit = new VelocityUnit(length.Unit, velocity.Unit.DenominatorUnit);
            var velocityConverted    = velocity.WithCounterUnit(length.Unit);
            var value = length.Value / velocityConverted.Value;
            return new Time(value, velocity.Unit.DenominatorUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="length">a dividend (counter) - a value that is being divided</param>
        /// <param name="time">a divisor (denominator) - a value which dividend is divided by</param>
        public static Velocity? operator /(Length? length, Time time)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return length.Value / time;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="length">a dividend (counter) - a value that is being divided</param>
        /// <param name="velocity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Time? operator /(Length? length, Velocity velocity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null)
                return null;
            return length.Value / velocity;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="length">a dividend (counter) - a value that is being divided</param>
        /// <param name="time">a divisor (denominator) - a value which dividend is divided by</param>
        public static Velocity? operator /(Length length, Time? time)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (time is null)
                return null;
            return length / time.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="length">a dividend (counter) - a value that is being divided</param>
        /// <param name="velocity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Time? operator /(Length length, Velocity? velocity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (velocity is null)
                return null;
            return length / velocity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="length">a dividend (counter) - a value that is being divided</param>
        /// <param name="time">a divisor (denominator) - a value which dividend is divided by</param>
        public static Velocity? operator /(Length? length, Time? time)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null || time is null)
                return null;
            return length.Value / time.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="length">a dividend (counter) - a value that is being divided</param>
        /// <param name="velocity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Time? operator /(Length? length, Velocity? velocity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (length is null || velocity is null)
                return null;
            return length.Value / velocity.Value;
        }

    }
}
