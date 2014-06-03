using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.Security
{
    internal static partial class HashHelper
    {
        public static string GetStringHash(string input, HashAlgorithm hashAlgorithm)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input", "input不能为空。");
            }
            using (hashAlgorithm)
            {
                byte[] bytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(bytes).Replace("-", string.Empty);
            }
        }
    }
}
