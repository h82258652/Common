using System.Numerics;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeBigInteger(BigInteger bigInteger)
        {
            return bigInteger.ToString();
        }
    }
}
