using System;
using System.Collections.Generic;

namespace Learning_CSharp.Linq.LinqAdditions
{
    public class FuncEqualityComparer<T> : IEqualityComparer<T>
    {
        public FuncEqualityComparer(Func<T, T, bool> func)
        {
            _func = func;
        }

        readonly Func<T, T, bool> _func;

        public bool Equals(T x, T y)
        {
            return _func(x, y);
        }

        public int GetHashCode(T obj)
        {
            return 0;
        }
    }
}