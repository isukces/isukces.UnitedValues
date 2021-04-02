using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace UnitGenerator
{
    public class TreeExpression : ICodeSource1, IReducable
    {
        private string _override;

        public TreeExpression(ExpressionPath path, IReadOnlyList<ExpressionPath> arguments, Kind2 kind)
        {
            Path      = path;
            Kind      = kind;
            Arguments = arguments ?? new ExpressionPath[0];
        }

        public IEnumerable<ExpressionPath> GetUsedExpressions()
        {
            if (!(_override is null))
                yield break;
            if (Kind != Kind2.Method)
            {
                yield return Path;
                yield break;
            }

            foreach (var i in Arguments)
                yield return i;
            var a=  FullMethods;
            if (a != null)
               yield return a;
        }
 

        public override string ToString()
        {
            return Code;
        }

        public void UpdateFromReduction(ExpressionPath expression, string varName)
        {
            if (_override != null)
                return;
            var full = FullMethods;
            if (expression.Equals(full))
            {
                _override = varName;
                return;
            }
            Path.UpdateFromReduction(expression, varName);
            if (Kind != Kind2.Method)
                return;
            foreach (var i in Arguments) i.Reduce(expression, varName);
            // Arguments                = Arguments.Select(dict.Reduce).ToArray();
        }

        [CanBeNull]
        private ExpressionPath FullMethods
        {
            get
            {
                if (Kind != Kind2.Method)
                    return null;
                var args = Args.Make(Arguments, a => a.Code);
                // return args.CallMethod(Path.Code);

                if (Path.Parts.Length == 1)
                {
                    var mn   = Path.Parts.Single();
                    var code = args.CallMethod(mn.Code);
                    return ExpressionPath.FromSingleElement(code);
                }
                else
                {
                    var tmp  = Path.Parts.Take(Path.Dots).ToList();
                    var mn   = Path.Parts.Last();
                    var code = args.CallMethod(mn.Code);
                    tmp.Add(new SimpleCodeSource(code));
                    return new ExpressionPath(tmp.ToArray());
                }
            }
        }

        public ExpressionPath Path       { get;  }
        public Kind2          Kind       { get; }
   
        [NotNull]
        public IReadOnlyList<ExpressionPath> Arguments { get;  }

        public string Code
        {
            get
            {
                if (_override != null)
                    return _override;
                if (Kind == Kind2.Method)
                {
                    var args = Args.Make(Arguments, a => a.Code);
                    return args.CallMethod(Path.Code);
                }

                if (Arguments.Any())
                    throw new NotSupportedException();
                return Path.Code;
            }
        }
    }
}