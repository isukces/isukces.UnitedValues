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

        public void WriteCode(CodeWriter cw)
        {
            if (!string.IsNullOrEmpty(_input.Comment))
                cw.WriteLine("// " + _input.Comment);
            var right = OperatorParameters.RightMethodArgumentName;
            var left  = OperatorParameters.LeftMethodArgumentName;

            foreach (var i in _input.Vars)
                cw.WriteAssign(i.Name, i.Code, true);
            if (!string.IsNullOrEmpty(RightValue))
            {
                right += "Converted";
                cw.WriteAssign(right, RightValue, true);
            }

            cw.WriteAssign("value", $"{right}.Value * {left}.Value", true);

            var code = new Args("value", ResultUnit).Create(OperatorParameters.Result.Value.ValueTypeName);
            cw.WriteReturn(code);
        }

        private OperatorParamsBase OperatorParameters => _input.OperatorParameters;
        private string             RightValue         => _input.RightValue;
        private string             ResultUnit         => _input.ResultUnit;
        private readonly OperatorCodeBuilderInput _input;
    }
}