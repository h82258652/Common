using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static object DeserializeToObject(string input, Type type)
        {
            input = input.Trim();
            #region null
            if (input=="null")
            {
                return null;
            }
            #endregion
            #region bool
            if (type==typeof( bool))
            {
                return DeserializeToBoolean(input, type);
            }
            #endregion
            #region byte
            if (type==typeof(byte))
            {
                return DeserializeToByte(input, type);
            }
            #endregion
            #region
            #endregion
        }
    }
}
