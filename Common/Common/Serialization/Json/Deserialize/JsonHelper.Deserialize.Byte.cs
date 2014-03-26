using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static byte DeserializeToByte(string input, Type type)
        {
            byte b;
            if (byte.TryParse(input,out b)==false)
            {
                throw new
            }
            return b;
        }
    }
}
