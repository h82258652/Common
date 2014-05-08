using System.Collections.Generic;

namespace System.Linq
{
    /// <summary>
    /// IEnumerable&lt;T&gt;扩展类。
    /// </summary>
    public static class EnumerableExtension
    {
        /// <summary>
        /// 通过使用元素的字段的值、属性的值或调用方法返回的值进行比较，返回序列中的非重复元素。
        /// </summary>
        /// <typeparam name="TSource"><c>source</c> 中的元素的类型。</typeparam>
        /// <typeparam name="TCompareElement">用于比较的值的类型。必须为值类型。</typeparam>
        /// <param name="source">要从中移除重复元素的序列。</param>
        /// <param name="comparer">用于比较的值。</param>
        /// <returns>一个 System.Collections.Generic.IEnumerable&lt;TSource&gt;，包含源序列中的非重复元素。</returns>
        /// <exception cref="System.ArgumentNullException"><c>source</c> 为 null。</exception>
        public static IEnumerable<TSource> Distinct<TSource, TCompareElement>(this IEnumerable<TSource> source, Func<TSource, TCompareElement> comparer) where TCompareElement : struct
        {
            return source.Distinct(new ElementEqualityComparer<TSource, TCompareElement>(comparer));
        }

        /// <summary>
        /// 通过使用元素的字段的值、属性的值或调用方法返回的值进行比较，返回序列中的非重复元素。
        /// </summary>
        /// <typeparam name="TSource"><c>source</c> 中的元素的类型。</typeparam>
        /// <param name="source">要从中移除重复元素的序列。</param>
        /// <param name="comparer">用于比较的字符串。</param>
        /// <returns>一个 System.Collections.Generic.IEnumerable&lt;TSource&gt;，包含源序列中的非重复元素。</returns>
        /// <exception cref="System.ArgumentNullException"><c>source</c> 为 null。</exception>
        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, Func<TSource, string> comparer)
        {
            return source.Distinct(new ElementEqualityComparer<TSource, string>(comparer));
        }

        private class ElementEqualityComparer<TSource, TCompareElement> : IEqualityComparer<TSource>
        {
            private readonly Func<TSource, TCompareElement> _compareFunc;

            internal ElementEqualityComparer(Func<TSource, TCompareElement> compareFunc)
            {
                this._compareFunc = compareFunc;
            }

            public bool Equals(TSource x, TSource y)
            {
                return object.Equals(_compareFunc(x), _compareFunc(y));
            }

            public int GetHashCode(TSource obj)
            {
                return _compareFunc(obj).GetHashCode();
            }
        }
    }
}
