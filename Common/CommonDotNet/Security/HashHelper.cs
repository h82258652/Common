using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Security
{
    internal static partial class HashHelper
    {
        public static string GetStringHash(string input, HashAlgorithm hashAlgorithm)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input不能为空。");
            }
            using (hashAlgorithm)
            {
                byte[] bytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(bytes).Replace("-", string.Empty);
            }
        }
    }
}
