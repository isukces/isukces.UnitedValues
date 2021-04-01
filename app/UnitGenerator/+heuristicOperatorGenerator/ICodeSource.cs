using System.Collections.Generic;

namespace UnitGenerator
{
    interface ICodeSource
    {
        string Code { get; }
        void AddTo(ExpressionsReductor reductor);
        void Reduce(ExpressionsReductor.ReductionResult dict);
        
        bool DependsOnLeftArgument { get; }
    }
}