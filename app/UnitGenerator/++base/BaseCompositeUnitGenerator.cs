using System;
using System.Collections.Generic;
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

            var name = new Args(Cfg.UnitTypes.Unit).MakeGenericType("IEquatable");
            Target.ImplementedInterfaces.Add(name);

            var pi = new[]
            {
                new ConstructorParameterInfo(_info.FirstPropertyName, _info.First.Unit, null,
                    _info.FirstPropertyName.Decamelize().ToLower()),
                new ConstructorParameterInfo(_info.SecondPropertyName, _info.Second.Unit, null,
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
        }

        protected abstract IEnumerable<string> GetImplementedInterfaces();

        protected abstract CompositeUnitGeneratorInfo GetInfo();

        protected abstract Info2 GetInfo2();

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

        private void Add_WithSecond()
        {
            var cw = Ext.Create(GetType());
            var e  = new Args("newUnit", _info.SecondPropertyName).Create(Target.Name);
            cw.WriteLine($"return {e};");
            Target.AddMethod($"With{_info.FirstPropertyName}", Cfg.UnitTypes.Unit)
                .WithBody(cw)
                .AddParam("newUnit", _info.First.Unit);
        }

        private void Add_WithFirst()
        {
            var cw = Ext.Create(GetType());
            var e  = new Args(_info.FirstPropertyName, "newUnit").Create(Target.Name);
            cw.WriteLine($"return {e};");
            Target.AddMethod("With" + _info.SecondPropertyName, Cfg.UnitTypes.Unit)
                .WithBody(cw)
                .AddParam("newUnit", _info.Second.Unit);
        }

        private CompositeUnitGeneratorInfo _info;
        private Info2 _info2;

        protected const string PropertyName = nameof(IUnitNameContainer.UnitName);
    }

    public class Info2
    {
        public Info2(string stringSeparator)
        {
            StringSeparator = stringSeparator;
        }

        public string StringSeparator { get; }
    }
}