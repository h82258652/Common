using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static ushort DeserializeToUInt16(string input, Type type)
        {
            ushort us;
            if (ushort.TryParse(input, out us) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return us;
        }
    }
}
