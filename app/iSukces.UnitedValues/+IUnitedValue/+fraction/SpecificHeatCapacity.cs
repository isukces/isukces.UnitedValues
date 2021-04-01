namespace iSukces.UnitedValues
{
    public partial struct SpecificHeatCapacity
    {
        public SpecificHeatCapacity(decimal value,
            EnergyUnit energy,
            MassUnit mass,
            KelvinTemperatureUnit temperature)
            : this(value, new EnergyMassDensityUnit(energy, mass), temperature)
        {
        }
    }
}