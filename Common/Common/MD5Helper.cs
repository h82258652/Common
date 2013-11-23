using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Security.Cryptography
{
    public static partial class MD5Helper
    {
        /// <summary>
        /// 获取字符串的 32 位 MD5 大写
        /// </summary>
        /// <param name="input">需计算 MD5 的字符串</param>
        /// <param name="prefix">需添加的文本前缀</param>
        /// <returns> 32 位 MD5 大写</returns>
        public static string Get(string input, string prefix = "")
        {
            using (MD5CryptoServiceProvider md5csp = new MD5CryptoServiceProvider())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(prefix + input);
                bytes = md5csp.ComputeHash(bytes);
                return BitConverter.ToString(bytes).Replace("-", string.Empty);
            }
        }
    }
}
