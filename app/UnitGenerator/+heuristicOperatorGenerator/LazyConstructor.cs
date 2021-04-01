using System.Collections.Generic;

namespace UnitGenerator
{
    internal class LazyConstructor:ICodeSource
    {
        public LazyConstructor(string typeName, string[] constructorArgs, bool dependsOnLeftArgument)
        {
            TypeName                   = typeName;
            ConstructorArgs            = constructorArgs;
            DependsOnLeftArgument = dependsOnLeftArgument;
        }

        public void AddTo(ExpressionsReductor tmp)
        {
            foreach (var i in ConstructorArgs)
                tmp.Add(i);
        }

        public void Reduce(ExpressionsReductor.ReductionResult dict)
        {
            for (var index = 0; index < ConstructorArgs.Length; index++)
            {
                ConstructorArgs[index] = dict.Reduce(ConstructorArgs[index]);
            }
        }

        public bool DependsOnLeftArgument { get; }

        public string   TypeName        { get; }
        public string[] ConstructorArgs { get; }
        public string   Code            {
            get
            {
                return new Args(ConstructorArgs).Create(TypeName);
            }
        }
    }
}