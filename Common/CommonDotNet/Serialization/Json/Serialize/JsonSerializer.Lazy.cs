using System;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeLazy<T>(Lazy<T> lazy)
        {
            if (lazy.IsValueCreated == true)
            {
                return SerializeObject(lazy.Value);
            }
            else
            {
                return SerializeObject(null);
            }
        }
    }
}
