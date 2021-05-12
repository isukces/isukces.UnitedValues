using System;
using iSukces.Code;
using iSukces.Code.Interfaces;

namespace UnitGenerator
{
    internal class OperatorCodeBuilder
    {
        public OperatorCodeBuilder(OperatorCodeBuilderInput input)
        {
            _input = input;
        }

        public void WriteCode(CsCodeWriter cw)
        {
            if (!string.IsNullOrEmpty(_input.Comment))
                cw.WriteLine("// " + _input.Comment);
            if (_input.Throw)
            {
                cw.WriteLine("// " + _input.OperatorParameters.DebugIs);
                cw.WriteLine("throw new " + nameof(NotImplementedException) + "();");
                return;
            }

            var right = OperatorParameters.RightMethodArgumentName;
            var left  = OperatorParameters.LeftMethodArgumentName;

            foreach (var i in _input.Vars)
                cw.WriteAssign(i.Name, i.Code, true);
            if (!string.IsNullOrEmpty(RightValue))
            {
                right += "Converted";
                cw.WriteAssign(right, RightValue, true);
            }

            if (string.IsNullOrEmpty(_input.UseReturnExpression))
            {
                var value = string.IsNullOrEmpty(_input.UseValueExpression)
                    ? $"{left}.Value {OperatorParameters.Oper} {right}.Value"
                    : _input.UseValueExpression;
                if (!string.IsNullOrEmpty(_input.ResultMultiplication))
                    value += " * " + _input.ResultMultiplication;
                cw.WriteAssign("value", value, true);

                var code = new CsArguments("value", ResultUnit).Create(OperatorParameters.Result.Value.ValueTypeName);
                cw.WriteReturn(code);
            } else
                cw.WriteReturn(_input.UseReturnExpression);
        }

        private OperatorParamsBase OperatorParameters => _input.OperatorParameters;
        private string             RightValue         => _input.RightValue;
        private string             ResultUnit         => _input.ResultUnit;
        private readonly OperatorCodeBuilderInput _input;
    }
}