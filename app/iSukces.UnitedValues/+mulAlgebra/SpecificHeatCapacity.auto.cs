// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct SpecificHeatCapacity
    {
        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="deltaKelvinTemperature">left factor (multiplicand)</param>
        /// <param name="specificHeatCapacity">rigth factor (multiplier)</param>
        public static EnergyMassDensity operator *(DeltaKelvinTemperature deltaKelvinTemperature, SpecificHeatCapacity specificHeatCapacity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForRightFractionValue
            // scenario with hint
            // .Is<DeltaKelvinTemperature, SpecificHeatCapacity, EnergyMassDensity>("*")
            var ru = specificHeatCapacity.Unit;
            var lu = deltaKelvinTemperature.Unit;
            var tmp = new MassDetlaKelvinUnit(ru.DenominatorUnit.LeftUnit, lu);
            var specificHeatCapacityConverted = specificHeatCapacity.ConvertTo(new SpecificHeatCapacityUnit(ru.CounterUnit, tmp));
            var value = deltaKelvinTemperature.Value * specificHeatCapacityConverted.Value;
            return new EnergyMassDensity(value, new EnergyMassDensityUnit(ru.CounterUnit, ru.DenominatorUnit.LeftUnit));
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="specificHeatCapacity">left factor (multiplicand)</param>
        /// <param name="deltaKelvinTemperature">rigth factor (multiplier)</param>
        public static EnergyMassDensity operator *(SpecificHeatCapacity specificHeatCapacity, DeltaKelvinTemperature deltaKelvinTemperature)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // EnergyMassDensity operator *(SpecificHeatCapacity specificHeatCapacity, DeltaKelvinTemperature deltaKelvinTemperature)
            // scenario with hint
            // .Is<SpecificHeatCapacity, DeltaKelvinTemperature, EnergyMassDensity>("*")
            var lu = specificHeatCapacity.Unit;
            var ru = deltaKelvinTemperature.Unit;
            var deltaKelvinTemperatureConverted = deltaKelvinTemperature.ConvertTo(lu.DenominatorUnit.RightUnit);
            var value = specificHeatCapacity.Value * deltaKelvinTemperatureConverted.Value;
            return new EnergyMassDensity(value, new EnergyMassDensityUnit(lu.CounterUnit, lu.DenominatorUnit.LeftUnit));
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="deltaKelvinTemperature">left factor (multiplicand)</param>
        /// <param name="specificHeatCapacity">rigth factor (multiplier)</param>
        public static EnergyMassDensity? operator *(DeltaKelvinTemperature? deltaKelvinTemperature, SpecificHeatCapacity specificHeatCapacity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (deltaKelvinTemperature is null)
                return null;
            return deltaKelvinTemperature.Value * specificHeatCapacity;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="specificHeatCapacity">left factor (multiplicand)</param>
        /// <param name="deltaKelvinTemperature">rigth factor (multiplier)</param>
        public static EnergyMassDensity? operator *(SpecificHeatCapacity? specificHeatCapacity, DeltaKelvinTemperature deltaKelvinTemperature)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (specificHeatCapacity is null)
                return null;
            return specificHeatCapacity.Value * deltaKelvinTemperature;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="deltaKelvinTemperature">left factor (multiplicand)</param>
        /// <param name="specificHeatCapacity">rigth factor (multiplier)</param>
        public static EnergyMassDensity? operator *(DeltaKelvinTemperature deltaKelvinTemperature, SpecificHeatCapacity? specificHeatCapacity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (specificHeatCapacity is null)
                return null;
            return deltaKelvinTemperature * specificHeatCapacity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="specificHeatCapacity">left factor (multiplicand)</param>
        /// <param name="deltaKelvinTemperature">rigth factor (multiplier)</param>
        public static EnergyMassDensity? operator *(SpecificHeatCapacity specificHeatCapacity, DeltaKelvinTemperature? deltaKelvinTemperature)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (deltaKelvinTemperature is null)
                return null;
            return specificHeatCapacity * deltaKelvinTemperature.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="deltaKelvinTemperature">left factor (multiplicand)</param>
        /// <param name="specificHeatCapacity">rigth factor (multiplier)</param>
        public static EnergyMassDensity? operator *(DeltaKelvinTemperature? deltaKelvinTemperature, SpecificHeatCapacity? specificHeatCapacity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (deltaKelvinTemperature is null || specificHeatCapacity is null)
                return null;
            return deltaKelvinTemperature.Value * specificHeatCapacity.Value;
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="specificHeatCapacity">left factor (multiplicand)</param>
        /// <param name="deltaKelvinTemperature">rigth factor (multiplier)</param>
        public static EnergyMassDensity? operator *(SpecificHeatCapacity? specificHeatCapacity, DeltaKelvinTemperature? deltaKelvinTemperature)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (specificHeatCapacity is null || deltaKelvinTemperature is null)
                return null;
            return specificHeatCapacity.Value * deltaKelvinTemperature.Value;
        }

    }
}
