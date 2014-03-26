using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serialization
{
   public static partial class JsonHelper
    {
       internal static double DeserializeToDouble(string input, Type type)
       {
           double d;
           if (double .TryParse(input,out d)==false)
           {
               throw new
           }
           return d;
       }
    }
}
