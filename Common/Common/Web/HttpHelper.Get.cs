using System;
using System.IO;
using System.Net;
using System.Web;

namespace Common.Web
{
    public static partial class HttpHelper
    {
        /// <summary>
        /// 发出一个同步 Get 请求。
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static string Get(string url, object param = null)
        {
            if (string.IsNullOrWhiteSpace(url) == true)
            {
                throw new ArgumentException("url 不能为空。");
            }
            string queryString = ObjectToRequestData(param);
            if (queryString.Length > 0)
            {
                url = url + '?' + queryString;
            }
            url = HttpUtility.UrlEncode(url);
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

        public static void GetAsync(string url, object param = null, Action<string> success = null,
            Action<Exception> failure = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url) == true)
                {
                    throw new ArgumentException("url 不能为空。");
                }
                string queryString = ObjectToRequestData(param);
                if (queryString.Length > 0)
                {
                    url = url + '?' + queryString;
                }
                url = HttpUtility.UrlEncode(url);
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
            catch (Exception ex)
            {
                if (failure != null)
                {
                    failure(ex);
                }
            }
        }
    }
}
