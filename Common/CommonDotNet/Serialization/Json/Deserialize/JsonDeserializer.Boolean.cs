using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private bool DeserializeToBoolean(string input, Type type)
        {
            switch (input)
            {
                case "true":
                    {
                        return true;
                    }
                case "false":
                    {
                        return false;
                    }
                default:
                    {
                        throw new JsonDeserializeException(input, type);
                    }
            }
        }
    }
}
