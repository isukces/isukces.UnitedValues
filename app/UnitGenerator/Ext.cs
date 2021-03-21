using iSukces.Code;

namespace UnitGenerator
{
    public static class Ext
    {
        public static CsMethod AddOperator(this CsClass cl, string operatorName, params string[] args)
        {
            var arg = string.Join(", ", args);
            return cl.AddMethod(operatorName, cl.Name, "implements " + operatorName + " operator")
                .WithBodyFromExpression($"new {cl.Name}({arg})");
        }

        public static CsMethod WithBodyFromAssignment(this CsMethod method, string variable, string code)
        {
            method.Body = $"{variable} = {code};";
            return method;
        }

        public static CsMethod WithBodyFromExpression(this CsMethod method, string code)
        {
            method.Body = $"return {code};";
            return method;
        }

        public static CsMethod WithLeftRightArguments(this CsMethod method, string leftType, string rightType,
            string leftName = "left",
            string rightName = "right")
        {
            method.AddParam(leftName, leftType);
            method.AddParam(rightName, rightType);
            return method;
        }
    }
}