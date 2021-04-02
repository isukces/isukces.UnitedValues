using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitGenerator
{
    public interface IReducable
    {
        IEnumerable<ExpressionPath> GetUsedExpressions();
        void UpdateFromReduction(ExpressionPath expression, string varName);
    }
    
    public class ExpressionsReductor
    {
        public ExpressionsReductor(Func<string, string> addVariable)
        {
            AddVariable = addVariable;
        }


        private static ExpressionPath GetExpressionForReducing(IReducable[] arguments)
        {
            var expressions = arguments.SelectMany(a =>
            {
                var g = a.GetUsedExpressions().ToArray();
                return g;
            }).ToArray();
            if (expressions.Any())
            {
                var maxDots = expressions.Select(a => a.Dots).Max();
                for (var dots = 1; dots <= maxDots; dots++)
                {
                    var tmpDotsCount = dots;
                    var grouppedExpressions = KeyWithCount
                        .MakeList(expressions, a => a.GetByDotsCounts(tmpDotsCount));
                    var expressionToReduce = grouppedExpressions.Where(a => a.Count > 1).ToArray();
                    if (expressionToReduce.Length > 0)
                        return expressionToReduce[0].Key;
                }
            }

            var methodReductor = KeyWithCount.MakeList(expressions, q =>
            {
                if (q.LooksLikeMethodCall)
                    return q;
                return null;
            });
            if (methodReductor.Length > 0)
                return methodReductor[0].Key;
            return null;
        }

        public void AddAny(object e)
        {
            switch (e)
            {
                case null:
                    return;
                case IReducable r:
                    Add(r);
                    break;
                default:
                    break;
            }
        }
        public void Add(IReducable expression)
        {
            _expressions.Add(expression);
        }

        public void ReduceExpressions()
        {
            var reducedArray = _expressions.ToArray();
            while (true)
            {
                var expression = GetExpressionForReducing(reducedArray);
                if (expression is null)
                    return;
                ReduceOne(reducedArray, expression);
            }
        }



        private void ReduceOne(IReducable[] arguments, ExpressionPath expression)
        {
            var varName = AddVariable(expression.Code);
            for (var index = 0; index < arguments.Length; index++)
            {
                var src = arguments[index];
                src.UpdateFromReduction(expression, varName);
            }
        }

        private Func<string, string> AddVariable { get; }

        private readonly List<IReducable> _expressions = new List<IReducable>();

        public void ForceReduce(ExpressionPath expression)
        {
            var reducedArray = _expressions.ToArray();
            ReduceOne(reducedArray, expression);
        }
    }
}