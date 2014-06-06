
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
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于数字类别。</returns>
        public static bool IsNumber(this char value)
        {
            return char.IsNumber(value);
        }

        /// <summary>
        /// 指示当前字符是否属于十进制数字类别。（即字符'0'-'9'）
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于十进制数字类别。</returns>
        public static bool IsDigit(this char value)
        {
            return char.IsDigit(value);
        }

        /// <summary>
        /// 指示当前字符是否属于大写字母类别。
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于大写字母类别。</returns>
        public static bool IsUpper(this char value)
        {
            return char.IsUpper(value);
        }

        /// <summary>
        /// 指示当前字符是否属于小写字母类别。
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于小写字母类别。</returns>
        public static bool IsLower(this char value)
        {
            return char.IsLower(value);
        }

        /// <summary>
        /// 指示当前字符是否属于中文字符。
        /// </summary>
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于中文字符。</returns>
        public static bool IsChinese(this char value)
        {
            if (value >= 0x4e00 && value <= 0x9fa5)
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
        /// <param name="value">测试的字符。</param>
        /// <returns>是否属于十六进制字符类别。</returns>
        public static bool IsHex(this char value)
        {
            if (value >= '0' && value <= '9')
            {
                return true;
            }
            else if (value >= 'a' && value <= 'f')
            {
                return true;
            }
            else if (value >= 'A' && value <= 'F')
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
