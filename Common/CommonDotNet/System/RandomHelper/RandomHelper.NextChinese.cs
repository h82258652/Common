
namespace System
{
    public static partial class RandomHelper
    {
        /// <summary>
        /// 返回一个随机汉字。
        /// </summary>
        /// <returns>一个随机汉字。</returns>
        public static char NextChinese()
        {
            return Rand.NextChinese();
        }
        
        /// <summary>
        /// 返回指定个数的随机汉字。
        /// </summary>
        /// <param name="count">随机汉字的个数。</param>
        /// <returns>指定个数的随机汉字。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>length</c> 小于 0。</exception>
        public static string NextChinese(int count)
        {
            return Rand.NextChinese(count);
        }
    }
}
