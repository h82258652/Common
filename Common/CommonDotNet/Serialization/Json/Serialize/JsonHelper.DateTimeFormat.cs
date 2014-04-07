
namespace Common.Serialization.Json
{
    /// <summary>
    /// JSON 序列化时 DateTime 类型的转换格式。
    /// </summary>
    public enum DateTimeFormat
    {
        /// <summary>
        /// 将 DateTime 序列化成 "yyyy-MM-ddTHH:mm:ss.FFFFFFFK" 格式（默认）。
        /// </summary>
        Default,
        /// <summary>
        /// 将 DateTime 序列化成 new Date(AllMillisecond) 格式。
        /// </summary>
        Create,
        /// <summary>
        /// 将 DateTime 序列化成 "\/Date(AllMillisecond)\/" 格式。
        /// </summary>
        Function
    }
}
