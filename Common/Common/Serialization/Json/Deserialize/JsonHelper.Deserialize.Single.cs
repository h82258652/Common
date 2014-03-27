using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static float DeserializeToSingle(string input, Type type)
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
