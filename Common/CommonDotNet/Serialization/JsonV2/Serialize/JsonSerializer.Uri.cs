using System;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeUri(Uri uri)
        {
            return "\"" + uri.ToString() + "\"";
        }
    }
}
