using System;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeGuid(Guid guid)
        {
            return "\"" + guid.ToString() + "\"";
        }
    }
}
