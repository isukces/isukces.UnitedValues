// ReSharper disable All
// generator: ProductUnitGenerator
using System;
using System.Globalization;

namespace iSukces.UnitedValues
{
    public partial struct TorqueUnit : IProductUnit<ForceUnit, LengthUnit>, IEquatable<TorqueUnit>
    {
        /// <summary>
        /// creates instance of TorqueUnit
        /// </summary>
        /// <param name="leftUnit">left unit</param>
        /// <param name="rightUnit">right unit</param>
        public TorqueUnit(ForceUnit leftUnit, LengthUnit rightUnit)
        {
            LeftUnit = leftUnit;
            RightUnit = rightUnit;
        }

        public bool Equals(TorqueUnit other)
        {
            return LeftUnit.Equals(other.LeftUnit) && RightUnit.Equals(other.RightUnit);
        }

        public override bool Equals(object other)
        {
            return other is TorqueUnit unitedValue ? Equals(unitedValue) : false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (LeftUnit.GetHashCode() * 397) ^ RightUnit.GetHashCode();
            }
        }

        /// <summary>
        /// Returns unit name
        /// </summary>
        public override string ToString()
        {
            return UnitName;
        }

        public TorqueUnit WithLeftUnit(ForceUnit newUnit)
        {
            // generator : ProductUnitGenerator.Add_WithSecond
            return new TorqueUnit(newUnit, RightUnit);
        }

        public TorqueUnit WithRightUnit(LengthUnit newUnit)
        {
            // generator : ProductUnitGenerator.Add_WithFirst
            return new TorqueUnit(LeftUnit, newUnit);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(TorqueUnit left, TorqueUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(TorqueUnit left, TorqueUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// left unit
        /// </summary>
        public ForceUnit LeftUnit { get; }

        /// <summary>
        /// right unit
        /// </summary>
        public LengthUnit RightUnit { get; }

        public string UnitName
        {
            get { return LeftUnit.UnitName + RightUnit.UnitName; }
        }

    }
}
