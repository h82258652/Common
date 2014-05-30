using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// Int32 扩展类。
    /// </summary>
    public static partial class Int32Extension
    {
        /// <summary>
        /// 指示当前 32 位有符号整数是否为质数。
        /// </summary>
        /// <param name="num">32 位有符号整数。</param>
        /// <returns>是否为质数。</returns>
        public static bool IsPrime(this int num)
        {
            return Int64Extension.IsPrime(num);
        }

        /// <summary>
        /// 获取当前 32 位有符号整数的 16 进制形式。
        /// </summary>
        /// <param name="num">32 位有符号整数。</param>
        /// <returns>16 进制形式。</returns>
        public static string ToHex(this int num)
        {
            return num.ToString("X");
        }
    }
}
