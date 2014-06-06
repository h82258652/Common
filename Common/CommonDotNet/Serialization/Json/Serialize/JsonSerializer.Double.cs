
using System.Globalization;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeDouble(double d)
        {
            return d.ToString(CultureInfo.InvariantCulture);
        }
    }
}
