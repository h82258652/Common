using System;
using System.Collections;

namespace Common.Serialization.Json
{
    /// <summary>
    /// 表示 JSON 序列化时字符串或数组或集合的元素个数有误。
    /// </summary>
    public sealed class JsonCountException : Exception
    {
        /// <summary>
        /// 字符串或数组或集合的元素个数应该小于此值。
        /// </summary>
        public int LessThan
        {
            get;
            private set;
        }

        /// <summary>
        /// 字符串或数组或集合的元素个数应该大于此值。
        /// </summary>
        public int GreaterThan
        {
            get;
            private set;
        }

        /// <summary>
        /// 引发当前异常的字符串或数组或集合。
        /// </summary>
        public object SourceObject
        {
            get;
            private set;
        }

        /// <summary>
        /// 引发当前异常的字符串或数组或集合的元素个数。
        /// </summary>
        public int CurrentCount
        {
            get;
            private set;
        }

        private JsonCountException()
        {
            this.LessThan = -1;
            this.GreaterThan = -1;
        }

        internal static JsonCountException CreateLessThanException(object source, int lessThan)
        {
            return new JsonCountException()
            {
                SourceObject = source,
                CurrentCount = (source as ICollection).Count,
                LessThan = lessThan
            };
        }

        internal static JsonCountException CreateGreaterThanException(object source, int greaterThan
            )
        {
            return new JsonCountException()
            {
                SourceObject = source,
                CurrentCount = (source as ICollection).Count,
                GreaterThan = greaterThan
            };
        }

        /// <summary>
        /// 返回表示当前异常的字符串。
        /// </summary>
        /// <returns>描述该异常的字符串。</returns>
        public override string ToString()
        {
            if (this.LessThan > -1)
            {
                return "当前字符串或数组或集合的个数为：" + this.CurrentCount + "，但应小于 " + this.LessThan + "。";
            }
            if (this.GreaterThan > -1)
            {
                return "当前字符串或数组或集合的个数为：" + this.CurrentCount + "，但应大于 " + this.GreaterThan + "。";
            }
            return base.ToString();
        }
    }
}
