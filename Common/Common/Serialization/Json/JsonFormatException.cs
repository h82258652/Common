using System;

namespace Common.Serialization
{
    /// <summary>
    /// 表示 JSON 格式有误。
    /// </summary>
    [Serializable]
    public sealed class JsonFormatException : Exception
    {
        /// <summary>
        /// 初始化 JsonFormatException 类的新实例。
        /// </summary>
        public JsonFormatException()
        {
        }

        /// <summary>
        /// 使用指定的错误信息初始化 JsonFormatException 类的新实例。
        /// </summary>
        /// <param name="message">描述错误的消息。</param>
        public JsonFormatException(string message)
            : base("JSON 格式错误：" + message)
        {
        }

        /// <summary>
        /// 使用指定错误消息和对作为此异常原因的内部异常的引用来初始化 JsonFormatException 类的新实例。
        /// </summary>
        /// <param name="message">解释异常原因的错误信息。</param>
        /// <param name="innerException">导致当前异常的异常；如果未指定内部异常，则是一个 null 引用（在 Visual Basic 中为 Nothing）。</param>
        public JsonFormatException(string message, Exception innerException)
            : base("JSON 格式错误：" + message, innerException)
        {
        }
    }
}
