using System.Collections;
using System.Collections.Generic;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeDictionary(IDictionary dictionary)
        {
            List<string> values = new List<string>();
            foreach (DictionaryEntry temp in dictionary)
            {
                values.Add(SerializeObject(temp.Key) + ":" + SerializeObject(temp.Value));
            }
            return "{" + string.Join(",", values) + "}";
        }
    }
}
