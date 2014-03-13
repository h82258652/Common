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
        /// <exception cref="System.ArgumentNullException"></exception>
        public static string GetStringMD5(string input, string prefix = "")
        {
            if (input == null)
            {
                throw new ArgumentNullException("input不能为空。");
            }
            using (MD5CryptoServiceProvider md5Csp = new MD5CryptoServiceProvider())
            {
                byte[] bytes = md5Csp.ComputeHash(Encoding.UTF8.GetBytes(prefix + input));
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
            using (MD5CryptoServiceProvider md5Csp = new MD5CryptoServiceProvider())
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    byte[] bytes = md5Csp.ComputeHash(fs);
                    return BitConverter.ToString(bytes).Replace("-", string.Empty);
                }
            }
        }
    }
}
