
namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        /// <summary>
        /// 设置 DateTime 序列化的格式，默认"yyyy-MM-ddTHH:mm:ss.FFFFFFFK"。
        /// </summary>
        public static DateTimeFormat DateTimeFormat = DateTimeFormat.Default;

        /// <summary>
        /// 序列化时，缩进的空格数，默认为 0。
        /// </summary>
        public static int SerializeIndentationWhiteSpaceCount = 0;

        /// <summary>
        /// 序列化时，是否格式化 JSON，默认为否。
        /// </summary>
        public static bool SerializeWapp = false;
    }
}
