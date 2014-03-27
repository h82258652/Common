using System;
using System.Collections;

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
                ArrayList array = new ArrayList();
                foreach (var temp in JsonHelper.ItemReader(input))
                {
                    array.Add(DeserializeToObject(temp, elementType));
                }
                return array.ToArray(elementType);
            }
            else
            {
                throw new JsonDeserializeException(input, type);
            }
        }
    }
}
