using System.Numerics;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeBigInteger(BigInteger bigInteger)
        {
            return bigInteger.ToString();
        }
    }
}
