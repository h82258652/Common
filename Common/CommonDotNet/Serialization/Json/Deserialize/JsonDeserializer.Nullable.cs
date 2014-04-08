using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private object DeserializeToNullable(string input, Type type)
        {
            if (input == "null")
            {
                return null;
            }
            else
            {
                return DeserializeToObject(input, Nullable.GetUnderlyingType(type));
            }
        }
    }
}
