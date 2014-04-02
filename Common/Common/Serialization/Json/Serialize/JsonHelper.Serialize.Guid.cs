using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeGuid(Guid guid)
        {
            return "\"" + guid.ToString() + "\"";
        }
    }
}
