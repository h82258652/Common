using System.Collections;
using System.Text;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeList(IList list)
        {
            StringBuilder sb = new StringBuilder("[");
            for (int i = 0, count = list.Count; i < count; i++)
            {
                sb.Append(SerializeObject(list[i]));
                if (i != count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
