using System.Collections.Generic;

namespace UnitGenerator
{
    internal class MultiplicationAlgebraConfig
    {
        public MultiplicationAlgebraConfig WithDiv<T1, T2, TDiv>(bool areRelatedUnits)
        {
            var x = new MultiplicationAlgebraConfigItem(
                new TypesGroup(typeof(T1).Name),
                new TypesGroup(typeof(T2).Name),
                new TypesGroup(typeof(TDiv).Name),
                areRelatedUnits
            );
            Items.Add(x);
            return this;
        }

        public MultiplicationAlgebraConfig WithMul<T1, T2, TMul>(bool areRelatedUnits)
        {
            // T1/T2 = TMul
            // TMul * T2 = T1
            var x = new MultiplicationAlgebraConfigItem(
                new TypesGroup(typeof(TMul).Name),
                new TypesGroup(typeof(T2).Name),
                new TypesGroup(typeof(T1).Name),
                areRelatedUnits
            );
            Items.Add(x);
            return this;
        }

        public List<MultiplicationAlgebraConfigItem> Items { get; } = new List<MultiplicationAlgebraConfigItem>();
    }
}