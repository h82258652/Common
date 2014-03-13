﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Common.Web
{
    public static partial class HttpHelper
    {
        /// <summary>
        /// 发出一个同步 Post 请求。
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static string Post(string url, object param = null)
        {
            if (string.IsNullOrWhiteSpace(url) == true)
            {
                throw new ArgumentException("url 不能为空。");
            }
            url = HttpUtility.UrlEncode(url);
            WebRequest request = HttpWebRequest.Create(new Uri(url));
            request.Method = "POST";
            request.ContentType = @"application/x-www-form-urlencoded";
            byte[] bytes = Encoding.UTF8.GetBytes(ObjectToRequestData(param));
            request.ContentLength = bytes.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// 发出一个异步 POST 请求。
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <param name="success"></param>
        /// <param name="failure"></param>
        public static void PostAsync(string url, object param = null, Action<string> success = null, Action<WebException> failure = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url) == true)
                {
                    throw new ArgumentException("url 不能为空。");
                }
                url = HttpUtility.UrlEncode(url);
                WebRequest request = HttpWebRequest.Create(new Uri(url));
                request.Method = "POST";
                request.ContentType = @"application/x-www-form-urlencoded";
                byte[] bytes = Encoding.UTF8.GetBytes(ObjectToRequestData(param));
                request.ContentLength = bytes.Length;
                request.BeginGetRequestStream((IAsyncResult result) =>
                {
                    using (Stream stream = request.EndGetRequestStream(result))
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }
                    request.BeginGetResponse((IAsyncResult result2) =>
                    {
                        using (WebResponse response = request.EndGetResponse(result2))
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
