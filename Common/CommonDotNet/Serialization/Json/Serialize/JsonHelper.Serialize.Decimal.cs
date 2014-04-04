
namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeDecimal(decimal d)
        {
            return d.ToString();
        }
    }
}
