namespace iSukces.UnitedValues
{
    public partial class SpecificHeatCapacityUnit
    {
        public SpecificHeatCapacityUnit(EnergyUnit energy, MassUnit mass, KelvinTemperatureUnit temperature)
            : this(new EnergyMassDensityUnit(energy, mass), temperature)
        {
        }
    }
}