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

        public static bool Set(string name, string value)
        {
            return Set(name, value, DateTime.MaxValue);
        }

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
