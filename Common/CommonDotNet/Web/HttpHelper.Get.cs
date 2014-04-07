using System;
using System.IO;
using System.Net;
using System.Web;

namespace Common.Web
{
    /// <summary>
    /// Http 帮助类。
    /// </summary>
    public static partial class HttpHelper
    {
        /// <summary>
        /// 发出一个同步 Get 请求。
        /// </summary>
        /// <param name="url">请求的 url。</param>
        /// <param name="param">Get 请求的参数。</param>
        /// <returns>请求结果。</returns>
        /// <exception cref="ArgumentException"><c>url</c> 为空字符串或 null。</exception>
        /// <exception cref="System.UriFormatException"><c>url</c> 格式错误。</exception>
        /// <exception cref="System.Net.WebException">连接失败。</exception>
        public static string Get(string url, object param = null)
        {
            if (string.IsNullOrWhiteSpace(url) == true)
            {
                throw new ArgumentException("url 不能为空。");
            }
            if (url.Contains("://") == false)
            {
                url = "http://" + url;
            }
            string queryString = ObjectToRequestData(param);
            queryString = HttpUtility.UrlEncode(queryString);
            if (queryString.Length > 0)
            {
                url = url + '?' + queryString;
            }
            WebRequest request = HttpWebRequest.Create(new Uri(url));
            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// 发出一个异步 GET 请求。
        /// </summary>
        /// <param name="url">请求的 url。</param>
        /// <param name="param">Get 请求的参数。</param>
        /// <param name="success">请求成功时执行的方法。</param>
        /// <param name="failure">请求失败时执行的方法。</param>
        public static void GetAsync(string url, object param = null, Action<string> success = null,
            Action<WebException> failure = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url) == true)
                {
                    throw new ArgumentException("url 不能为空。");
                }
                if (url.Contains("://") == false)
                {
                    url = "http://" + url;
                }
                string queryString = ObjectToRequestData(param);
                queryString = HttpUtility.UrlEncode(queryString);
                if (queryString.Length > 0)
                {
                    url = url + '?' + queryString;
                }
                WebRequest request = HttpWebRequest.Create(new Uri(url));
                request.Method = "GET";
                request.BeginGetResponse((IAsyncResult result) =>
                {
                    using (WebResponse response = request.EndGetResponse(result))
                    {
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {
                            if (success != null)
                            {
                                success(sr.ReadToEnd());
                            }
                        }
                    }
                }, request);
            }
            catch (WebException ex)
            {
                if (failure != null)
                {
                    failure(ex);
                }
            }
        }
    }
}
