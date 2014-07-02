
namespace System
{
    public partial class RandomExtension
    {
        /// <summary>
        /// 用随机数填充指定字节数组的元素。
        /// </summary>
        /// <param name="buffer">包含随机数的字节数组。</param>
        /// <exception cref="System.ArgumentNullException"><c>buffer</c> 为 null。</exception>
        public override void NextBytes(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer", "值不能为 null。");
            }
            base.NextBytes(buffer);
        }

        /// <summary>
        /// 用随机数填充指定字节数组的元素。
        /// </summary>
        /// <param name="buffer">包含随机数的字节数组。</param>
        public void NextBytesSafely(byte[] buffer)
        {
            if (buffer != null)
            {
                NextBytes(buffer);
            }
        }

        /// <summary>
        /// 获取指定长度的用随机数填充的字节数组。
        /// </summary>
        /// <param name="length">字节数组的长度。</param>
        /// <returns>用随机数填充的字节数组。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>length</c> 小于 0。</exception>
        public byte[] NextBytes(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", "返回随机数组的长度不能小于零。");
            }
            var buffer = new byte[length];
            NextBytes(buffer);
            return buffer;
        }
    }
}
