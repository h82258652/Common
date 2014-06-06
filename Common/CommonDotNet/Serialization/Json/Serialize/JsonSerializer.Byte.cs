
using System.Globalization;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeByte(byte b)
        {
            return b.ToString(CultureInfo.InvariantCulture);
        }
    }
}
