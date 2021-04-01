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
    public partial class AreaUnit : IUnit, IEquatable<AreaUnit>, IDecomposableUnit, IDerivedDecomposableUnit
    {
        /// <summary>
        /// creates instance of AreaUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public AreaUnit(string unitName)
        {
            if (unitName is null)
                throw new NullReferenceException(nameof(unitName));
            unitName = unitName.Trim();
            if (unitName.Length == 0)
                throw new ArgumentException(nameof(unitName));
            UnitName = unitName?.Replace('2', '²');
        }

        /// <summary>
        /// creates instance of AreaUnit
        /// </summary>
        /// <param name="baseUnit">based on</param>
        /// <param name="unitName">name of unit</param>
        public AreaUnit(LengthUnit baseUnit, string unitName = null)
        {
            if (baseUnit is null)
                throw new NullReferenceException(nameof(baseUnit));
            BaseUnit = baseUnit;
            unitName = unitName?.Trim();
            UnitName = string.IsNullOrEmpty(unitName) ? baseUnit.UnitName + "²" : unitName;
        }

        public IReadOnlyList<DecomposableUnitItem> Decompose()
        {
            // generator : BasicUnitGenerator.Add_Decompose
            return new[] { GetBasicUnit() };
        }

        public bool Equals(AreaUnit other)
        {
            return String.Equals(UnitName, other?.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is AreaUnit tmp && Equals(tmp);
        }

        public DecomposableUnitItem GetBasicUnit()
        {
            // generator : BasicUnitGenerator.Add_Decompose
            var tmp = GetLengthUnit();
            return new DecomposableUnitItem(tmp, 2);
        }

        public override int GetHashCode()
        {
            return UnitName?.GetHashCode() ?? 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [RelatedUnitSource(RelatedUnitSourceUsage.ProvidesRelatedUnit)]
        public LengthUnit GetLengthUnit()
        {
            // generator : BasicUnitGenerator.Add_ConvertOtherPower
            return GlobalUnitRegistry.Relations.GetOrThrow<AreaUnit, LengthUnit>(this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [RelatedUnitSource(RelatedUnitSourceUsage.ProvidesRelatedUnit)]
        public VolumeUnit GetVolumeUnit()
        {
            // generator : BasicUnitGenerator.Add_ConvertOtherPower
            return GlobalUnitRegistry.Relations.GetOrThrow<AreaUnit, VolumeUnit>(this);
        }

        /// <summary>
        /// Returns unit name
        /// </summary>
        public override string ToString()
        {
            return UnitName;
        }

        bool IEquatable<AreaUnit>.Equals(AreaUnit other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(AreaUnit left, AreaUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(AreaUnit left, AreaUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts UnitDefinition&lt;AreaUnit&gt; into AreaUnit implicitly.
        /// </summary>
        /// <param name="src"></param>
        public static implicit operator AreaUnit(UnitDefinition<AreaUnit> src)
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
        [RelatedUnitSource(RelatedUnitSourceUsage.DoNotUse)]
        public LengthUnit BaseUnit { get; }

    }
}
