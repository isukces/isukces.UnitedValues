// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct MassStream
    {
        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="energyMassDensity">left factor (multiplicand)</param>
        /// <param name="massStream">rigth factor (multiplier)</param>
        public static Power operator *(EnergyMassDensity energyMassDensity, MassStream massStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<EnergyMassDensity, MassStream, Power>("*")
            // hint location HandleCreateOperatorCode, line 38
            var massUnit = massStream.Unit.CounterUnit;
            var leftConverted = energyMassDensity.ConvertTo(new EnergyMassDensityUnit(EnergyUnits.Joule, massUnit));
            var rightConverted = massStream.ConvertTo(new MassStreamUnit(massUnit, TimeUnits.Second));
            var value = leftConverted.Value * rightConverted.Value;
            return new Power(value, PowerUnits.Watt);
            // scenario F1
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="massStream">left factor (multiplicand)</param>
        /// <param name="energyMassDensity">rigth factor (multiplier)</param>
        public static Power operator *(MassStream massStream, EnergyMassDensity energyMassDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<MassStream, EnergyMassDensity, Power>("*")
            // hint location HandleCreateOperatorCode, line 49
            var massUnit = massStream.Unit.CounterUnit;
            var leftConverted = energyMassDensity.ConvertTo(new EnergyMassDensityUnit(EnergyUnits.Joule, massUnit));
            var rightConverted = massStream.ConvertTo(new MassStreamUnit(massUnit, TimeUnits.Second));
            var value = leftConverted.Value * rightConverted.Value;
            return new Power(value, PowerUnits.Watt);
            // scenario F1
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="energyMassDensity">left factor (multiplicand)</param>
        /// <param name="massStream">rigth factor (multiplier)</param>
        public static Power? operator *(EnergyMassDensity? energyMassDensity, MassStream massStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energyMassDensity is null)
                return null;
            return energyMassDensity.Value * massStream;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="massStream">left factor (multiplicand)</param>
        /// <param name="energyMassDensity">rigth factor (multiplier)</param>
        public static Power? operator *(MassStream? massStream, EnergyMassDensity energyMassDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (massStream is null)
                return null;
            return massStream.Value * energyMassDensity;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="energyMassDensity">left factor (multiplicand)</param>
        /// <param name="massStream">rigth factor (multiplier)</param>
        public static Power? operator *(EnergyMassDensity energyMassDensity, MassStream? massStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (massStream is null)
                return null;
            return energyMassDensity * massStream.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="massStream">left factor (multiplicand)</param>
        /// <param name="energyMassDensity">rigth factor (multiplier)</param>
        public static Power? operator *(MassStream massStream, EnergyMassDensity? energyMassDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energyMassDensity is null)
                return null;
            return massStream * energyMassDensity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="energyMassDensity">left factor (multiplicand)</param>
        /// <param name="massStream">rigth factor (multiplier)</param>
        public static Power? operator *(EnergyMassDensity? energyMassDensity, MassStream? massStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energyMassDensity is null || massStream is null)
                return null;
            return energyMassDensity.Value * massStream.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="massStream">left factor (multiplicand)</param>
        /// <param name="energyMassDensity">rigth factor (multiplier)</param>
        public static Power? operator *(MassStream? massStream, EnergyMassDensity? energyMassDensity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (massStream is null || energyMassDensity is null)
                return null;
            return massStream.Value * energyMassDensity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static VolumeStream operator /(MassStream massStream, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<MassStream, Density, VolumeStream>("/")
            // hint location GetBasicOperatorHints, line 31
            var massStreamUnit = massStream.Unit;
            var densityUnit = density.Unit;
            var tmp1 = densityUnit.DenominatorUnit;
            var targetRightUnit = new DensityUnit(massStreamUnit.CounterUnit, tmp1);
            var resultUnit = new VolumeStreamUnit(tmp1, massStreamUnit.DenominatorUnit);
            var densityConverted = density.ConvertTo(targetRightUnit);
            var value = massStream.Value / densityConverted.Value;
            return new VolumeStream(value, resultUnit);
            // scenario F1
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="volumeStream">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density operator /(MassStream massStream, VolumeStream volumeStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<MassStream, VolumeStream, Density>("/")
            // hint location GetBasicOperatorHints, line 31
            var volumeStreamUnit = volumeStream.Unit;
            var tmp1 = volumeStreamUnit.CounterUnit;
            var massStreamUnit = massStream.Unit;
            var targetRightUnit = new VolumeStreamUnit(tmp1, massStreamUnit.DenominatorUnit);
            var resultUnit = new DensityUnit(massStreamUnit.CounterUnit, tmp1);
            var volumeStreamConverted = volumeStream.ConvertTo(targetRightUnit);
            var value = massStream.Value / volumeStreamConverted.Value;
            return new Density(value, resultUnit);
            // scenario F1
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static VolumeStream? operator /(MassStream? massStream, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (massStream is null)
                return null;
            return massStream.Value / density;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="volumeStream">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(MassStream? massStream, VolumeStream volumeStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (massStream is null)
                return null;
            return massStream.Value / volumeStream;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static VolumeStream? operator /(MassStream massStream, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return massStream / density.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="volumeStream">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(MassStream massStream, VolumeStream? volumeStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volumeStream is null)
                return null;
            return massStream / volumeStream.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="density">a divisor (denominator) - a value which dividend is divided by</param>
        public static VolumeStream? operator /(MassStream? massStream, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (massStream is null || density is null)
                return null;
            return massStream.Value / density.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="massStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="volumeStream">a divisor (denominator) - a value which dividend is divided by</param>
        public static Density? operator /(MassStream? massStream, VolumeStream? volumeStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (massStream is null || volumeStream is null)
                return null;
            return massStream.Value / volumeStream.Value;
        }

    }
}
