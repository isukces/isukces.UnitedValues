using System;

namespace iSukces.UnitedValues
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class RelatedUnitSourceAttribute : Attribute
    {
        public RelatedUnitSourceAttribute(RelatedUnitSourceUsage usage = RelatedUnitSourceUsage.Default)
        {
            Usage = usage;
        }

        public RelatedUnitSourceUsage Usage { get; }
    }

    [Flags]
    public enum RelatedUnitSourceUsage
    {
        /// <summary>
        ///     Yes for properties, no for methods
        /// </summary>
        Default,
        DoNotUse,
        ProvidesRelatedUnit
    }
}