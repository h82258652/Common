
namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeNullable(object nullable)
        {
            return SerializeObject(nullable);
        }
    }
}
