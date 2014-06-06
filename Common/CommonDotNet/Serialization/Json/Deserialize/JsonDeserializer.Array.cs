using System;
using System.Collections.Generic;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private Array DeserializeToArray(string input, Type type)
        {
            if (input.StartsWith("[", StringComparison.Ordinal) == true && input.EndsWith("]", StringComparison.Ordinal) == true)
            {
                input = input.Substring(1, input.Length - 2).Trim();
                // 获取元素类型。
                Type elementType = type.GetElementType();
                List<object> list = new List<object>();
                foreach (var temp in JsonHelper.ItemReader(input))
                {
                    list.Add(DeserializeToObject(temp, elementType));
                }
                return list.ToArray();
            }
            else
            {
                throw new JsonDeserializeException(input, type);
            }
        }
    }
}
