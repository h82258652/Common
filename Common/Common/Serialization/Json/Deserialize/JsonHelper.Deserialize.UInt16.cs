using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serialization.Json.Deserialize
{
   public static partial class JsonHelper
    {
       internal static ushort DeserializeToUInt16(string input,Type type)
       {
           ushort us;
           if (ushort.TryParse(input, out us) == false)
           {
               throw new JsonDeserializeException();
           }
           return us;
       }
    }
}
