using System;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private decimal DeserializeToDecimal(string input, Type type)
        {
            decimal d;
            if (decimal.TryParse(input, out d) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return d;
        }
    }
}
