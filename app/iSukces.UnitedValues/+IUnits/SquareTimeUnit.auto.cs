// ReSharper disable All
// generator: BasicUnitGenerator
using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.UnitedValues
{
    [Serializable]
    public partial class SquareTimeUnit : IUnit, IEquatable<SquareTimeUnit>, IDecomposableUnit, IDerivedDecomposableUnit
    {
        /// <summary>
        /// creates instance of SquareTimeUnit
        /// </summary>
        /// <param name="unitName">name of unit</param>
        public SquareTimeUnit(string unitName)
        {
            if (unitName is null)
                throw new NullReferenceException(nameof(unitName));
            unitName = unitName.Trim();
            if (unitName.Length == 0)
                throw new ArgumentException(nameof(unitName));
            UnitName = unitName;
        }

        /// <summary>
        /// creates instance of SquareTimeUnit
        /// </summary>
        /// <param name="baseUnit">based on</param>
        /// <param name="unitName">name of unit</param>
        public SquareTimeUnit(TimeUnit baseUnit, string unitName = null)
        {
            if (baseUnit is null)
                throw new NullReferenceException(nameof(baseUnit));
            BaseUnit = baseUnit;
            unitName = unitName?.Trim();
            UnitName = string.IsNullOrEmpty(unitName) ? baseUnit.UnitName + "²" : unitName;
        }

        public System.Collections.Generic.IReadOnlyList<DecomposableUnitItem> Decompose()
        {
            // generator : BasicUnitGenerator.Add_Decompose
            return new[] { GetBasicUnit() };
        }

        public bool Equals(SquareTimeUnit other)
        {
            return String.Equals(UnitName, other?.UnitName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is SquareTimeUnit tmp && Equals(tmp);
        }

        public DecomposableUnitItem GetBasicUnit()
        {
            // generator : BasicUnitGenerator.Add_Decompose
            var tmp = GetTimeUnit();
            return new DecomposableUnitItem(tmp, 2);
        }

        public override int GetHashCode()
        {
            return UnitName?.GetHashCode() ?? 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TimeUnit GetTimeUnit()
        {
            // generator : BasicUnitGenerator.Add_ConvertOtherPower
            return GlobalUnitRegistry.Relations.GetOrThrow<SquareTimeUnit, TimeUnit>(this);
        }

        /// <summary>
        /// Returns unit name
        /// </summary>
        public override string ToString()
        {
            return UnitName;
        }

        bool IEquatable<SquareTimeUnit>.Equals(SquareTimeUnit other)
        {
            return Equals(other);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(SquareTimeUnit left, SquareTimeUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(SquareTimeUnit left, SquareTimeUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Converts UnitDefinition&lt;SquareTimeUnit&gt; into SquareTimeUnit implicitly.
        /// </summary>
        /// <param name="src"></param>
        public static implicit operator SquareTimeUnit(UnitDefinition<SquareTimeUnit> src)
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
        public TimeUnit BaseUnit { get; }

    }
}
