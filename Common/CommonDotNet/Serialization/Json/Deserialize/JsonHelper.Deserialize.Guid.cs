using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static Guid DeserializeToGuid(string input, Type type)
        {
            if (input.StartsWith("\"") == true && input.EndsWith("\"") == true)
            {
                input = input.Substring(1, input.Length - 2);
                return Guid.Parse(input);
            }
            else
            {
                throw new JsonDeserializeException(input, type);
            }
        }
    }
}
