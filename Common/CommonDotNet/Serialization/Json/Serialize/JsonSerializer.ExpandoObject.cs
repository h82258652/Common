using System.Collections.Generic;
using System.Dynamic;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeExpandoObject(ExpandoObject expandoObject)
        {
            List<string> values = new List<string>();
            foreach (KeyValuePair<string, object> keyValuePair in expandoObject)
            {
                values.Add(SerializeObject(keyValuePair.Key) + ":" + SerializeObject(keyValuePair.Value));
            }
            return "{" + string.Join(",", values) + "}";
        }
    }
}
