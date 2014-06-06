
namespace Common.Serialization.Json
{
    public static partial class JsonHelper
    {
        /// <summary>
        /// ����ǰ����ת��Ϊ JSON �ַ�����
        /// </summary>
        /// <param name="value">��Ҫ���� JSON ���л��Ķ���</param>
        /// <returns>���л��� JSON �ַ�����</returns>
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

            // ���л���
            json = serializer.SerializeObject(value);

            // ��ʽ����
            json = FormatJson(json);

            return json;
        }
    }
}
