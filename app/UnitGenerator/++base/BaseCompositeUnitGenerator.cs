using System.Collections.Generic;
using System.Linq;
using iSukces.Code;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;

// using Self= UnitGenerator.BaseCompositeUnitGenerator<T>;

namespace UnitGenerator
{
    public abstract class BaseCompositeUnitGenerator<T> : BaseGenerator<T>
        where T : IUnitInfo
    {
        protected BaseCompositeUnitGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }

        protected override void GenerateOne()
        {
            _info       = GetInfo();
            _info2      = GetInfo2();
            Target.Kind = CsNamespaceMemberKind.Class;

            foreach (var i in GetImplementedInterfaces())
                Target.ImplementedInterfaces.Add(i);

            var name = new Args(Cfg.UnitTypes.Unit.TypeName).MakeGenericType("IEquatable");
            Target.ImplementedInterfaces.Add(name);

            var pi = new[]
            {
                new ConstructorParameterInfo(_info.FirstPropertyName, _info.First.Unit.TypeName, null,
                    _info.FirstPropertyName.Decamelize().ToLower()),
                new ConstructorParameterInfo(_info.SecondPropertyName, _info.Second.Unit.TypeName, null,
                    _info.SecondPropertyName.Decamelize().ToLower())
            };
            Add_Constructor(pi);
            Add_Properties(pi);
            Add_UnitNameProperty();
            Add_Equals();
            Add_GetHashCode(
                $"({_info.FirstPropertyName}.GetHashCode() * 397) ^ {_info.SecondPropertyName}.GetHashCode()");
            AddCommon_EqualityOperators();
            Add_ToString(PropertyName);

            Add_WithFirst();
            Add_WithSecond();

            Add_Decompose();
        }

        protected abstract IEnumerable<string> GetImplementedInterfaces();

        protected abstract CompositeUnitGeneratorInfo GetInfo();

        protected abstract Info2 GetInfo2();

        private void Add_Decompose()
        {
            var items = _info2?.Items;
            if (items is null || items.Length == 0)
                return;
            var type = new Args(Target.GetTypeName<DecomposableUnitItem>())
                .MakeGenericType(Target.GetTypeName<IReadOnlyList<int>>(), true);

            var cs = Ext.Create(GetType());
            {
                // creates code
                var codeItems = new DecomposeExpressionFinder(typeof(Length).Assembly).GetCodeItems(items, Target.Name);
                if (codeItems != null)
                {
                    var initCodes = codeItems.Select(a => a.Init).Where(a => !string.IsNullOrWhiteSpace(a));
                    foreach (var i in initCodes) 
                        cs.WriteLine(i);
                    cs.WriteLine(new Args(codeItems.Select(a=>a.Expression).ToArray()).ReturnArray().Code);
                    cs.WriteLine("/*");
                }

                cs.WriteLine("var decomposer = new UnitDecomposer();");
                foreach (var item in items)
                    cs.WriteLine("decomposer.Add({0}, {1});", item.Propertyname, item.Power.CsEncode());
                cs.WriteReturn("decomposer.Items");
                
                if (codeItems != null)
                    cs.WriteLine("*/");
                var m = Target.AddMethod(nameof(IDecomposableUnit.Decompose), type);
                m.WithBody(cs);
            }

            Target.ImplementedInterfaces.Add(nameof(IDecomposableUnit));
        }


        private void Add_Equals()
        {
            var compareCode =
                $"{_info.FirstPropertyName}.Equals(other.{_info.FirstPropertyName}) && {_info.SecondPropertyName}.Equals(other.{_info.SecondPropertyName})";
            Add_EqualsUniversal(Target.Name, false, OverridingType.None, compareCode);
            Add_EqualsUniversal("object", false, OverridingType.Override,
                "other is " + Target.Name + " unitedValue ? Equals(unitedValue) : false");
        }

        private void Add_UnitNameProperty()
        {
            var sep = string.IsNullOrEmpty(_info2.StringSeparator)
                ? ""
                : " + " + _info2.StringSeparator.CsEncode();
            Target.AddProperty(PropertyName, "string")
                .WithIsPropertyReadOnly()
                .WithNoEmitField()
                .WithOwnGetter($@"{_info.FirstPropertyName}.UnitName{sep} + {_info.SecondPropertyName}.UnitName")
                .OwnGetterIsExpression = true;
        }

        private void Add_WithFirst()
        {
            var cw = Ext.Create(GetType());
            var e  = new Args(_info.FirstPropertyName, "newUnit").Create(Target.Name);
            cw.WriteLine($"return {e};");
            Target.AddMethod("With" + _info.SecondPropertyName, Cfg.UnitTypes.Unit.TypeName)
                .WithBody(cw)
                .AddParam("newUnit", _info.Second.Unit.TypeName);
        }

        private void Add_WithSecond()
        {
            var cw = Ext.Create(GetType());
            var e  = new Args("newUnit", _info.SecondPropertyName).Create(Target.Name);
            cw.WriteLine($"return {e};");
            Target.AddMethod($"With{_info.FirstPropertyName}", Cfg.UnitTypes.Unit.TypeName)
                .WithBody(cw)
                .AddParam("newUnit", _info.First.Unit.TypeName);
        }

        private CompositeUnitGeneratorInfo _info;
        private Info2 _info2;

        protected const string PropertyName = nameof(IUnitNameContainer.UnitName);
    }

    public class Info2
    {
        public Info2(string stringSeparator, NameAndPower[] items)
        {
            StringSeparator = stringSeparator;
            Items           = items;
        }

        public string         StringSeparator { get; }
        public NameAndPower[] Items           { get; }
    }
}