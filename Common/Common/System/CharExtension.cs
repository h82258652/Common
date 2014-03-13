using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 字符扩展类。
    /// </summary>
    public static partial class CharExtension
    {
        /// <summary>
        /// 指示当前字符是否属于数字类别。（'0'-'9'及罗马字母例如'Ⅰ'等字符）
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsNumber(this char c)
        {
            return char.IsNumber(c);
        }

        /// <summary>
        /// 指示当前字符是否属于十进制数字类别。（即字符'0'-'9'）
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsDigit(this char c)
        {
            return char.IsDigit(c);
        }

        /// <summary>
        /// 指示当前字符是否属于大写字母类别。
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsUpper(this char c)
        {
            return char.IsUpper(c);
        }

        /// <summary>
        /// 指示当前字符是否属于小写字母类别。
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsLower(this char c)
        {
            return char.IsLower(c);
        }
    }
}
