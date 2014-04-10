using System;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeNullable(object nullable)
        {
            return SerializeObject(nullable);
        }
    }
}
