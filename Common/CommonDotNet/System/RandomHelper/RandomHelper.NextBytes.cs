
namespace System
{
    public static partial class RandomHelper
    {
        /// <summary>
        /// 用随机数填充指定字节数组的元素。
        /// </summary>
        /// <param name="buffer">包含随机数的字节数组。</param>
        /// <exception cref="System.ArgumentNullException"><c>buffer</c> 为 null。</exception>
        public static void NextBytes(byte[] buffer)
        {
            Rand.NextBytes(buffer);
        }

        /// <summary>
        /// 获取指定长度的用随机数填充的字节数组。
        /// </summary>
        /// <param name="length">字节数组的长度。</param>
        /// <returns>用随机数填充的字节数组。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>length</c> 小于 0。</exception>
        public static byte[] NextBytes(int length)
        {
            return Rand.NextBytes(length);
        }
    }
}
