using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private ulong DeserializeToUInt64(string input, Type type)
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
