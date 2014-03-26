using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static decimal DeserializeToDecimal(string input, Type type)
        {
            decimal d;
            if (decimal.TryParse(input, out d) == false)
            {
                throw new JsonDeserializeException();
            }
            return d;
        }
    }
}
