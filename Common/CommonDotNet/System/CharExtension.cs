
namespace System
{
    /// <summary>
    /// 字符扩展类。
    /// </summary>
    public static partial class CharExtension
    {
        /// <summary>
        /// 指示当前字符是否属于数字类别。（'0'-'9'及例如罗马字母'Ⅰ'等字符）
        /// </summary>
        /// <param name="c">测试的字符。</param>
        /// <returns>是否属于数字类别。</returns>
        public static bool IsNumber(this char c)
        {
            return char.IsNumber(c);
        }

        /// <summary>
        /// 指示当前字符是否属于十进制数字类别。（即字符'0'-'9'）
        /// </summary>
        /// <param name="c">测试的字符。</param>
        /// <returns>是否属于十进制数字类别。</returns>
        public static bool IsDigit(this char c)
        {
            return char.IsDigit(c);
        }

        /// <summary>
        /// 指示当前字符是否属于大写字母类别。
        /// </summary>
        /// <param name="c">测试的字符。</param>
        /// <returns>是否属于大写字母类别。</returns>
        public static bool IsUpper(this char c)
        {
            return char.IsUpper(c);
        }

        /// <summary>
        /// 指示当前字符是否属于小写字母类别。
        /// </summary>
        /// <param name="c">测试的字符。</param>
        /// <returns>是否属于小写字母类别。</returns>
        public static bool IsLower(this char c)
        {
            return char.IsLower(c);
        }

        /// <summary>
        /// 指示当前字符是否属于中文字符。
        /// </summary>
        /// <param name="c">测试的字符。</param>
        /// <returns>是否属于中文字符。</returns>
        public static bool IsChinese(this char c)
        {
            if (c >= 0x4e00 && c <= 0x9fa5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 指示当前字符是否属于十六进制字符类别。
        /// </summary>
        /// <param name="c">测试的字符。</param>
        /// <returns>是否属于十六进制字符类别。</returns>
        public static bool IsHex(this char c)
        {
            if (c >= '0' && c <= '9')
            {
                return true;
            }
            else if (c >= 'a' && c <= 'f')
            {
                return true;
            }
            else if (c >= 'A' && c <= 'F')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
