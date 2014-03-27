using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static double DeserializeToDouble(string input, Type type)
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
