using System.Globalization;
using System.Text;

namespace System
{
    public partial class RandomExtension
    {
        /// <summary>
        /// 返回一个随机汉字。
        /// </summary>
        /// <returns>一个随机汉字。</returns>
        public char NextChinese()
        {
            var gb2312 = Encoding.GetEncoding("gb2312");

            var r1 = Next(11, 14);
            var r2 = r1 == 13 ? Next(0, 7) : Next(0, 16);
            var r3 = Next(10, 16);
            var r4 = r3 == 10 ? Next(1, 16) : r3 == 15 ? Next(0, 15) : Next(0, 16);

            var sr1 = r1.ToString("X", CultureInfo.InvariantCulture);
            var sr2 = r2.ToString("X", CultureInfo.InvariantCulture);
            var sr3 = r3.ToString("X", CultureInfo.InvariantCulture);
            var sr4 = r4.ToString("X", CultureInfo.InvariantCulture);

            var b1 = Convert.ToByte(sr1 + sr2, 16);
            var b2 = Convert.ToByte(sr3 + sr4, 16);

            return gb2312.GetString(new[] { b1, b2 }, 0, 2)[0];
        }

        /// <summary>
        /// 返回指定个数的随机汉字。
        /// </summary>
        /// <param name="count">随机汉字的个数。</param>
        /// <returns>指定个数的随机汉字。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>length</c> 小于 0。</exception>
        public string NextChinese(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "count 不能小于零。");
            }
            if (count == 0)
            {
                return string.Empty;
            }
            var sb = new StringBuilder(count);
            for (var i = 0; i < count; i++)
            {
                sb.Append(NextChinese());
            }
            return sb.ToString();
        }
    }
}
