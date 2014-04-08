using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private float DeserializeToSingle(string input, Type type)
        {
            float f;
            if (float.TryParse(input, out f) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return f;
        }
    }
}
