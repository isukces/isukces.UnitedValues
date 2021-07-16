using System.Collections.Generic;

namespace UnitGenerator
{
    public class MultiplicationAlgebra
    {
        public MultiplicationAlgebra WithDiv<T1, T2, TDiv>(OperatorHints operatorHints = null,
            bool areRelatedUnits = false)
        {
            var x = new MultiplicationAlgebraItem(
                new TypesGroup(typeof(T1).Name),
                new TypesGroup(typeof(T2).Name),
                new TypesGroup(typeof(TDiv).Name),
                areRelatedUnits,
                operatorHints
            );
            Items.Add(x);
            return this;
        }

        public MultiplicationAlgebra WithMul<T1, T2, TMul>(string implementingClass, bool areRelatedUnits = false)
        {
            // T1/T2 = TMul
            // TMul * T2 = T1
            var x = new MultiplicationAlgebraItem(
                new TypesGroup(typeof(TMul).Name),
                new TypesGroup(typeof(T2).Name),
                new TypesGroup(typeof(T1).Name),
                areRelatedUnits,
                null
            );
            Items.Add(x);
            return this;
        }

        public List<MultiplicationAlgebraItem> Items { get; } = new List<MultiplicationAlgebraItem>();
    }
}