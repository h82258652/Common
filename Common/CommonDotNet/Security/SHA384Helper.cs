using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Common.Security
{
    /// <summary>
    /// SHA384 帮助类。
    /// </summary>
    public static partial class SHA384Helper
    {
        /// <summary>
        /// 获取文件的 40 位 SHA384 大写。
        /// </summary>
        /// <param name="filePath">需计算 SHA384 的文件。</param>
        /// <returns>40 位 SHA384 大写。</returns>
        /// <exception cref="FileNotFoundException"><c>filePath</c> 不存在。</exception>
        public static string GetFileSHA384(string filePath)
        {
            if (File.Exists(filePath) == false)
            {
                throw new FileNotFoundException("文件不存在！", filePath);
            }
            using (SHA384CryptoServiceProvider sha384Csp = new SHA384CryptoServiceProvider())
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] bytes = sha384Csp.ComputeHash(fs);
                    StringBuilder sb = new StringBuilder(40);
                    foreach (var temp in bytes)
                    {
                        sb.AppendFormat("{0:X2}", temp);
                    }
                    return sb.ToString();
                }
            }
        }

        /// <summary>
        /// 获取字符串的 40 位 SHA384 大写。
        /// </summary>
        /// <param name="input">需计算 SHA384 的字符串。</param>
        /// <param name="prefix">需添加的字符串前缀。</param>
        /// <returns>40 位 SHA384 大写。</returns>
        /// <exception cref="ArgumentNullException"><c>input</c> 为 null。</exception>
        public static string GetStringSHA386(string input, string prefix = "")
        {
            if (input == null)
            {
                throw new ArgumentNullException("input", "input 不能为空。");
            }
            using (SHA384CryptoServiceProvider sha384Csp = new SHA384CryptoServiceProvider())
            {
                byte[] bytes = sha384Csp.ComputeHash(Encoding.UTF8.GetBytes(prefix + input));
                StringBuilder sb = new StringBuilder(40);
                foreach (var temp in bytes)
                {
                    sb.AppendFormat("{0:X2}", temp);
                }
                return sb.ToString();
            }
        }
    }
}
