using System;

namespace Common.Serialization.Json
{
    public partial class JsonHelper
    {
        /// <summary>
        /// 将指定的 JSON 字符串转换为 T 类型的对象。
        /// </summary>
        /// <param name="input">要进行反序列化的 JSON 字符串。</param>
        /// <param name="type">所生成对象的类型。</param>
        /// <returns>反序列化的对象。</returns>
        /// <exception cref="Common.Serialization.Json.JsonDeserializeException">JSON 格式错误时产生。</exception>
        public static object Deserialize(string input, Type type)
        {
            JsonDeserializer deserializer = new JsonDeserializer()
            {
                MaxStackLevel = JsonHelper.MaxStackLevel
            };

            return deserializer.DeserializeToObject(input, type);
        }

        /// <summary>
        /// 将指定的 JSON 字符串转换为 T 类型的对象。
        /// </summary>
        /// <typeparam name="T">所生成对象的类型。</typeparam>
        /// <param name="input">要进行反序列化的 JSON 字符串。</param>
        /// <returns>反序列化的对象。</returns>
        /// <exception cref="Common.Serialization.Json.JsonDeserializeException">JSON 格式错误时产生。</exception>
        public static T Deserialize<T>(string input)
        {
            return (T)Deserialize(input, typeof(T));
        }
    }
}
