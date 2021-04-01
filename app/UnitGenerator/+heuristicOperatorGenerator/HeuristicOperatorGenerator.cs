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
                    return new ExpressionCodeSource(src.Path?.Path, src.Root == ValueOfSomeTypeExpressionRoot.Left);
                }

                return null;
            }

            var ccc = constr[0];

            var list    = new List<ValueOfSomeTypeExpression>();
        
            foreach (var i in ccc.GetParameters())
            {
                var type = i.ParameterType;
                sources = typesDict.GetTypeSources(type);
                ValueOfSomeTypeExpression el = sources[0];
                if (el.Root == ValueOfSomeTypeExpressionRoot.Right)
                {
                    // try to construct;
                    var constructed = Construct(new XUnitTypeName(type.Name));
                    if (constructed.DependsOnLeftArgument)
                    {
                        // hasLeft = true;
                       // el      = constructed.Code;
                    }
                }
           
                list.Add(el);
            }

            var hasLeft = list.Any(q => q.Root == ValueOfSomeTypeExpressionRoot.Left);
            if (!hasLeft)
            {
                sources = typesDict.GetTypeSources(type1);
                if (sources.Any())
                {
                    var src = sources[0];
                    return new ExpressionCodeSource(src.Path?.Path, src.Root == ValueOfSomeTypeExpressionRoot.Left);
                }

                throw new NotImplementedException();
            }

            var aaa = list.Select(a => a.Path.Path).ToArray();
            return new LazyConstructor(unit.GetTypename(), aaa, true);
        }

        private void Scan(ValueOfSomeTypeExpressionRoot root, XUnitTypeName x, Kind2 kind, ExpressionPath path = null)
        {
            if (!_resolver.TryGetValue(x.GetTypename(), out var type))
                throw new NotImplementedException();
            var info1 = new ValueOfSomeTypeExpression(root, type, path, kind);
            _sink.Add(info1);
            if (kind != Kind2.Property)
                return;
            foreach (var propInfo in type.GetProperties())
            {
                var bla = propInfo.GetCustomAttribute<RelatedUnitSourceAttribute>();
                if (bla != null && bla.Usage ==RelatedUnitSourceUsage.DoNotUse)
                    continue;
                var pt  = propInfo.PropertyType;
                if (!pt.Implements<IUnit>()) continue;
                Scan(root, new XUnitTypeName(propInfo.PropertyType.Name), kind, path + propInfo.Name);
            }
            foreach (var methodInfo in type.GetMethods(BindingFlags.Instance| BindingFlags.Public))
            {
                var bla = methodInfo.GetCustomAttribute<RelatedUnitSourceAttribute>();
                if (bla is null || (bla.Usage & RelatedUnitSourceUsage.ProvidesRelatedUnit) ==0)
                    continue;
                var returnType = methodInfo.ReturnType;
                if (!returnType.Implements<IUnit>())
                    throw new Exception("Should return IUnit");
                if (methodInfo.GetParameters().Length!=0)
                    throw new Exception("Should be parameterles");
                Scan(root, new XUnitTypeName(returnType.Name), Kind2.Method, path + $"{methodInfo.Name}()");
            }

        }

        private void TryCreateInternal()
        {
            var cc = _args.Input;
            var lu = cc.LeftMethodArgumentName + ".Unit";
            var ru = cc.RightMethodArgumentName + ".Unit";

            Scan(ValueOfSomeTypeExpressionRoot.Left, cc.Left.Unit, Kind2.Property, (ExpressionPath)lu);
            Scan(ValueOfSomeTypeExpressionRoot.Right, cc.Right.Unit, Kind2.Property, (ExpressionPath)ru);

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
                convertType.AddTo(reductor);

            var result = Construct(cc.Result.Unit);
            result.AddTo(reductor);

            var dict = reductor.GetReduced();
            convertType?.Reduce(dict);
            result.Reduce(dict);

            // =============================
            if (result.Code == "specificHeatCapacity.Unit.DenominatorUnit")
                Debug.WriteLine("");
            switch (convertType)
            {
                case null:
                    break;
                case LazyConstructor _:
                    _args.Result.ConvertRight(AddVariable(convertType.Code, "targetRightUnit"));
                    break;
                default:
                    _args.Result.ConvertRight(convertType.Code);
                    break;
            }

            if (result is LazyConstructor)
                _args.Result.ResultUnit = AddVariable(result.Code, "resultUnit");
            else
                _args.Result.ResultUnit = result.Code;
        }

        private int _varNumber;
        private readonly OperatorHints.CreateOperatorCodeEventArgs _args;
        private readonly ClrTypesResolver _resolver;
        private readonly List<ValueOfSomeTypeExpression> _sink = new List<ValueOfSomeTypeExpression>();
    }

    public enum ValueOfSomeTypeExpressionRoot
    {
        Left,
        Right
    }
}