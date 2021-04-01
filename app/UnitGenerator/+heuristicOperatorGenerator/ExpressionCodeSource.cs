using System.Collections.Generic;

namespace UnitGenerator
{
    internal class ExpressionCodeSource : ICodeSource
    {
        public ExpressionCodeSource(string code, bool dependsOnLeftArgument)
        {
            Code                       = code;
            DependsOnLeftArgument = dependsOnLeftArgument;
        }

        public void AddTo(ExpressionsReductor reductor)
        {
            reductor.Add(Code);
        }

        public void Reduce(ExpressionsReductor.ReductionResult dict)
        {
            Code = dict.Reduce(Code);
        }

        public bool DependsOnLeftArgument { get; }

        public string Code { get; set; }
    }
}