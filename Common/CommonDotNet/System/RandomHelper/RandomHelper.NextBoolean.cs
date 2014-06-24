
namespace System
{
    public static partial class RandomHelper
    {
        /// <summary>
        /// 返回随机真假。
        /// </summary>
        /// <returns>真或假。</returns>
        public static bool NextBoolean()
        {
            return Rand.Next(2) == 0;
        }
    }
}
