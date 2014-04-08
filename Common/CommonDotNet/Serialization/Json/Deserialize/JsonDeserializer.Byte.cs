using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private byte DeserializeToByte(string input, Type type)
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
