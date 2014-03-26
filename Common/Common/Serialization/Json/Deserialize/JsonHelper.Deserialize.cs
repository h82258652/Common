using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        public static object Deserialize(string input, Type type)
        {
        }

        public static T Deserialize<T>(string input)
        {
            return (T)Deserialize(input, typeof(T));
        }
    }
}
