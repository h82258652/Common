using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.SqlServer.Server;

namespace Test
{
    public static class EnumberableExtension
    {
        public static IEnumerable<TSource> Distinct<TSource, TCompareElement>(this IEnumerable<TSource> source, Func<TSource, TCompareElement> keySelector)
        {
            return source.Distinct(new ElementEqualityComparer<TSource, TCompareElement>(keySelector));
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Func<TSource, string> keySelector, StringComparer comparer)
        {
            return source.Distinct(new ElementEqualityComparer<TSource, string>(keySelector, comparer));
        }

        private class ElementEqualityComparer<TSource, TCompareElement> : IEqualityComparer<TSource>
        {
            private readonly Func<TSource, TCompareElement> _keySelector;
            private readonly IEqualityComparer<TCompareElement> _comparer;

            internal ElementEqualityComparer(Func<TSource, TCompareElement> keySelector)
                : this(keySelector, EqualityComparer<TCompareElement>.Default)
            {
            }

            internal ElementEqualityComparer(Func<TSource, TCompareElement> keySelector, IEqualityComparer<TCompareElement> comparer)
            {
                this._keySelector = keySelector;
                this._comparer = comparer;
            }
            
            public bool Equals(TSource x, TSource y)
            {
                return this._comparer.Equals(this._keySelector(x), this._keySelector(y));
            }

            public int GetHashCode(TSource obj)
            {
                return this._comparer.GetHashCode(this._keySelector(obj));
            }
        }
    }
}
