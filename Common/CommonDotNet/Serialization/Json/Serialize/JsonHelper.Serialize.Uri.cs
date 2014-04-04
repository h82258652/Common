using System;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeUri(Uri uri)
        {
            return "\"" + uri.OriginalString + "\"";
        }
    }
}
