using System;
using System.Text;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeArray(Array array)
        {
            StringBuilder sb = new StringBuilder("[");
            for (int i = 0, length = array.Length; i < length; i++)
            {
                sb.Append(SerializeObject(array.GetValue(i)));
                if (i != length - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
