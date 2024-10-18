using System;
using System.Globalization;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace iSukces.UnitedValues;

public static class CommonParse
{
    public static ParseResult Parse(string value, Type resultType)
    {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException();
            var m = ParseRegex.Match(value);
            if (!m.Success)
                throw new ArgumentException($"Unable to convert \'{value}\' into {resultType}");
            var minus  = m.Groups[1].Value == "-";
            var number = decimal.Parse(m.Groups[2].Value, CultureInfo.InvariantCulture);
            if (minus)
                number = -number;
            var unit = m.Groups[6].Value.Trim();
            return new ParseResult(number, unit);
        }

    public const string RegexFilter = @"^\s*([-+]?)\s*((\d+)(\.(\d+))?)\s*(.*)\s*$";

    public static readonly Regex ParseRegex = new Regex(RegexFilter, RegexOptions.Compiled);

    public struct ParseResult
    {
        public ParseResult(decimal value, string unitName)
        {
                Value     = value;
                _unitName = unitName?.Trim();
            }

        public decimal Value { get; }

        [NotNull]
        public string UnitName => _unitName ?? "";

        private readonly string _unitName;
    }
}