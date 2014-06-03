using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.Security
{
    /// <summary>
    /// SHA1 帮助类。
    /// </summary>
    public static partial class SHA1Helper
    {
        /// <summary>
        /// 获取文件的 40 位 SHA1 大写。
        /// </summary>
        /// <param name="filePath">需计算 SHA1 的文件。</param>
        /// <returns> 40 位 SHA1 大写。</returns>
        /// <exception cref="FileNotFoundException"><c>filePath</c> 不存在。</exception>
        public static string GetFileSHA1(string filePath)
        {
            if (File.Exists(filePath) == false)
            {
                throw new FileNotFoundException("文件不存在！", filePath);
            }
            using (SHA1CryptoServiceProvider sha1Csp = new SHA1CryptoServiceProvider())
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] bytes = sha1Csp.ComputeHash(fs);
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
        /// 获取字符串的 40 位 SHA1 大写。
        /// </summary>
        /// <param name="input">需计算 SHA1 的字符串。</param>
        /// <param name="prefix">需添加的字符串前缀。</param>
        /// <returns> 40 位 SHA1 大写。</returns>
        /// <exception cref="ArgumentNullException"><c>input</c> 为 null。</exception>
        public static string GetStringSHA1(string input, string prefix = "")
        {
            if (input == null)
            {
                throw new ArgumentNullException("input", "input 不能为空。");
            }
            using (SHA1CryptoServiceProvider sha1Csp = new SHA1CryptoServiceProvider())
            {
                byte[] bytes = sha1Csp.ComputeHash(Encoding.UTF8.GetBytes(prefix + input));
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
