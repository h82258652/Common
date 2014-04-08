
namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeDecimal(decimal d)
        {
            return d.ToString();
        }
    }
}
