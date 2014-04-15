using System;

namespace Common.Serialization.Json
{
    /// <summary>
    /// 表示 JSON 反序列化失败。
    /// </summary>
    [Serializable]
    public sealed class JsonDeserializeException : Exception
    {
        /// <summary>
        /// 初始化 JsonDeserializeException 类的新实例。
        /// </summary>
        public JsonDeserializeException()
        {
        }

        /// <summary>
        /// 使用指定的错误信息初始化 JsonDeserializeException 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public JsonDeserializeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 使用反序列化失败的字符串及类型初始化 JsonDeserializeException 类的新实例。
        /// </summary>
        /// <param name="input">反序列化失败的字符串。</param>
        /// <param name="type">反序列化失败的类型。</param>
        public JsonDeserializeException(string input, Type type)
            : base("无法将 " + input + " 反序列化为 " + type.Name + " 的类型。")
        {
        }
    }
}
