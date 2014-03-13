using System;

namespace Common.Serialization
{
    /// <summary>
    /// 表示 JSON 格式有误。
    /// </summary>
    public sealed class JsonFormatException : Exception
    {
        public JsonFormatException()
        {
        }

        public JsonFormatException(string message)
            : base("JSON 格式错误：" + message)
        {
        }

        public JsonFormatException(string message, Exception innerException)
            : base("JSON 格式错误：" + message, innerException)
        {
        }
    }
}