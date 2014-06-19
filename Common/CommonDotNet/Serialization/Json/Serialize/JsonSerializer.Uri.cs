using System;
using System.Web;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeUri(Uri uri)
        {
            return "\"" + uri.GetComponents(UriComponents.SerializationInfoString, UriFormat.UriEscaped) + "\"";
        }
    }
}
