using System;
using System.Collections;
using System.Collections.Generic;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static Array DeserializeToArray(string input, Type type)
        {
            if (input.StartsWith("[") == true && input.EndsWith("]") == true)
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
