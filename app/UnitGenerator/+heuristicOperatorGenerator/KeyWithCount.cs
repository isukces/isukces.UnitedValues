using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace UnitGenerator
{
    [ImmutableObject(true)]
    public class KeyWithCount
    {
        public KeyWithCount(string key, int count)
        {
            Key   = key;
            Count = count;
        }

        public static KeyWithCount Make<T>(IGrouping<string, T> src)
        {
            return new KeyWithCount(src.Key, src.Count());
        }

        public static KeyWithCount[] MakeList<T>(IEnumerable<T> source, Func<T, string> map)
        {
            var q = source.Select(map)
                .Where(a => !string.IsNullOrWhiteSpace(a))
                .GroupBy(a => a)
                .ToArray();
            return q.Select(Make)
                .Where(a => a.Count > 1)
                //.OrderByDescending(a => a.Count)
                .ToArray();
        }

        public static KeyWithCount[] MakeList<T>(IEnumerable<IGrouping<string, T>> source)
        {
            return source.Select(Make)
                .OrderByDescending(a => a.Count)
                .ToArray();
        }

        public override string ToString()
        {
            return $"Key={Key}, Count={Count}";
        }

        public string Key { get; }

        public int Count { get; }
    }
}