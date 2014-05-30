using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// Math 扩展类。
    /// </summary>
    public static partial class MathExtension
    {
        /// <summary>
        /// 求两个 32 位有符号整数的最大公约数。
        /// </summary>
        /// <param name="a">一个 32 位有符号整数。</param>
        /// <param name="b">另一个 32 位有符号整数。</param>
        /// <returns>两个 32 位有符号整数的最大公约数。</returns>
        public static int GCD(int a, int b)
        {
            // 记录两原数为2的多少倍。原理：Gcd(ka,kb)==k*Gcd(a,b)。
            int k = 0;
            for (; ; )
            {
                #region 退出条件
                if (a == 0)
                {
                    // 等价于b*2^k。
                    return b << k;
                }
                else if (b == 0)
                {
                    // 等价于a*2^k。
                    return a << k;
                }
                #endregion

                // 等价于a%2==0。
                if ((a & 1) == 0)
                {
                    // 等价于a/=2，即a=a/2。
                    a >>= 1;
                    // 等价于b%2==0；a，b都为偶数，否则a为偶数，b为奇数。
                    if ((b & 1) == 0)
                    {
                        // 等价于b/=2，即b=b/2。
                        b >>= 1;
                        k++;
                    }
                }
                else
                {
                    // 等价于b%2==0；a为奇数，b为偶数。
                    if ((b & 1) == 0)
                    {
                        // 等价于b/=2，即b=b/2。
                        b >>= 1;
                    }
                    // a，b都为奇数。
                    else
                    {
                        #region 使b变成更小的一个，即b=Math.Min(a,b)
                        if (b > a)
                        {
                            // 等价于a=a+b。
                            a += b;
                            b = a - b;
                            // 等价于a=a-b。
                            a -= b;
                        }
                        #endregion
                        // 等价于a=a-b。
                        a -= b;
                    }
                }
            }
        }
    }
}
