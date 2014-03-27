using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static int DeserializeToInt32(string input, Type type)
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
