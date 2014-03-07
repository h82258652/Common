using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Common.Security
{
    public static partial class MD5Helper
    {
        /// <summary>
        /// 获取字符串的 32 位 MD5 大写
        /// </summary>
        /// <param name="input">需计算 MD5 的字符串</param>
        /// <param name="prefix">需添加的字符串前缀</param>
        /// <returns> 32 位 MD5 大写</returns>
        public static string GetStringMD5(string input, string prefix = "")
        {
            using (MD5CryptoServiceProvider md5csp = new MD5CryptoServiceProvider())
            {
                byte[] bytes = md5csp.ComputeHash(Encoding.UTF8.GetBytes(prefix + input));
                return BitConverter.ToString(bytes).Replace("-", string.Empty);
            }
        }

        /// <summary>
        /// 获取文件的 32 位 MD5 大写
        /// </summary>
        /// <param name="filePath">需计算 MD5 的文件</param>
        /// <returns> 32 位 MD5 大写</returns>
        public static string GetFileMD5(string filePath)
        {
            using (MD5CryptoServiceProvider md5csp = new MD5CryptoServiceProvider())
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] bytes = md5csp.ComputeHash(fs);
                    return BitConverter.ToString(bytes).Replace("-", string.Empty);
                }
            }
        }
    }
}