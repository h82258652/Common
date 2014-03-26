using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        /// <summary>
        /// 将当前对象转换为 JSON 字符串。
        /// </summary>
        /// <param name="obj">需要进行 JSON 序列化的对象。</param>
        /// <returns>序列化的 JSON 字符串。</returns>
        public static string SerializeToJson(this object obj)
        {
            string json;

            // 序列化。
            json = SerializeObject(obj);

            // 格式化。
            json = FormatJson(json);

            return json;
        }
    }
}
