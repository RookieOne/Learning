using System;
using System.Collections.Generic;

namespace Learning_CSharp.YieldTests
{
    public static class LinqYieldExamples
    {
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> items, Predicate<T> predicate)
        {
            foreach (T i in items)
                if (predicate(i))
                    yield return i;
        }
    }
}