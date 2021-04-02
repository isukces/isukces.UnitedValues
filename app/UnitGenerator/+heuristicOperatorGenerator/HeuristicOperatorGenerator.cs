using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class HeuristicOperatorGenerator
    {
        private HeuristicOperatorGenerator(OperatorHints.CreateOperatorCodeEventArgs args, ClrTypesResolver resolver)
        {
            _args     = args;
            _resolver = resolver;
        }

        public static void TryCreate(OperatorHints.CreateOperatorCodeEventArgs args, ClrTypesResolver resolver)
        {
            var instance = new HeuristicOperatorGenerator(args, resolver);
            try
            {
                instance.TryCreateInternal();
            }
            catch
            {
                args.Handled = true;
            }
        }

        private string AddVariable(string code, string varName)
        {
            if (varName is null)
                varName = "tmp" + (++_varNumber).CsEncode();
            _args.Result.AddVariable(varName, code);
            return varName;
        }

 

        private ICodeSource Construct(XUnitTypeName unit)
        {
            if (!_resolver.TryGetValue(unit.GetTypename(), out var type1))
                throw new NotImplementedException();
 

            ValueOfSomeTypeExpression[] sources;

            var constr = type1.GetConstructors()
                .Where(a =>
                {
                    var pa = a.GetParameters();
                    foreach (var info in pa)
                        if (!info.ParameterType.Implements<IUnit>())
                            return false;
                    return true;
                })
                .OrderByDescending(a => a.GetParameters().Length)
                .ToArray();
            var typesDict = TypeFinder.Make(_sink);
            if (constr.Length == 0)
            {
                sources = typesDict.GetTypeSources(type1);
                if (sources.Any())
                {
                    var src = sources[0];
                    return new ExpressionCodeSource(src.Expression,
                        src.Root == ValueOfSomeTypeExpressionRoot.Left);
                }

                return null;
            }

            var ccc = constr[0];

 
            var list = typesDict.FindParameters(ccc, t=>Construct(new XUnitTypeName(t.Name)), out var hasLeft);

            // var hasLeft = list.Any(q => q.Root == ValueOfSomeTypeExpressionRoot.Left);
            if (!hasLeft)
            {
                sources = typesDict.GetTypeSources(type1);
                if (sources.Any())
                {
                    var src = sources[0];
                    return new ExpressionCodeSource(src.Expression,
                        src.Root == ValueOfSomeTypeExpressionRoot.Left);
                }

                throw new NotImplementedException();
            }

            return MethodCallCodeSource.MakeFromConstructor(unit, list, true);
        }

        private void Scan(ValueOfSomeTypeExpressionRoot root, XUnitTypeName x, Kind2 kind, ExpressionPath path = null)
        {
            if (!_resolver.TryGetValue(x.GetTypename(), out var type))
                throw new NotImplementedException();
            var info1 = new ValueOfSomeTypeExpression(root, type, new TreeExpression(path, null, kind), kind);
            _sink.Add(info1);
            if (kind != Kind2.Property)
                return;
            foreach (var propInfo in type.GetProperties())
            {
                var attribute = propInfo.GetCustomAttribute<RelatedUnitSourceAttribute>();
                if (attribute != null && attribute.Usage == RelatedUnitSourceUsage.DoNotUse)
                    continue;
                var pt = propInfo.PropertyType;
                if (!pt.Implements<IUnit>()) continue;
                Scan(root, new XUnitTypeName(propInfo.PropertyType.Name), kind, path + propInfo.Name);
            }

            foreach (var methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Public))
            {
                var at = methodInfo.GetCustomAttribute<RelatedUnitSourceAttribute>();
                if (at is null || (at.Usage & RelatedUnitSourceUsage.ProvidesRelatedUnit) == 0)
                    continue;
                var returnType = methodInfo.ReturnType;
                if (!returnType.Implements<IUnit>())
                    throw new Exception("Should return IUnit");
                if (methodInfo.GetParameters().Length != 0)
                    throw new Exception("Should be parameterles");
                Scan(root, new XUnitTypeName(returnType.Name), Kind2.Method, path + $"{methodInfo.Name}");
            }


        }

        private void TryCreateInternal()
        {
            if (_args.Input.Is<PlanarDensity, Length, LinearDensity>("*"))
                Debug.Write("");

            var cc = _args.Input;
            var lu = cc.LeftMethodArgumentName + ".Unit";
            var ru = cc.RightMethodArgumentName + ".Unit";

            Scan(ValueOfSomeTypeExpressionRoot.Left, cc.Left.Unit, Kind2.Property, ExpressionPath.FromSplit(lu));
            Scan(ValueOfSomeTypeExpressionRoot.Right, cc.Right.Unit, Kind2.Property, ExpressionPath.FromSplit(ru));

            _conversionMethodScanner = ConversionMethodScanner.Scan(_resolver.Assembly);

            var reductor = new ExpressionsReductor(n =>
            {
                string varName = null;
                if (n == lu || n == ru)
                    varName = n.Replace(".", "");
                return AddVariable(n, varName);
            });

            var convertType = Construct(cc.Right.Unit);
            if (convertType.Code == ru)
                convertType = null;
            else
                reductor.AddAny(convertType);
                // convertType.AddToDeleteMe(reductor);

            ICodeSource result = Construct(cc.Result.Unit);

            Func<string> addExtraValueMultiplication = null;
            ICodeSource G1()
            {
                if (!_resolver.TryGetValue(cc.Result.Unit.TypeName, out var type1))
                    throw new NotImplementedException();
                if (_conversionMethodScanner.Dictionary.TryGetValue(type1, out var list))
                {
                    var typesDict = TypeFinder.Make(_sink);
                    foreach (var i in list)
                    {
                        var aaa = typesDict.FindParameters(i, null, out var hl);
                        return  MethodCallCodeSource.Make(i, aaa, hl);
                    }
                }

                return null;
            }
            if (result is null)
            {
                result = G1();
                if (result != null)
                {
                    addExtraValueMultiplication = () => { return result.Code + "." + nameof(IUnitDefinition.Multiplication); };
                }
            }
            reductor.AddAny(result);
            //result.AddToDeleteMe(reductor);
            reductor.ReduceExpressions();
            if (addExtraValueMultiplication != null)
            {
                reductor.ForceReduce(new ExpressionPath(result));
            }


            // =============================
            if (result.Code == "specificHeatCapacity.Unit.DenominatorUnit")
                Debug.WriteLine("");
            switch (convertType)
            {
                case null:
                    break;
                case MethodCallCodeSource _:
                    _args.Result.ConvertRight(AddVariable(convertType.Code, "targetRightUnit"));
                    break;
                default:
                    _args.Result.ConvertRight(convertType.Code);
                    break;
            }

            if (result is MethodCallCodeSource)
                _args.Result.ResultUnit = AddVariable(result.Code, "resultUnit");
            else
                _args.Result.ResultUnit = result.Code;
            if (addExtraValueMultiplication != null)
                _args.Result.ResultMultiplication = addExtraValueMultiplication();
        }

        private int _varNumber;
        private readonly OperatorHints.CreateOperatorCodeEventArgs _args;
        private readonly ClrTypesResolver _resolver;
        private readonly List<ValueOfSomeTypeExpression> _sink = new List<ValueOfSomeTypeExpression>();
        private ConversionMethodScanner _conversionMethodScanner;
    }

    public enum ValueOfSomeTypeExpressionRoot
    {
        Left,
        Right
    }
}