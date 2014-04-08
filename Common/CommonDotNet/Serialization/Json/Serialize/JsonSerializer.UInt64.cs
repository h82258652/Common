
namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeUInt64(ulong ul)
        {
            return ul.ToString();
        }
    }
}
