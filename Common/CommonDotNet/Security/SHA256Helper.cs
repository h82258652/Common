using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.Security
{
    /// <summary>
    /// SHA256 帮助类。
    /// </summary>
    public static partial class SHA256Helper
    {
        /// <summary>
        /// 获取文件的 40 位 SHA256 大写。
        /// </summary>
        /// <param name="filePath">需计算 SHA256 的文件。</param>
        /// <returns> 40 位 SHA256 大写。</returns>
        /// <exception cref="FileNotFoundException"><c>filePath</c> 不存在。</exception>
        public static string GetFileSHA256(string filePath)
        {
            if (File.Exists(filePath) == false)
            {
                throw new FileNotFoundException("文件不存在！", filePath);
            }
            using (SHA256CryptoServiceProvider sha256Csp = new SHA256CryptoServiceProvider())
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] bytes = sha256Csp.ComputeHash(fs);
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
        /// 获取字符串的 40 位 SHA256 大写。
        /// </summary>
        /// <param name="input">需计算 SHA256 的字符串。</param>
        /// <param name="prefix">需添加的字符串前缀。</param>
        /// <returns> 40 位 SHA256 大写。</returns>
        /// <exception cref="ArgumentNullException"><c>input</c> 为 null。</exception>
        public static string GetStringSHA256(string input, string prefix = "")
        {
            if (input == null)
            {
                throw new ArgumentNullException("input", "input 不能为空。");
            }
            using (SHA256CryptoServiceProvider sha256Csp = new SHA256CryptoServiceProvider())
            {
                byte[] bytes = sha256Csp.ComputeHash(Encoding.UTF8.GetBytes(prefix + input));
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
