
namespace Common.Reflection
{
    public static partial class ReflectionHelper
    {
        /// <summary>
        /// 定义反射帮助类的方法中搜索的方式。
        /// </summary>
        public enum SearchOption
        {
            /// <summary>
            /// 大小写完全匹配。
            /// </summary>
            Default,
            /// <summary>
            /// 忽略大小写。
            /// </summary>
            IgnoreCase
        }
    }
}