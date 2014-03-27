using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static decimal DeserializeToDecimal(string input, Type type)
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
