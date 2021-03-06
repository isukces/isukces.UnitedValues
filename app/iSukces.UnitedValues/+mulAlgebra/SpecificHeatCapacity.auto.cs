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
            // scenario B
            var unit = new SpecificHeatCapacityUnit(specificHeatCapacity.Unit.CounterUnit, deltaKelvinTemperature.Unit);
            var specificHeatCapacityConverted    = specificHeatCapacity.WithDenominatorUnit(deltaKelvinTemperature.Unit);
            var value = deltaKelvinTemperature.Value * specificHeatCapacityConverted.Value;
            return new EnergyMassDensity(value, specificHeatCapacity.Unit.CounterUnit);
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
            // hint location Add_EnergyMassDensity_DeltaKelvinTemperature_SpecificHeatCapacity, line 16
            var specificHeatCapacityUnit = specificHeatCapacity.Unit;
            var tmp1 = specificHeatCapacityUnit.CounterUnit;
            var resultUnit = new EnergyMassDensityUnit(tmp1.CounterUnit, tmp1.DenominatorUnit);
            var deltaKelvinTemperatureConverted = deltaKelvinTemperature.ConvertTo(specificHeatCapacityUnit.DenominatorUnit);
            var value = specificHeatCapacity.Value * deltaKelvinTemperatureConverted.Value;
            return new EnergyMassDensity(value, resultUnit);
            // scenario D1
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
