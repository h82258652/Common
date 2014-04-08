using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private ushort DeserializeToUInt16(string input, Type type)
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
