using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private long DeserializeToInt64(string input, Type type)
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
