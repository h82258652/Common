using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private short DeserializeToInt16(string input, Type type)
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
