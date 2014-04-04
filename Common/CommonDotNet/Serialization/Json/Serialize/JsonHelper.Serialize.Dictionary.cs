using System.Collections;
using System.Collections.Generic;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeDictionary(IDictionary dictionary)
        {
            List<string> values = new List<string>();
            foreach (DictionaryEntry temp in dictionary)
            {
                values.Add("\"" + temp.Key.ToString() + "\":" + SerializeObject(temp.Value));
            }
            return "{" + string.Join(",", values) + "}";
        }
    }
}
