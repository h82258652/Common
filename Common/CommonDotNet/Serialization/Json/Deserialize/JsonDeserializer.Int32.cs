using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private int DeserializeToInt32(string input, Type type)
        {
            int i;
            if (int.TryParse(input, out i) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return i;
        }
    }
}
