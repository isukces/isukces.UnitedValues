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
            // Fill method HandleCreateOperatorCode
            // .Is<EnergyMassDensity, MassStream, Power>("*")
            throw new NotImplementedException();
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
            // Fill method HandleCreateOperatorCode
            // .Is<MassStream, EnergyMassDensity, Power>("*")
            throw new NotImplementedException();
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

    }
}
