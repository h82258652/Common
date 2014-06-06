
using System.Globalization;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeInt32(int i)
        {
            return i.ToString(CultureInfo.InvariantCulture);
        }
    }
}
