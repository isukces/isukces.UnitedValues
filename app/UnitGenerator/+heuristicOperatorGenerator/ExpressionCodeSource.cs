using System.Collections.Generic;

namespace UnitGenerator
{
    internal class ExpressionCodeSource : ICodeSource, IReducable
    {
        public ExpressionCodeSource(TreeExpression treeCode, bool dependsOnLeftArgument)
        {
            TreeCode              = treeCode;
            DependsOnLeftArgument = dependsOnLeftArgument;
        }

        /*
        public void AddToDeleteMe(ExpressionsReductor reductor)
        {
            TreeCode.AddToDeleteMe(reductor);
        }
        */

        public IEnumerable<ExpressionPath> GetUsedExpressions()
        {
            return TreeCode.GetUsedExpressions();
        }

        public void UpdateFromReduction(ExpressionPath expression, string varName)
        {
            TreeCode.UpdateFromReduction(expression, varName);
        }


        public TreeExpression TreeCode { get; }

        public bool DependsOnLeftArgument { get; }

        public string Code => TreeCode.Code;
    }
}