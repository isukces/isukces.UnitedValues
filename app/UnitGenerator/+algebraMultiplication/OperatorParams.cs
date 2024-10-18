using iSukces.Code;

namespace UnitGenerator
{
    public class OperatorParamsBase
    {
        public OperatorParamsBase(TypesGroup left, TypesGroup right, TypesGroup result, string leftMethodArgumentName,
            string rightMethodArgumentName, string oper)
        {
            Left                    = left;
            Right                   = right;
            Result                  = result;
            LeftMethodArgumentName  = leftMethodArgumentName;
            RightMethodArgumentName = rightMethodArgumentName;
            Oper                    = oper;
        }

        public bool Is<TLeft, TRight, TResult>(string oper)
        {
            if (!Left.IsValue<TLeft>()) return false;
            if (!Right.IsValue<TRight>()) return false;
            if (!Result.IsValue<TResult>()) return false;
            return Oper == oper;
        }

        public override string ToString()
        {
            var l          = Left.Value + " " + LeftMethodArgumentName;
            var r          = Right.Value + " " + RightMethodArgumentName;
            var args       = new CsArguments(l, r);
            var methodName = $"{Result.Value} operator {Oper}";
            return args.CallMethod(methodName);
        }

        public string DebugIs
        {
            get
            {
                // .Is<LinearDensity, Length, PlanarDensity>("/")
                var a = new CsArguments(Left.Value.ValueTypeName, Right.Value.ValueTypeName, Result.Value.ValueTypeName)
                    .MakeGenericType(".Is")
                    .Declaration;
                var b = new CsArguments(Oper.CsEncode()).CallMethod(a);
                return b;
            }
        }
        
        public TypesGroup Left                    { get; }
        public TypesGroup Right                   { get; }
        public TypesGroup Result                  { get; }
        public string     LeftMethodArgumentName  { get; }
        public string     RightMethodArgumentName { get; }
        public string     Oper                    { get; }
    }

    public class OperatorParams : OperatorParamsBase
    {
        public OperatorParams(TypesGroup left, TypesGroup right, TypesGroup result, string leftMethodArgumentName,
            string rightMethodArgumentName, string oper, OperatorHints operatorHints) : base(left, right, result,
            leftMethodArgumentName, rightMethodArgumentName, oper)
        {
            OperatorHints = operatorHints;
        }


        public OperatorCodeBuilderInput GetBuilder()
        {
            if (OperatorHints is null)
                return null;
            return OperatorHints.GetBuilder(this);
        }

        public OperatorHints OperatorHints { get; }
    }
}