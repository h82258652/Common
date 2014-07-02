
namespace System
{
    public static partial class RandomHelper
    {
        /// <summary>
        /// 返回枚举类型中随机一个枚举值。
        /// </summary>
        /// <typeparam name="T">可枚举类型。</typeparam>
        /// <returns>其中一个枚举值。</returns>
        /// <exception cref="System.InvalidOperationException"><c>T</c> 不是枚举类型。</exception>
        [CLSCompliant(false)]
        public static T NextEnum<T>() where T : struct,  IComparable, IFormattable, IConvertible
        {
            return Rand.NextEnum<T>();
        }

        /// <summary>
        /// 返回枚举类型中随机一个枚举值。
        /// </summary>
        /// <param name="type">可枚举类型。</param>
        /// <returns>其中一个枚举值。</returns>
        /// <exception cref="System.ArgumentNullException"><c>type</c> 为 null。</exception>
        /// <exception cref="System.InvalidOperationException"><c>type</c> 不是枚举类型。</exception>
        public static Enum NextEnum(Type type)
        {
            return Rand.NextEnum(type);
        }
    }
}
