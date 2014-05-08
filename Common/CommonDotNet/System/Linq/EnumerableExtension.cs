using System.Collections.Generic;

namespace System.Linq
{
    /// <summary>
    /// IEnumerable&lt;T&gt;扩展类。
    /// </summary>
    public static partial class EnumerableExtension
    {
        /// <summary>
        /// 通过使用元素的字段的值、属性的值或调用方法返回的值进行比较，返回序列中的非重复元素。
        /// </summary>
        /// <typeparam name="TSource"><c>source</c> 中的元素的类型。</typeparam>
        /// <typeparam name="TCompareElement">用于比较的值的类型。</typeparam>
        /// <param name="source">要从中移除重复元素的序列。</param>
        /// <param name="keySelector">获取比较的值的方法。</param>
        /// <returns>一个 System.Collections.Generic.IEnumerable&lt;TSource&gt;，包含源序列中的非重复元素。</returns>
        /// <exception cref="System.ArgumentNullException"><c>source</c> 为 null。</exception>
        public static IEnumerable<TSource> Distinct<TSource, TCompareElement>(this IEnumerable<TSource> source, Func<TSource, TCompareElement> keySelector)
        {
            return source.Distinct(new ElementEqualityComparer<TSource, TCompareElement>(keySelector));
        }

        /// <summary>
        /// 通过使用元素的字段的值、属性的值或调用方法返回的值进行比较，返回序列中的非重复元素。
        /// </summary>
        /// <typeparam name="TSource"><c>source</c> 中的元素的类型。</typeparam>
        /// <param name="source">要从中移除重复元素的序列。</param>
        /// <param name="keySelector">用于比较的字符串。</param>
        /// <param name="comparer">字符串比较的方式。</param>
        /// <returns>一个 System.Collections.Generic.IEnumerable&lt;TSource&gt;，包含源序列中的非重复元素。</returns>
        /// <exception cref="System.ArgumentNullException"><c>source</c> 为 null。</exception>
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
