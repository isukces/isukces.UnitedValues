// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct EnergyMassDensity
    {
        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="deltaKelvinTemperature">a divisor (denominator) - a value which dividend is divided by</param>
        public static SpecificHeatCapacity operator /(EnergyMassDensity energyMassDensity, DeltaKelvinTemperature deltaKelvinTemperature)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // SpecificHeatCapacity operator /(EnergyMassDensity energyMassDensity, DeltaKelvinTemperature deltaKelvinTemperature)
            // scenario with hint
            // .Is<EnergyMassDensity, DeltaKelvinTemperature, SpecificHeatCapacity>("/")
            var energyMassDensityUnit = energyMassDensity.Unit;
            var resultUnit = new SpecificHeatCapacityUnit(energyMassDensityUnit.CounterUnit, energyMassDensityUnit.DenominatorUnit, deltaKelvinTemperature.Unit);
            var value = energyMassDensity.Value / deltaKelvinTemperature.Value;
            return new SpecificHeatCapacity(value, resultUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="specificHeatCapacity">a divisor (denominator) - a value which dividend is divided by</param>
        public static DeltaKelvinTemperature operator /(EnergyMassDensity energyMassDensity, SpecificHeatCapacity specificHeatCapacity)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<EnergyMassDensity, SpecificHeatCapacity, DeltaKelvinTemperature>("/")
            var energyMassDensityUnit = energyMassDensity.Unit;
            var specificHeatCapacityUnit = specificHeatCapacity.Unit;
            var tmp1 = specificHeatCapacityUnit.DenominatorUnit;
            var targetRightUnit = new SpecificHeatCapacityUnit(energyMassDensityUnit.CounterUnit, energyMassDensityUnit.DenominatorUnit, tmp1);
            var specificHeatCapacityConverted = specificHeatCapacity.ConvertTo(targetRightUnit);
            var value = energyMassDensity.Value / specificHeatCapacityConverted.Value;
            return new DeltaKelvinTemperature(value, tmp1);
            // scenario F1
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="deltaKelvinTemperature">a divisor (denominator) - a value which dividend is divided by</param>
        public static SpecificHeatCapacity? operator /(EnergyMassDensity? energyMassDensity, DeltaKelvinTemperature deltaKelvinTemperature)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energyMassDensity is null)
                return null;
            return energyMassDensity.Value / deltaKelvinTemperature;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="specificHeatCapacity">a divisor (denominator) - a value which dividend is divided by</param>
        public static DeltaKelvinTemperature? operator /(EnergyMassDensity? energyMassDensity, SpecificHeatCapacity specificHeatCapacity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energyMassDensity is null)
                return null;
            return energyMassDensity.Value / specificHeatCapacity;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="deltaKelvinTemperature">a divisor (denominator) - a value which dividend is divided by</param>
        public static SpecificHeatCapacity? operator /(EnergyMassDensity energyMassDensity, DeltaKelvinTemperature? deltaKelvinTemperature)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (deltaKelvinTemperature is null)
                return null;
            return energyMassDensity / deltaKelvinTemperature.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="specificHeatCapacity">a divisor (denominator) - a value which dividend is divided by</param>
        public static DeltaKelvinTemperature? operator /(EnergyMassDensity energyMassDensity, SpecificHeatCapacity? specificHeatCapacity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (specificHeatCapacity is null)
                return null;
            return energyMassDensity / specificHeatCapacity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="deltaKelvinTemperature">a divisor (denominator) - a value which dividend is divided by</param>
        public static SpecificHeatCapacity? operator /(EnergyMassDensity? energyMassDensity, DeltaKelvinTemperature? deltaKelvinTemperature)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energyMassDensity is null || deltaKelvinTemperature is null)
                return null;
            return energyMassDensity.Value / deltaKelvinTemperature.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="energyMassDensity">a dividend (counter) - a value that is being divided</param>
        /// <param name="specificHeatCapacity">a divisor (denominator) - a value which dividend is divided by</param>
        public static DeltaKelvinTemperature? operator /(EnergyMassDensity? energyMassDensity, SpecificHeatCapacity? specificHeatCapacity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (energyMassDensity is null || specificHeatCapacity is null)
                return null;
            return energyMassDensity.Value / specificHeatCapacity.Value;
        }

    }
}
