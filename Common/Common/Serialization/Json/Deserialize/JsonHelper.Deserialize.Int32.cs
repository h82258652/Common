using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serialization
{
  public static partial  class JsonHelper
    {
      internal static int DeserializeToInt32(string input, Type type)
      {
          int i;
          if (int.TryParse(input,out i)==false)
          {
              throw new
          }
          return i;
      }
    }
}
