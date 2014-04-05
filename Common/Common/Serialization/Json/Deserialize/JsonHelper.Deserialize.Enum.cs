using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static Enum DeserializeToEnum(string input, Type type)
        {
            if (input.StartsWith("\"") == true && input.EndsWith("\"") == true)
            {
                string source = input;
                input = input.Substring(1, input.Length - 2);
                Enum value;
                try
                {
                    value = (Enum)Enum.Parse(type, input, false);
                }
                catch (Exception)
                {
                    throw new JsonDeserializeException(source, type);
                }
                return value;
            }
            else
            {
                int i;
                if (int.TryParse(input, out i) == true)
                {
                    return (Enum)Enum.Parse(type, i.ToString(), false);
                }
                else
                {
                    throw new JsonDeserializeException(input, type);
                }
            }
        }
    }
}
