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
    public partial class LengthUnit : IUnit, IEquatable<LengthUnit>
    {
        /// <summary>
        /// creates instance of LengthUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public LengthUnit(string unitName)
        {
            if (unitName is null)
                throw new NullReferenceException(nameof(unitName));
            unitName = unitName.Trim();
            if (unitName.Length == 0)
                throw new ArgumentException(nameof(unitName));
            UnitName = unitName;
        }

        public bool Equals(LengthUnit other)
        {
            return String.Equals(UnitName, other?.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LengthUnit tmp && Equals(tmp);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AreaUnit GetAreaUnit()
        {
            // generator : BasicUnitGenerator.Add_ConvertOtherPower
            return GlobalUnitRegistry.Relations.GetOrThrow<LengthUnit, AreaUnit>(this);
        }

        public override int GetHashCode()
        {
            return UnitName?.GetHashCode() ?? 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public VolumeUnit GetVolumeUnit()
        {
            // generator : BasicUnitGenerator.Add_ConvertOtherPower
            return GlobalUnitRegistry.Relations.GetOrThrow<LengthUnit, VolumeUnit>(this);
        }

        /// <summary>
        /// Returns unit name
        /// </summary>
        public override string ToString()
        {
            return UnitName;
        }

        bool IEquatable<LengthUnit>.Equals(LengthUnit other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(LengthUnit left, LengthUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(LengthUnit left, LengthUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts UnitDefinition&lt;LengthUnit&gt; into LengthUnit implicitly.
        /// </summary>
        /// <param name="src"></param>
        public static implicit operator LengthUnit(UnitDefinition<LengthUnit> src)
        {
            return src.Unit;
        }

        /// <summary>
        /// name of unit
        /// </summary>
        public string UnitName { get; }

    }
}
