using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private Uri DeserializeToUri(string input, Type type)
        {
            if (input.StartsWith("\"") == true && input.EndsWith("\"") == true)
            {
                string source = input;
                input = input.Substring(1, input.Length - 2);
                Uri value;
                try
                {
                    value = new Uri(input);
                }
                catch
                {
                    throw new JsonDeserializeException(source, type);
                }
                return value;
            }
            else
            {
                throw new JsonDeserializeException(input, type);
            }
        }
    }
}
