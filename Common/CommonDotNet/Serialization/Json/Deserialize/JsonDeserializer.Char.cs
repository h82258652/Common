using System;
using System.Text;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private char DeserializeToChar(string input, Type type)
        {
            if (input.StartsWith("\"", StringComparison.Ordinal) == true && input.EndsWith("\"", StringComparison.Ordinal) == true)
            {
                string source = input;
                input = input.Substring(1, input.Length - 2);
                if (input == "\\\\")
                {
                    return '\\';
                }
                else if (input == "\\b")
                {
                    return '\b';
                }
                else if (input == "\\f")
                {
                    return '\f';
                }
                else if (input == "\\n")
                {
                    return '\n';
                }
                else if (input == "\\r")
                {
                    return '\r';
                }
                else if (input == "\\t")
                {
                    return '\t';
                }
                else if (input.StartsWith("\\u", StringComparison.Ordinal) == true)
                {
                    input = input.Substring(2);
                    if (input.Length == 4)
                    {
                        char c0 = input[0];
                        char c1 = input[1];
                        char c2 = input[2];
                        char c3 = input[3];
                        if (c0.IsHex() == true && c1.IsHex() == true && c2.IsHex() == true && c3.IsHex() == true)
                        {
                            byte b0 = Convert.ToByte(c2.ToString() + c3.ToString(), 16);
                            byte b1 = Convert.ToByte(c0.ToString() + c1.ToString(), 16);
                            return Encoding.Unicode.GetChars(new byte[2] { b0, b1 })[0];
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
                }
                else
                {
                    if (input.Length == 1)
                    {
                        return input[0];
                    }
                    else
                    {
                        throw new JsonDeserializeException(source, type);
                    }
                }
            }
            else
            {
                throw new JsonDeserializeException(input, type);
            }
        }
    }
}
