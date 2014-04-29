using System;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeLazy<T>(Lazy<T> lazy)
        {
            if (lazy.IsValueCreated == true)
            {
                return "{\"IsValueCreated\":true,\"Value\":" + SerializeObject(lazy.Value) + "}";
            }
            else
            {
                return "{\"IsValueCreated\":false,\"Value\":" + SerializeObject(default(T)) + "}";
            }
        }
    }
}
