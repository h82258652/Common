using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Common.Security
{
    /// <summary>
    /// RSA 帮助类。
    /// </summary>
    public static partial class RSAHelper
    {
        /// <summary>
        /// 使用 RSA 算法对字符串进行解密。
        /// </summary>
        /// <param name="value">需解密的字符串。</param>
        /// <param name="key">密钥。</param>
        /// <returns>解密后的字符串。</returns>
        public static string DecryptRSA(this string value, string key)
        {
            CspParameters cspp = new CspParameters()
            {
                KeyContainerName = key
            };
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp)
            {
                PersistKeyInCsp = true
            };
            string[] decryptArray = value.Split('-');
            byte[] decryptByteArray = Array.ConvertAll(decryptArray,
                (s => Convert.ToByte(byte.Parse(s, NumberStyles.HexNumber))));
            byte[] bytes = rsa.Decrypt(decryptByteArray, true);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// 使用 RSA 算法对字符串进行加密。
        /// </summary>
        /// <param name="value">需加密的字符串。</param>
        /// <param name="key">密钥。</param>
        /// <returns>加密后的字符串。</returns>
        public static string EncryptRSA(this string value, string key)
        {
            CspParameters cspp = new CspParameters()
            {
                KeyContainerName = key
            };
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp)
            {
                PersistKeyInCsp = true
            };
            byte[] bytes = rsa.Encrypt(Encoding.UTF8.GetBytes(value), true);
            return BitConverter.ToString(bytes);
        }
    }
}
