using System;

namespace iSukces.UnitedValues
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class RelatedUnitSourceAttribute : Attribute
    {
        public RelatedUnitSourceAttribute(RelatedUnitSourceUsage usage = RelatedUnitSourceUsage.Default,
            int sortOrder=10)
        {
            Usage     = usage;
            SortOrder = sortOrder;
        }

        public RelatedUnitSourceUsage Usage { get; }
        
        public int SortOrder { get; }
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