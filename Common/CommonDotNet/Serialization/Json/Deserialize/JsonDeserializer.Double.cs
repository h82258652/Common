using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private double DeserializeToDouble(string input, Type type)
        {
            double d;
            if (double.TryParse(input, out d) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return d;
        }
    }
}
