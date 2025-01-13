using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace UnitGenerator;

public class ExpressionPath : IEquatable<ExpressionPath>, IReducable
{
    public ExpressionPath(params ICodeSource1[] parts)
    {
        Parts = parts;
        if (Code.Split('.').Length != Parts.Length)
            Debug.Write("");
    }

    public static ExpressionPath? From(ICodeSource1? x)
    {
        if (x is null)
            return null;
        return new ExpressionPath(x);
    }

    public static ExpressionPath FromSingleElement(string x)
    {
        if (x.Contains('.'))
            throw new NotImplementedException();
        var src = new SimpleCodeSource(x);
        return new ExpressionPath(src);
    }

    public static ExpressionPath? FromSplit(string x)
    {
        x = x?.Trim();
        if (string.IsNullOrEmpty(x))
            return null;
        var tmp = x.Split('.')
            .Select(a => a.Trim())
            .Select(a => (ICodeSource1)new SimpleCodeSource(a))
            .ToArray();
        return new ExpressionPath(tmp);
    }


    public static ExpressionPath operator +(ExpressionPath left, string? right)
    {
        if (string.IsNullOrWhiteSpace(right))
            return left;
        return left + new SimpleCodeSource(right);
    }

    public static ExpressionPath operator +(ExpressionPath? left, ICodeSource1 right)
    {
        if (left is null)
            return From(right);

        if (right is null)
            return left;
        var l = new List<ICodeSource1>(left.Parts.Length + 1);
        l.AddRange(left.Parts);
        l.Add(right);
        return new ExpressionPath(l.ToArray());
    }

    public static bool operator ==(ExpressionPath? left, ExpressionPath? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ExpressionPath? left, ExpressionPath? right)
    {
        return !Equals(left, right);
    }

    public bool Equals(ExpressionPath? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (Parts.Length != other.Parts.Length)
            return false;
        for (var index = 0; index < Parts.Length; index++)
            if (Parts[index].Code != other.Parts[index].Code)
                return false;
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ExpressionPath)obj);
    }

    public IEnumerable<ExpressionPath> GetUsedExpressions()
    {
        var c = Parts.ToArray();
        return new[] {new ExpressionPath(c)};
    }

    public ExpressionPath? GetByDotsCounts(int dotsCount)
    {
        var partsExpected = dotsCount + 1;
        if (Parts.Length < partsExpected)
            return null;
        if (Parts.Length == partsExpected)
            return this;
        return new ExpressionPath(Parts.Take(partsExpected).ToArray());
    }

    public override int GetHashCode()
    {
        if (Parts.Length == 0)
            return 0;
        return Parts.Length * 777 + Parts[0].Code.GetHashCode();
    }

    public ExpressionPath Reduce(ExpressionPath expression, string varName)
    {
        if (expression.Dots == Dots)
            return FromSingleElement(varName);
        if (Dots < expression.Dots)
            return this;

        var l = new List<ICodeSource1>();
        l.Add(new SimpleCodeSource(varName));
        l.AddRange(Parts.Skip(expression.Parts.Length));
        return new ExpressionPath(l.ToArray());
    }

    public override string ToString()
    {
        return Code;
    }

    public void UpdateFromReduction(ExpressionPath expression, string varName)
    {
        if (expression.Dots == Dots)
        {
            if (Equals(expression))
                Parts = new ICodeSource1[] {new SimpleCodeSource(varName)};
            return;
        }

        if (Dots < expression.Dots)
            return;

        var begin = new ExpressionPath(Parts.Take(expression.Parts.Length).ToArray());
        if (begin.Equals(expression))
        {
            var l = new List<ICodeSource1>();
            l.Add(new SimpleCodeSource(varName));
            l.AddRange(Parts.Skip(expression.Parts.Length));
            Parts = l.ToArray();
        }
    }


    public ICodeSource1[] Parts { get; set; }

    public string Code => string.Join(".", Parts.Select(a => a.Code));
    public int    Dots => Parts.Length - 1;

    public bool LooksLikeMethodCall
    {
        get
        {
            return Parts.Any(a => a.Code.EndsWith(")"));
        }
    }
}
