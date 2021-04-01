using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitGenerator
{
    internal class ExpressionsReductor
    {
        public ExpressionsReductor(Func<string, string> addVariable)
        {
            AddVariable = addVariable;
        }


        private static string GetReduceExpression(ExpressionPath[] arguments)
        {
            var maxDots = arguments.Select(a => a.Dots).Max();
            for (var dots = 1; dots < maxDots; dots++)
            {
                var tmpDotsCount = dots;
                var grouppedExpressions = KeyWithCount
                    .MakeList(arguments, a => a.GetByDotsCounts(tmpDotsCount));
                var expressionToReduce = grouppedExpressions.Where(a => a.Count > 1).ToArray();
                if (expressionToReduce.Length > 0)
                    return expressionToReduce[0].Key;
            }

            var methodReductor = KeyWithCount.MakeList(arguments, q =>
            {
                var path = q.Path;
                return path.EndsWith("()", StringComparison.Ordinal) ? path : null;
            });
            if (methodReductor.Length > 0)
                return methodReductor[0].Key;
            return null;
        }


        public void Add(string expression)
        {
            _expressions.Add(expression);
        }

        public ReductionResult GetReduced()
        {
            var runAgain              = true;
            var reducedArray          = _expressions.Select(a => (ExpressionPath)a).ToArray();
            while (runAgain) runAgain = ReduceSinglePass(reducedArray);

            var dictionary = new Dictionary<string, string>();
            for (var index = 0; index < _expressions.Count; index++)
            {
                var source  = _expressions[index];
                var resuced = reducedArray[index].Path;
                dictionary[source] = resuced;
            }

            return new ReductionResult(dictionary);
        }

        private bool ReduceSinglePass(ExpressionPath[] arguments)
        {
            var expression = GetReduceExpression(arguments);
            if (expression is null)
                return false;
            var varName1 = AddVariable(expression);
            for (var index = 0; index < arguments.Length; index++)
            {
                var text = arguments[index].Path;
                if (text == expression)
                    arguments[index] = (ExpressionPath)varName1;
                else if (text.StartsWith(expression + ".", StringComparison.Ordinal))
                    arguments[index] = (ExpressionPath)(varName1 + text.Substring(expression.Length));
            }

            return true;
        }

        private Func<string, string> AddVariable { get; }

        private readonly List<string> _expressions = new List<string>();


        internal class ReductionResult
        {
            public ReductionResult(IReadOnlyDictionary<string, string> dictionary)
            {
                _dictionary = dictionary;
            }

            public string Reduce(string x)
            {
                if (_dictionary.TryGetValue(x, out var y))
                    return y;
                return x;
            }

            private readonly IReadOnlyDictionary<string, string> _dictionary;
        }
    }
}