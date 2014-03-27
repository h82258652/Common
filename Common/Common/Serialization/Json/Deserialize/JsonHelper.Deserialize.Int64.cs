using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static long DeserializeToInt64(string input, Type type)
        {
            long l;
            if (long.TryParse(input, out l) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return l;
        }
    }
}
