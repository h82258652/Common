using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static bool DeserializeToBoolean(string input, Type type)
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
                        throw new JsonDeserializeException();
                    }
            }
        }
    }
}
