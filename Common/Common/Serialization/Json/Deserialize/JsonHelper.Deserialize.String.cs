using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string DeserializeToString(string input, Type type)
        {
            if (input.StartsWith("\"") && input.EndsWith("\""))
            {
                input = input.Substring(1, input.Length - 2);
                StringBuilder sb = new StringBuilder();
                for (int i = 0, length = input.Length; i < length; i++)
                {
                    if (input[i] == '\\')
                    {
                        if (i + 1 == length)
                        {
                            // 转义符错误。
                            throw new JsonDeserializeException("JSON格式错误");
                        }
                        if (input[i + 1] == '\\')
                        {
                            sb.Append("\\");
                        }
                        else if (input[i + 1] == 'b')
                        {
                            sb.Append("\b");
                        }
                        else if (input[i + 1] == 'f')
                        {
                            sb.Append("\f");
                        }
                        else if (input[i + 1] == 'n')
                        {
                            sb.Append("\n");
                        }
                        else if (input[i + 1] == 'r')
                        {
                            sb.Append("\r");
                        }
                        else if (input[i + 1] == 't')
                        {
                            sb.Append("\t");
                        }
                        else if (input[i + 1] == 'u' && i + 5 < length)
                        {
                            char c0 = input[i + 2];
                            char c1 = input[i + 3];
                            char c2 = input[i + 4];
                            char c3 = input[i + 5];
                            if (IsHex(c0) && IsHex(c1) && IsHex(c2) && IsHex(c3))
                            {
                                byte b0 = Convert.ToByte(c2.ToString() + c3.ToString(), 16);
                                byte b1 = Convert.ToByte(c0.ToString() + c1.ToString(), 16);
                                sb.Append(Encoding.Unicode.GetChars(new byte[] { b0, b1 })[0]);
                                i += 4;
                            }
                            // \u 转义符错误。
                            else
                            {
                                throw new JsonFormatException(@"\u转义符错误。");
                            }
                        }
                        else
                        {
                            // 转义符错误。
                            throw new JsonFormatException("转义符错误。");
                        }
                        i++;
                    }
                    else
                    {
                        sb.Append(input[i]);
                    }
                }
                return sb.ToString();
            }
            else
            {
                // 缺少前后的双引号。
                throw new JsonDeserializeException("字符串缺失双引号。");
            }
        }
    }
}
