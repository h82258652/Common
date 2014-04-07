
namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeBoolean(bool b)
        {
            return b ? "true" : "false";
        }
    }
}
