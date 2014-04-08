
namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeBoolean(bool b)
        {
            return b ? "true" : "false";
        }
    }
}
