using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private uint DeserializeToUInt32(string input, Type type)
        {
            uint ui;
            if (uint.TryParse(input, out ui) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return ui;
        }
    }
}
