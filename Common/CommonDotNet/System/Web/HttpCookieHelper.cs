using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace System.Web
{
    /// <summary>
    /// HttpCookie 帮助类。
    /// </summary>
    public static partial class HttpCookieHelper
    {
        /// <summary>
        /// 移除指定名称的 cookie。
        /// </summary>
        /// <param name="name">cookie 的名称。</param>
        /// <returns>是否成功移除 cookie。</returns>
        public static bool Remove(string name)
        {
            HttpContext context = HttpContext.Current;
            if (context == null)
            {
                return false;
            }
            HttpCookie cookie = context.Request.Cookies[name];
            if (cookie == null)
            {
                return false;
            }
            cookie.Expires = new DateTime(1970, 1, 1, 0, 0, 0);
            context.Response.SetCookie(cookie);
            return true;
        }

        /// <summary>
        /// 移除所有 cookie。
        /// </summary>
        /// <returns>是否成功移除所有 cookie。</returns>
        public static bool RemoveAll()
        {
            HttpContext context = HttpContext.Current;
            if (context == null)
            {
                return false;
            }
            HttpCookieCollection cookies = context.Request.Cookies;
            HttpResponse response = context.Response;
            foreach (HttpCookie cookie in cookies)
            {
                cookie.Expires = new DateTime(1970, 1, 1, 0, 0, 0);
                response.SetCookie(cookie);
            }
            return true;
        }

        /// <summary>
        /// 获取 cookie 的值。
        /// </summary>
        /// <param name="name">cookie 的名称。</param>
        /// <returns>cookie 的值。若获取失败，则返回 null。</returns>
        public static string Get(string name)
        {
            HttpContext context = HttpContext.Current;
            if (context == null)
            {
                return null;
            }
            HttpCookie cookie = context.Request.Cookies[name];
            if (cookie == null)
            {
                return null;
            }
            return cookie.Value;
        }

        /// <summary>
        /// 设置指定 cookie 的值。
        /// </summary>
        /// <param name="name">cookie 的名称。</param>
        /// <param name="value">cookie 的值。</param>
        /// <returns>是否成功设置 cookie 的值。</returns>
        public static bool Set(string name, string value)
        {
            return Set(name, value, DateTime.MaxValue);
        }

        /// <summary>
        /// 设置指定 cookie 的值。
        /// </summary>
        /// <param name="name">cookie 的名称。</param>
        /// <param name="value">cookie 的值。</param>
        /// <param name="expires">cookie 的到期时间。</param>
        /// <returns>是否成功设置 cookie 的值。</returns>
        public static bool Set(string name, string value, DateTime expires)
        {
            HttpContext context = HttpContext.Current;
            if (context == null)
            {
                return false;
            }
            HttpCookie cookie = new HttpCookie(name, value)
            {
                Expires = expires
            };
            context.Response.Cookies.Add(cookie);
            return true;
        }
    }
}
