// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct Density
    {
        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="volumeStream">rigth factor (multiplier)</param>
        public static MassStream operator *(Density density, VolumeStream volumeStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<Density, VolumeStream, MassStream>("*")
            var densityUnit = density.Unit;
            var volumeStreamUnit = volumeStream.Unit;
            var tmp1 = volumeStreamUnit.DenominatorUnit;
            var targetRightUnit = new VolumeStreamUnit(densityUnit.DenominatorUnit, tmp1);
            var resultUnit = new MassStreamUnit(densityUnit.CounterUnit, tmp1);
            var volumeStreamConverted = volumeStream.ConvertTo(targetRightUnit);
            var value = density.Value * volumeStreamConverted.Value;
            return new MassStream(value, resultUnit);
            // scenario F1
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="volumeStream">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static MassStream operator *(VolumeStream volumeStream, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<VolumeStream, Density, MassStream>("*")
            var densityUnit = density.Unit;
            var tmp1 = densityUnit.CounterUnit;
            var volumeStreamUnit = volumeStream.Unit;
            var targetRightUnit = new DensityUnit(tmp1, volumeStreamUnit.CounterUnit);
            var resultUnit = new MassStreamUnit(tmp1, volumeStreamUnit.DenominatorUnit);
            var densityConverted = density.ConvertTo(targetRightUnit);
            var value = volumeStream.Value * densityConverted.Value;
            return new MassStream(value, resultUnit);
            // scenario F1
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="volumeStream">rigth factor (multiplier)</param>
        public static MassStream? operator *(Density? density, VolumeStream volumeStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return density.Value * volumeStream;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="volumeStream">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static MassStream? operator *(VolumeStream? volumeStream, Density density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volumeStream is null)
                return null;
            return volumeStream.Value * density;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="volumeStream">rigth factor (multiplier)</param>
        public static MassStream? operator *(Density density, VolumeStream? volumeStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volumeStream is null)
                return null;
            return density * volumeStream.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="volumeStream">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static MassStream? operator *(VolumeStream volumeStream, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null)
                return null;
            return volumeStream * density.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="density">left factor (multiplicand)</param>
        /// <param name="volumeStream">rigth factor (multiplier)</param>
        public static MassStream? operator *(Density? density, VolumeStream? volumeStream)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (density is null || volumeStream is null)
                return null;
            return density.Value * volumeStream.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="volumeStream">left factor (multiplicand)</param>
        /// <param name="density">rigth factor (multiplier)</param>
        public static MassStream? operator *(VolumeStream? volumeStream, Density? density)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volumeStream is null || density is null)
                return null;
            return volumeStream.Value * density.Value;
        }

    }
}
