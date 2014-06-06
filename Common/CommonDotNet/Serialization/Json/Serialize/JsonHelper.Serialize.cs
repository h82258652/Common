
namespace Common.Serialization.Json
{
    public static partial class JsonHelper
    {
        /// <summary>
        /// 将当前对象转换为 JSON 字符串。
        /// </summary>
        /// <param name="value">需要进行 JSON 序列化的对象。</param>
        /// <returns>序列化的 JSON 字符串。</returns>
        public static string SerializeToJson(this object value)
        {
            JsonSerializer serializer = new JsonSerializer()
            {
                DateTimeFormat = JsonHelper.DateTimeFormat,
                EnumFormat = JsonHelper.EnumFormat,
                RegexFormat = JsonHelper.RegexFormat,
                MaxStackLevel = JsonHelper.MaxStackLevel
            };

            string json;

            // 序列化。
            json = serializer.SerializeObject(value);

            // 格式化。
            json = FormatJson(json);

            return json;
        }
    }
}
