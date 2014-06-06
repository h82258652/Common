using System;
using System.Collections;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private IDictionary DeserializeToDictionary(string input, Type type)
        {
            if (input.StartsWith("{", StringComparison.Ordinal) == true && input.EndsWith("}", StringComparison.Ordinal) == true)
            {
                string source = input;
                input = input.Substring(1, input.Length - 2);
                IDictionary dictionary = Activator.CreateInstance(type, true) as IDictionary;
                // 获取键类型。
                Type keyType = type.GetGenericArguments()[0];
                // 获取值类型。
                Type valueType = type.GetGenericArguments()[1];
                foreach (var temp in JsonHelper.ItemReader(input))
                {
                    string key;
                    string value;
                    JsonHelper.ItemSpliter(temp, out key, out value);
                    object oKey = DeserializeToObject(key, keyType);
                    if (dictionary.Contains(oKey) == false)
                    {
                        object oValue = DeserializeToObject(value, valueType);
                        dictionary.Add(oKey, oValue);
                    }
                    else
                    {
                        throw new JsonDeserializeException(source, type);
                    }
                }
                return dictionary;
            }
            else
            {
                throw new JsonDeserializeException(input, type);
            }
        }
    }
}
