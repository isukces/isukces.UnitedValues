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
            // hint location Add_EnergyMassDensity_DeltaKelvinTemperature_SpecificHeatCapacity, line 63
            var lu = energyMassDensity.Unit;
            var temperatureUnit = new KelvinTemperatureUnit(null);
            var u2 = new MassDetlaKelvinUnit(lu.DenominatorUnit, deltaKelvinTemperature.Unit);
            var value = energyMassDensity.Value / deltaKelvinTemperature.Value;
            return new SpecificHeatCapacity(value, new SpecificHeatCapacityUnit(lu.CounterUnit, u2));
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
            // hint location Add_EnergyMassDensity_DeltaKelvinTemperature_SpecificHeatCapacity, line 76
            var lu = energyMassDensity.Unit;
            var ru = specificHeatCapacity.Unit;
            var rud = ru.DenominatorUnit;
            var tmp = new MassDetlaKelvinUnit(lu.DenominatorUnit, rud.RightUnit);
            var rightConvertedUnit = new SpecificHeatCapacityUnit(lu.CounterUnit, tmp);
            var specificHeatCapacityConverted = specificHeatCapacity.ConvertTo(rightConvertedUnit);
            var value = energyMassDensity.Value / specificHeatCapacityConverted.Value;
            return new DeltaKelvinTemperature(value, ru.DenominatorUnit.RightUnit);
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
