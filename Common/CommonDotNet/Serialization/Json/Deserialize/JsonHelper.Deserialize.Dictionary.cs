using System;
using System.Collections;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static IDictionary DeserializeToDictionary(string input, Type type)
        {
            if (input.StartsWith("{") == true && input.EndsWith("}") == true)
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
                    int index = temp.IndexOf(':');
                    if (index == -1)
                    {
                        throw new JsonDeserializeException(source, type);
                    }
                    else
                    {
                        string key = temp.Substring(0, index).Trim();
                        object oKey = DeserializeToObject(key, keyType);
                        if (dictionary.Contains(oKey) == false)
                        {
                            string value = temp.Substring(index + 1).Trim();
                            object oValue = DeserializeToObject(value, valueType);
                            dictionary.Add(oKey, oValue);
                        }
                        else
                        {
                            throw new JsonDeserializeException(source, type);
                        }
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
