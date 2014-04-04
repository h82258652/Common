using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static object DeserializeToNullable(string input, Type type)
        {
            if (input == "null")
            {
                return null;
            }
            else
            {
                return DeserializeToObject(input, Nullable.GetUnderlyingType(type));
            }
        }
    }
}
