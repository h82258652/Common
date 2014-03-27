using System;
using System.Text;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string DeserializeToString(string input, Type type)
        {
            if (input.StartsWith("\"") && input.EndsWith("\""))
            {
                string source = input;
                input = input.Substring(1, input.Length - 2);
                StringBuilder sb = new StringBuilder();
                for (int i = 0, length = input.Length; i < length; i++)
                {
                    if (input[i] == '\\')
                    {
                        if (i + 1 == length)
                        {
                            throw new JsonDeserializeException(source, type);
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
                            if (c0.IsHex() == true && c1.IsHex() == true && c2.IsHex() == true && c3.IsHex() == true)
                            {
                                byte b0 = Convert.ToByte(c2.ToString() + c3.ToString(), 16);
                                byte b1 = Convert.ToByte(c0.ToString() + c1.ToString(), 16);
                                sb.Append(Encoding.Unicode.GetChars(new byte[2] { b0, b1 })[0]);
                                i += 4;
                            }
                            else
                            {
                                throw new JsonDeserializeException(source, type);
                            }
                        }
                        else
                        {
                            throw new JsonDeserializeException(source, type);
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
                throw new JsonDeserializeException(input, type);
            }
        }
    }
}
