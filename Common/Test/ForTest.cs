using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Test
{

    public static class EnumberableExtension
    {
        public static IEnumerable<TSource> Distinct<TSource, TCompareElement>(this IEnumerable<TSource> source, Func<TSource, TCompareElement> comparer) where TCompareElement : struct
        {
            return source.Distinct(new ElementEqualityComparer<TSource, TCompareElement>(comparer));
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source,
            Func<TSource, string> comparer)
        {
            return source.Distinct(new ElementEqualityComparer<TSource, string>(comparer));
        }
        private class ElementEqualityComparer<T, TComparElement> : IEqualityComparer<T>
        {
            private readonly Func<T, TComparElement> _compareFunc;

            internal ElementEqualityComparer(Func<T, TComparElement> compareFunc)
            {
                this._compareFunc = compareFunc;
            }

            public bool Equals(T x, T y)
            {
                return object.Equals(_compareFunc(x), _compareFunc(y));
            }

            public int GetHashCode(T obj)
            {
                return _compareFunc(obj).GetHashCode();
            }
        }
    }

    
}
