using System;
using System.Collections;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static IList DeserializeToList(string input, Type type)
        {
            if (input.StartsWith("[") == true && input.EndsWith("]") == true)
            {
                input = input.Substring(1, input.Length - 2).Trim();
                // 获取元素类型。
                Type elementType = type.GetGenericArguments()[0];
                IList list = Activator.CreateInstance(type) as IList;
                foreach (var temp in JsonHelper.ItemReader(input))
                {
                    list.Add(DeserializeToObject(temp, elementType));
                }
                return list;
            }
            else
            {
                throw new JsonDeserializeException(input, type);
            }
        }
    }
}
