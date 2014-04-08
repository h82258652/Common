using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private sbyte DeserializeToSByte(string input, Type type)
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
