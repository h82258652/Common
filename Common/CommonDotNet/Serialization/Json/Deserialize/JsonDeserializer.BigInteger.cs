using System;
using System.Numerics;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private BigInteger DeserializeToBigInteger(string input, Type type)
        {
            BigInteger bigInteger;
            if (BigInteger.TryParse(input, out bigInteger) == false)
            {
                throw new JsonDeserializeException(input, type);
            }
            return bigInteger;
        }
    }
}
