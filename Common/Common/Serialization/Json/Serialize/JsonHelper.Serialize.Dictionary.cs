using System.Collections;
using System.Linq;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeDictionary(IDictionary dictionary)
        {
            var query = from DictionaryEntry temp in dictionary
                        select "\"" + temp.Key.ToString() + "\":" + SerializeObject(temp.Value);
            return "{" + string.Join(",", query) + "}";
        }
    }
}
