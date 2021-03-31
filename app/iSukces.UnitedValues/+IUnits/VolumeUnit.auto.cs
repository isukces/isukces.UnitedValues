// ReSharper disable All
// generator: BasicUnitGenerator
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.UnitedValues
{
    [Serializable]
    public partial class VolumeUnit : IUnit, IEquatable<VolumeUnit>, IDecomposableUnit, IDerivedDecomposableUnit
    {
        /// <summary>
        /// creates instance of VolumeUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public VolumeUnit(string unitName)
        {
            if (unitName is null)
                throw new NullReferenceException(nameof(unitName));
            unitName = unitName.Trim();
            if (unitName.Length == 0)
                throw new ArgumentException(nameof(unitName));
            UnitName = unitName?.Replace('3', '³');
        }

        /// <summary>
        /// creates instance of VolumeUnit
        /// </summary>
        /// <param name="baseUnit">based on</param>
        /// <param name="unitName">name of unit</param>
        public VolumeUnit(LengthUnit baseUnit, string unitName = null)
        {
            if (baseUnit is null)
                throw new NullReferenceException(nameof(baseUnit));
            BaseUnit = baseUnit;
            unitName = unitName?.Trim();
            UnitName = string.IsNullOrEmpty(unitName) ? baseUnit.UnitName + "³" : unitName;
        }

        public IReadOnlyList<DecomposableUnitItem> Decompose()
        {
            // generator : BasicUnitGenerator.Add_Decompose
            return new[] { GetBasicUnit() };
        }

        public bool Equals(VolumeUnit other)
        {
            return String.Equals(UnitName, other?.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is VolumeUnit tmp && Equals(tmp);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AreaUnit GetAreaUnit()
        {
            // generator : BasicUnitGenerator.Add_ConvertOtherPower
            return GlobalUnitRegistry.Relations.GetOrThrow<VolumeUnit, AreaUnit>(this);
        }

        public DecomposableUnitItem GetBasicUnit()
        {
            // generator : BasicUnitGenerator.Add_Decompose
            var tmp = GetLengthUnit();
            return new DecomposableUnitItem(tmp, 3);
        }

        public override int GetHashCode()
        {
            return UnitName?.GetHashCode() ?? 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LengthUnit GetLengthUnit()
        {
            // generator : BasicUnitGenerator.Add_ConvertOtherPower
            return GlobalUnitRegistry.Relations.GetOrThrow<VolumeUnit, LengthUnit>(this);
        }

        /// <summary>
        /// Returns unit name
        /// </summary>
        public override string ToString()
        {
            return UnitName;
        }

        bool IEquatable<VolumeUnit>.Equals(VolumeUnit other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(VolumeUnit left, VolumeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(VolumeUnit left, VolumeUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts UnitDefinition&lt;VolumeUnit&gt; into VolumeUnit implicitly.
        /// </summary>
        /// <param name="src"></param>
        public static implicit operator VolumeUnit(UnitDefinition<VolumeUnit> src)
        {
            return src.Unit;
        }

        /// <summary>
        /// name of unit
        /// </summary>
        public string UnitName { get; }

        /// <summary>
        /// based on
        /// </summary>
        public LengthUnit BaseUnit { get; }

    }
}
