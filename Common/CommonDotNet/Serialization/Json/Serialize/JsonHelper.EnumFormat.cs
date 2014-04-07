
namespace Common.Serialization.Json
{
    /// <summary>
    /// JSON 序列化时 Enum 类型的转换格式。
    /// </summary>
    public enum EnumFormat
    {
        /// <summary>
        /// 将 Enum 序列化成 value 格式（默认）。
        /// </summary>
        Default,
        /// <summary>
        /// 将 Enum 序列化成 "name" 格式。
        /// </summary>
        Name
    }
}
