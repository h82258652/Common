using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static sbyte DeserializeToSByte(string input, Type type)
        {
            sbyte sb;
            if (sbyte.TryParse(input, out sb) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return sb;
        }
    }
}
