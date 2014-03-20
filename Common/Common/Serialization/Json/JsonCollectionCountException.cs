using System;
using System.Collections;

namespace Common.Serialization
{
    /// <summary>
    /// 表示 JSON 序列化时数组或集合的元素个数有误。
    /// </summary>
    public sealed class JsonCollectionCountException : Exception
    {
        /// <summary>
        /// 数组或集合的元素个数应该小于此值。
        /// </summary>
        public int LessThan
        {
            get;
            set;
        }

        /// <summary>
        /// 数组或集合的元素个数应该大于此值。
        /// </summary>
        public int GreaterThan
        {
            get;
            set;
        }

        /// <summary>
        /// 引发当前异常的数组或集合
        /// </summary>
        public object CurrentCollection
        {
            get;
            set;
        }

        /// <summary>
        /// 引发当前异常的数组或集合的元素个数。
        /// </summary>
        public int CurrentCount
        {
            get;
            set;
        }

        internal static JsonCollectionCountException CreateLessThanException(object collection, int lessThan)
        {
            return new JsonCollectionCountException()
            {
                CurrentCollection = collection,
                CurrentCount = (collection as ICollection).Count,
                LessThan = lessThan
            };
        }

        internal static JsonCollectionCountException CreateGreaterThanException(object collection, int greaterThan
)
        {
            return new JsonCollectionCountException()
            {
                CurrentCollection = collection,
                CurrentCount = (collection as ICollection).Count,
                GreaterThan = greaterThan
            };
        }

        private JsonCollectionCountException()
        {
            LessThan = -1;
            GreaterThan = -1;
        }

        /// <summary>
        /// 返回表示当前异常的字符串。
        /// </summary>
        /// <returns>描述该异常的字符串。</returns>
        public override string ToString()
        {
            if (LessThan > -1)
            {
                return "当前数组或集合的个数为：" + CurrentCount + "，但应小于 " + LessThan + "。";
            }
            if (GreaterThan > -1)
            {
                return "当前数组或集合的个数为：" + CurrentCount + "，但应大于 " + GreaterThan + "。";
            }
            return base.ToString();
        }
    }
}
