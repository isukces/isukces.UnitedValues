using System.Collections.Generic;

namespace UnitGenerator
{
    public class MultiplicationAlgebra
    {
        public MultiplicationAlgebra WithDiv<T1, T2, TDiv>(bool areRelatedUnits=false)
        {
            var x = new MultiplicationAlgebraItem(
                new TypesGroup(typeof(T1).Name),
                new TypesGroup(typeof(T2).Name),
                new TypesGroup(typeof(TDiv).Name),
                areRelatedUnits
            );
            Items.Add(x);
            return this;
        }

        public MultiplicationAlgebra WithMul<T1, T2, TMul>(bool areRelatedUnits)
        {
            // T1/T2 = TMul
            // TMul * T2 = T1
            var x = new MultiplicationAlgebraItem(
                new TypesGroup(typeof(TMul).Name),
                new TypesGroup(typeof(T2).Name),
                new TypesGroup(typeof(T1).Name),
                areRelatedUnits
            );
            Items.Add(x);
            return this;
        }

        public List<MultiplicationAlgebraItem> Items { get; } = new List<MultiplicationAlgebraItem>();
    }
}