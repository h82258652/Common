
namespace Common.Serialization.Json
{
    /// <summary>
    /// JSON 序列化时 Regex 类型的转换格式。
    /// </summary>
    public enum RegexFormat
    {
        /// <summary>
        /// 将 Regex 序列化成 /pattern/attributes 格式（默认）。
        /// </summary>
        Default,
        /// <summary>
        /// 将 Regex 序列化成 new RegExp(pattern,attributes) 格式。
        /// </summary>
        Create
    }
}
