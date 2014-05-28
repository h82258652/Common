using System;
using System.Web;
using Common.Serialization.Json;

namespace Common.System.Web
{
    /// <summary>
    /// HttpResponse 扩展类。
    /// </summary>
    public static partial class HttpResponseExtension
    {
        /// <summary>
        /// 将对象 JSON 序列化，写入 HTTP 响应输出流。
        /// </summary>
        /// <param name="response">HTTP 响应输出流。</param>
        /// <param name="obj">写入的对象。</param>
        /// <exception cref="System.ArgumentNullException"><c>response</c> 为 null。</exception>
        public static void WriteJson(this HttpResponse response, object obj)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }
            response.ContentType = "text/json";
            response.Write(JsonHelper.SerializeToJson(obj));
        }
    }
}
