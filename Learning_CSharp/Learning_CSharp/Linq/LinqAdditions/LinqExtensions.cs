using System;
using System.Linq;
using System.Collections.Generic;

namespace Learning_CSharp.Linq.LinqAdditions
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> items, Func<T, T, bool> func)
        {
            return items.Distinct(new FuncEqualityComparer<T>(func));
        }
    }
}