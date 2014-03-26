using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeEnum(Enum e)
        {
            return Convert.ToInt32(e).ToString();
        }
    }
}
