using System.Text;

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
            var gb2312 = Encoding.GetEncoding("gb2312");

            var r1 = Rand.Next(11, 14);
            var r2 = r1 == 13 ? Rand.Next(0, 7) : Rand.Next(0, 16);
            var r3 = Rand.Next(10, 16);
            var r4 = r3 == 10 ? Rand.Next(1, 16) : r3 == 15 ? Rand.Next(0, 15) : Rand.Next(0, 16);

            var sr1 = r1.ToString("X");
            var sr2 = r2.ToString("X");
            var sr3 = r3.ToString("X");
            var sr4 = r4.ToString("X");

            var b1 = Convert.ToByte(sr1 + sr2, 16);
            var b2 = Convert.ToByte(sr3 + sr4, 16);

            return gb2312.GetString(new[] { b1, b2 }, 0, 2)[0];
        }

        /// <summary>
        /// 返回指定个数的随机汉字。
        /// </summary>
        /// <param name="length">随机汉字的个数。</param>
        /// <returns>指定个数的随机汉字。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>length</c> 小于 0。</exception>
        public static string NextChinese(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", length, "length 不能小于零。");
            }
            if (length == 0)
            {
                return string.Empty;
            }
            var sb = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                sb.Append(NextChinese());
            }
            return sb.ToString();
        }
    }
}
