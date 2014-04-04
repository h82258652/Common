using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static byte DeserializeToByte(string input, Type type)
        {
            byte b;
            if (byte.TryParse(input, out b) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return b;
        }
    }
}
