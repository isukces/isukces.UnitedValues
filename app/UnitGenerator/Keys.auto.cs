// ReSharper disable All
using System;

namespace UnitGenerator
{
    public partial class XUnitContainerTypeName
    {
        public XUnitContainerTypeName(string typeName)
        {
            if (typeName is null)
                throw new NullReferenceException(nameof(typeName));
            if (typeName.Length == 0)
                throw new ArgumentException(nameof(typeName));
            TypeName = typeName.Trim();
        }

        public bool Equals(XUnitContainerTypeName other)
        {
            return TypeName.Equals(other.TypeName);
        }

        public override bool Equals(object obj)
        {
            return obj is XUnitContainerTypeName s && StringComparer.Ordinal.Equals(TypeName, s.TypeName);
        }

        public override int GetHashCode()
        {
            return TypeName.GetHashCode();
        }

        public override string ToString()
        {
            return TypeName;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(XUnitContainerTypeName left, XUnitContainerTypeName right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(XUnitContainerTypeName left, XUnitContainerTypeName right)
        {
            return left.Equals(right);
        }

        public string TypeName { get; }

    }

    public partial class XUnitTypeName
    {
        public XUnitTypeName(string typeName)
        {
            if (typeName is null)
                throw new NullReferenceException(nameof(typeName));
            if (typeName.Length == 0)
                throw new ArgumentException(nameof(typeName));
            TypeName = typeName.Trim();
        }

        public bool Equals(XUnitTypeName other)
        {
            return TypeName.Equals(other.TypeName);
        }

        public override bool Equals(object obj)
        {
            return obj is XUnitTypeName s && StringComparer.Ordinal.Equals(TypeName, s.TypeName);
        }

        public override int GetHashCode()
        {
            return TypeName.GetHashCode();
        }

        public override string ToString()
        {
            return TypeName;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(XUnitTypeName left, XUnitTypeName right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(XUnitTypeName left, XUnitTypeName right)
        {
            return left.Equals(right);
        }

        public string TypeName { get; }

    }

    public partial class XValueTypeName
    {
        public XValueTypeName(string valueTypeName)
        {
            if (valueTypeName is null)
                throw new NullReferenceException(nameof(valueTypeName));
            if (valueTypeName.Length == 0)
                throw new ArgumentException(nameof(valueTypeName));
            ValueTypeName = valueTypeName.Trim();
        }

        public bool Equals(XValueTypeName other)
        {
            return ValueTypeName.Equals(other.ValueTypeName);
        }

        public override bool Equals(object obj)
        {
            return obj is XValueTypeName s && StringComparer.Ordinal.Equals(ValueTypeName, s.ValueTypeName);
        }

        public override int GetHashCode()
        {
            return ValueTypeName.GetHashCode();
        }

        public override string ToString()
        {
            return ValueTypeName;
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator !=(XValueTypeName left, XValueTypeName right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="left">first value to compare</param>
        /// <param name="right">second value to compare</param>
        public static bool operator ==(XValueTypeName left, XValueTypeName right)
        {
            return left.Equals(right);
        }

        public string ValueTypeName { get; }

    }
}
