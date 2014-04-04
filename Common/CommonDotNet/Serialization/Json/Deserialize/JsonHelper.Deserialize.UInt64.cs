using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static ulong DeserializeToUInt64(string input, Type type)
        {
            ulong ul;
            if (ulong.TryParse(input, out ul) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return ul;
        }
    }
}
