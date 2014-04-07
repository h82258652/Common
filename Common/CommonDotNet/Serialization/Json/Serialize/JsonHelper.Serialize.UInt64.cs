
namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeUInt64(ulong ul)
        {
            return ul.ToString();
        }
    }
}
