using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Web.Script.Serialization
{
    public static partial class JsonHelper
    {
        private static readonly JavaScriptSerializer jss;

        static JsonHelper()
        {
            jss = new JavaScriptSerializer();
        }

        /// <summary>
        /// 将当前对象转换为 JSON 字符串。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>序列化的 JSON 字符串。</returns>
        public static string SerializeToJson<T>(this T obj)
        {
            return jss.Serialize(obj);
        }

        /// <summary>
        /// 将指定的 JSON 字符串转换为 T 类型的对象。
        /// </summary>
        /// <typeparam name="T">所生成对象的类型。</typeparam>
        /// <param name="input">要进行反序列化的 JSON 字符串。</param>
        /// <returns>反序列化的对象。</returns>
        public static T Deserialize<T>(string input)
        {
            return jss.Deserialize<T>(input);
        }
    }
}
