using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static short DeserializeToInt16(string input, Type type)
        {
            short s;
            if (short.TryParse(input, out s) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return s;
        }
    }
}
