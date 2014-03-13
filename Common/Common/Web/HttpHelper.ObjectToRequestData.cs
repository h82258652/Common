using System;
using System.Collections.Generic;
using System.Reflection;

namespace Common.Web
{
    public static partial class HttpHelper
    {
        internal static string ObjectToRequestData(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            Type t = obj.GetType();
            List<string> list = new List<string>();
            foreach (FieldInfo field in t.GetFields())
            {
                list.Add(field.Name + '=' + field.GetValue(obj));
            }
            foreach (PropertyInfo property in t.GetProperties())
            {
                if (property.GetIndexParameters().Length == 0)
                {
                    list.Add(property.Name + '=' + property.GetValue(obj));
                }
            }
            return string.Join("&", list);
        }
    }
}
