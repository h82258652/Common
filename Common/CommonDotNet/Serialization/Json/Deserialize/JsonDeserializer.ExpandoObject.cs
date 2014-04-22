using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private ExpandoObject DeserializeToExpandoObject(string input, Type type)
        {
            if (input.StartsWith("{") == true && input.EndsWith("}") == true)
            {
                string source = input;
                input = input.Substring(1, input.Length - 2);
                ExpandoObject expandoObject = new ExpandoObject();
                IDictionary<string, object> dictionary = expandoObject;
                foreach (var temp in JsonHelper.ItemReader(input))
                {
                    int index = temp.IndexOf(':');
                    if (index == -1)
                    {
                        throw new JsonDeserializeException(source, type);
                    }
                    else
                    {
                        string key = temp.Substring(0, index).Trim();
                        string value = temp.Substring(index + 1).Trim();
                        dictionary.Add((string)DeserializeToObject(key, typeof(string)), value);
                    }
                }
                return expandoObject;
            }
            else
            {
                throw new JsonDeserializeException(input, type);
            }
        }
    }
}
