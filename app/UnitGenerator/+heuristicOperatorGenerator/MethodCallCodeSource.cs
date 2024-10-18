using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System;

namespace UnitGenerator;

internal class MethodCallCodeSource : ICodeSource, IReducable
{
    public MethodCallCodeSource(string callMethod, ICodeSource1[] constructorArgs, bool dependsOnLeftArgument)
    {
        CallMethod            = callMethod;
        ConstructorArgs       = constructorArgs;
        DependsOnLeftArgument = dependsOnLeftArgument;
    }

    public static MethodCallCodeSource Make(MethodInfo methodInfo,
        IReadOnlyList<ValueOfSomeTypeExpression> arguments, bool dependsOnLeftArgument)
    {
        var call = methodInfo.ReflectedType.Name + "." + methodInfo.Name;
        var ar   = arguments.Select(a => (ICodeSource1)a.Expression).ToArray();
        return new MethodCallCodeSource(call, ar, dependsOnLeftArgument);
    }

    public static ICodeSource MakeFromConstructor(XUnitTypeName unit,
        IReadOnlyList<ValueOfSomeTypeExpression> arguments, bool dependsOnLeftArgument)
    {
        var call = "new " + unit.GetTypename();
        var ar   = arguments.Select(a => (ICodeSource1)a.Expression).ToArray();
        return new MethodCallCodeSource(call, ar, dependsOnLeftArgument);
    }

    /*public void AddToDeleteMe(ExpressionsReductor reductor)
    {
        foreach (var i in ConstructorArgs)
            i.AddToDeleteMe(reductor);
    }
    */

         
    public bool DependsOnLeftArgument { get; }

    private string         CallMethod      { get; }
    private ICodeSource1[] ConstructorArgs { get; }

    public string Code
    {
        get
        {
            if (string.IsNullOrEmpty(_override))
                return new CsArguments(ConstructorArgs.Select(a => a.Code)).CallMethod(CallMethod);
            return _override;
        }
    }

    private string _override; 
    public IEnumerable<ExpressionPath> GetUsedExpressions()
    {
        yield return new ExpressionPath(new SimpleCodeSource(Code));
        foreach (var i in ConstructorArgs)
        {
            if (i is IReducable r)
                foreach (var ii in r.GetUsedExpressions())
                    yield return ii;
            else
                throw new NotImplementedException();
        }
    }

    public override string ToString()
    {
        return Code;
    }

    public void UpdateFromReduction(ExpressionPath expression, string varName)
    {
        if (!(_override is null)) return;
        if (expression.Code == Code)
        {
            _override = varName;
            return;
        }

        foreach (var i in ConstructorArgs)
        {
            if (i is IReducable te)
                te.UpdateFromReduction(expression, varName);
            else
                throw new System.NotImplementedException();
        } 
    }
}