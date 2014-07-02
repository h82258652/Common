
namespace System
{
    public partial class RandomExtension
    {
        /// <summary>
        /// 返回枚举类型中随机一个枚举值。
        /// </summary>
        /// <typeparam name="T">可枚举类型。</typeparam>
        /// <returns>其中一个枚举值。</returns>
        /// <exception cref="System.InvalidOperationException"><c>T</c> 不是枚举类型。</exception>
        [CLSCompliant(false)]
        public T NextEnum<T>() where T : struct,  IComparable, IFormattable, IConvertible
        {
            var type = typeof(T);
            if (type.IsEnum == false)
            {
                throw new InvalidOperationException(type.Name + "不是可枚举类型。");
            }
            return (T)(object)NextEnum(type);
        }

        /// <summary>
        /// 返回枚举类型中随机一个枚举值。
        /// </summary>
        /// <param name="type">可枚举类型。</param>
        /// <returns>其中一个枚举值。</returns>
        /// <exception cref="System.ArgumentNullException"><c>type</c> 为 null。</exception>
        /// <exception cref="System.InvalidOperationException"><c>type</c> 不是枚举类型。</exception>
        public Enum NextEnum(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type", "随机的枚举类型不能为空。");
            }
            if (type.IsEnum == false)
            {
                throw new InvalidOperationException(type.Name + " 不是可枚举类型。");
            }
            var array = Enum.GetValues(type);
            var index = Next(array.GetLowerBound(0), array.GetUpperBound(0) + 1);
            return (Enum)array.GetValue(index);
        }
    }
}
