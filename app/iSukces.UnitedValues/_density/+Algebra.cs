namespace iSukces.UnitedValues
{
    public partial struct Density
    {
        /// <summary>
        ///     Multiplication operator
        /// </summary>
        /// <param name="density"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static PlanarDensity operator *(Density density, Length length)
        {
            var lengthUnit = UnitRelationsDictionary.GetT<VolumeUnit, LengthUnit>(density.Unit.DenominatorUnit);
            length = length.ConvertTo(lengthUnit);
            var areaUnit = UnitRelationsDictionary.GetT<LengthUnit, AreaUnit>(lengthUnit);
            return new PlanarDensity(density.Value * length.Value,
                new PlanarDensityUnit(density.Unit.CounterUnit, areaUnit));
        }

        /// <summary>
        ///     Multiplication operator
        /// </summary>
        /// <param name="density"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static PlanarDensity operator *(Length length, Density density)
        {
            var volumeUnit = UnitRelationsDictionary.GetT<LengthUnit, VolumeUnit>(length.Unit);
            density = density.ConvertTo(new DensityUnit(density.Unit.CounterUnit, volumeUnit));
            var areaUnit = UnitRelationsDictionary.GetT<LengthUnit, AreaUnit>(length.Unit);
            return new PlanarDensity(density.Value * length.Value,
                new PlanarDensityUnit(density.Unit.CounterUnit, areaUnit));
        }


        /// <summary>
        ///     Multiplication operator
        /// </summary>
        /// <param name="density"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static LinearDensity operator *(Density density, Area length)
        {
            var lengthUnit = UnitRelationsDictionary.GetT<VolumeUnit, LengthUnit>(density.Unit.DenominatorUnit);
            var areaUnit   = UnitRelationsDictionary.GetT<LengthUnit, AreaUnit>(lengthUnit);
            length = length.ConvertTo(areaUnit);
            return new LinearDensity(density.Value * length.Value, density.Unit.CounterUnit, lengthUnit);
        }

        /// <summary>
        ///     Multiplication operator
        /// </summary>
        /// <param name="density"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static LinearDensity operator *(Area length, Density density)
        {
            var lengthUnit = UnitRelationsDictionary.GetT<AreaUnit, LengthUnit>(length.Unit);
            var volumeUnit = UnitRelationsDictionary.GetT<LengthUnit, VolumeUnit>(lengthUnit);
            density = density.ConvertTo(new DensityUnit(density.Unit.CounterUnit, volumeUnit));
            return new LinearDensity(density.Value * length.Value, density.Unit.CounterUnit, lengthUnit);
        }
    }


    public partial struct PlanarDensity
    {
        /// <summary>
        ///     Multiplication operator
        /// </summary>
        /// <param name="density"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static LinearDensity operator *(PlanarDensity density, Length length)
        {
            var lengthUnit = UnitRelationsDictionary.GetT<AreaUnit, LengthUnit>(density.Unit.DenominatorUnit);
            length = length.ConvertTo(lengthUnit);
            return new LinearDensity(
                density.Value * length.Value,
                density.Unit.CounterUnit,
                lengthUnit);
        }

        /// <summary>
        ///     Multiplication operator
        /// </summary>
        /// <param name="density"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static LinearDensity operator *(Length length, PlanarDensity density)
        {
            var areaUnit = UnitRelationsDictionary.GetT<LengthUnit, AreaUnit>(length.Unit);

            density = density.ConvertTo(new PlanarDensityUnit(density.Unit.CounterUnit, areaUnit));
            return new LinearDensity(
                density.Value * length.Value,
                density.Unit.CounterUnit,
                length.Unit);
        }


        /// <summary>
        ///     Multiplication operator
        /// </summary>
        /// <param name="density"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static Weight operator *(PlanarDensity density, Area length)
        {
            length = length.ConvertTo(density.Unit.DenominatorUnit);
            return new Weight(density.Value * length.Value, density.Unit.CounterUnit);
        }

        /// <summary>
        ///     Multiplication operator
        /// </summary>
        /// <param name="density"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static Weight operator *(Area length, PlanarDensity density)
        {
            density = density.ConvertTo(new PlanarDensityUnit(density.Unit.CounterUnit, length.Unit));
            return new Weight(density.Value * length.Value, density.Unit.CounterUnit);
        }
    }


    public partial struct LinearDensity
    {
        /// <summary>
        ///     Multiplication operator
        /// </summary>
        /// <param name="density"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static Weight operator *(LinearDensity density, Length length)
        {
            length = length.ConvertTo(density.Unit.DenominatorUnit);
            return new Weight(density.Value * length.Value, density.Unit.CounterUnit);
        }

        /// <summary>
        ///     Multiplication operator
        /// </summary>
        /// <param name="density"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static Weight operator *(Length length, LinearDensity density)
        {
            density = density.ConvertTo(new LinearDensityUnit(density.Unit.CounterUnit, length.Unit));
            return new Weight(density.Value * length.Value, density.Unit.CounterUnit);
        }
    }
}