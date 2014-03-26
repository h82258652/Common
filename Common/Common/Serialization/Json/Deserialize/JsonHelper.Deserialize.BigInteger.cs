using System;
using System.Numerics;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static BigInteger DeserializeToBigInteger(string input, Type type)
        {
            BigInteger bigInteger;
            if (BigInteger.TryParse(input, out bigInteger) == false)
            {
                throw new JsonDeserializeException();
            }
            return bigInteger;
        }
    }
}
