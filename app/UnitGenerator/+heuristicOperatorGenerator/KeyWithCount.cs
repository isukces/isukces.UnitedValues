using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace UnitGenerator
{
    [ImmutableObject(true)]
    public class KeyWithCount
    {
        public KeyWithCount(ExpressionPath key, int count)
        {
            Key   = key;
            Count = count;
        }

        public static KeyWithCount Make<T>(IGrouping<ExpressionPath, T> src)
        {
            return new KeyWithCount(src.Key, src.Count());
        }

        public static KeyWithCount[] MakeList<T>(IEnumerable<T> source, Func<T, ExpressionPath> map)
        {
            var q = source.Select(map)
                .Where(a => a!=null)
                .GroupBy(a => a)
                .ToArray();
            return q.Select(Make)
                .Where(a => a.Count > 1)
                //.OrderByDescending(a => a.Count)
                .ToArray();
        }

    

        public override string ToString()
        {
            return $"Key={Key}, Count={Count}";
        }

        public ExpressionPath Key { get; }

        public int Count { get; }
    }
}