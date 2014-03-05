using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace Common.Serialization
{
    /// <summary>
    /// 为启用 AFAX 的应用程序提供序列化和反序列化功能。
    /// </summary>
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

            // 序列化
            json = SerializeObject(obj);

            // 格式化
            json = FormatJson(json);

            return json;
        }

        internal static string SerializeObject(object obj)
        {
            #region null
            if (obj == null)
            {
                return "null";
            }
            #endregion
            #region bool
            if (obj is bool)
            {
                return (bool)obj ? "true" : "false";
            }
            #endregion
            #region char or string
            if (obj is char || obj is string)
            {
                string s = obj.ToString();
                StringBuilder sb = new StringBuilder();
                for (int i = 0, length = s.Length; i < length; i++)
                {
                    if (s[i] == '\\')
                    {
                        sb.Append("\\\\");
                    }
                    else if (s[i] == '\0')
                    {
                        sb.Append("\\0");
                    }
                    else if (s[i] == '\a')
                    {
                        sb.Append("\\a");
                    }
                    else if (s[i] == '\b')
                    {
                        sb.Append("\\b");
                    }
                    else if (s[i] == '\f')
                    {
                        sb.Append("\\f");
                    }
                    else if (s[i] == '\n')
                    {
                        sb.Append("\\n");
                    }
                    else if (s[i] == '\r')
                    {
                        sb.Append("\\r");
                    }
                    else if (s[i] == '\t')
                    {
                        sb.Append("\\t");
                    }
                    else if (s[i] == '\v')
                    {
                        sb.Append("\\v");
                    }
                    else
                    {
                        sb.Append(s[i]);
                    }
                }
                return "\"" + sb.ToString() + "\"";
            }
            #endregion
            #region number
            else if (obj is byte || obj is sbyte || obj is short || obj is int || obj is long || obj is float || obj is double || obj is ushort || obj is uint || obj is ulong || obj is decimal || obj is BigInteger)
            {
                return obj.ToString();
            }
            #endregion
            #region DateTime
            else if (obj is DateTime)
            {
                DateTime datetime = (DateTime)obj;
                if (JsonHelper.DateTimeFormat == DateTimeFormat.Default)
                {
                    return "\"" + datetime.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFFK") + "\"";
                }
                else if (JsonHelper.DateTimeFormat == DateTimeFormat.Create)
                {
                    return "new Date(" + (long)((datetime.ToUniversalTime().Ticks - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks) / 0x2710) + ")";
                }
                else if (JsonHelper.DateTimeFormat == DateTimeFormat.Function)
                {
                    return "\"\\/Date(" + (long)((datetime.ToUniversalTime().Ticks - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks) / 0x2710) + ")\\/\"";
                }
                else
                {
                    throw new Exception("DateTime序列化格式未指定");
                }
            }
            #endregion DateTime
            #region Array
            else if (obj is Array)
            {
                Array arr = obj as Array;
                StringBuilder sb = new StringBuilder();
                sb.Append('[');
                for (int i = 0, length = arr.Length; i < length; i++)
                {
                    sb.Append(SerializeObject(arr.GetValue(i)));
                    if (i != length - 1)
                    {
                        sb.Append(',');
                    }
                }
                sb.Append(']');
                return sb.ToString();
            }
            #endregion
            #region List
            else if (obj is IList)
            {
                IList list = obj as IList;
                StringBuilder sb = new StringBuilder();
                sb.Append("[");
                for (int i = 0, count = list.Count; i < count; i++)
                {
                    sb.Append(SerializeObject(list[i]));
                    if (i != count - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append("]");
                return sb.ToString();
            }
            #endregion
            #region Dictionary
            else if (obj is IDictionary)
            {
                IDictionary dic = obj as IDictionary;
                List<string> values = new List<string>();
                var keys = dic.Keys;
                foreach (var key in keys)
                {
                    values.Add("\"" + key + "\":" + SerializeObject(dic[key]));
                }
                return "{" + string.Join(",", values) + "}";
            }
            #endregion
            #region Class
            else
            {
                Type t = obj.GetType();
                List<string> values = new List<string>();
                #region 序列化字段
                FieldInfo[] fields;
                if (typeFields.TryGetValue(t, out fields) == false)
                {
                    fields = t.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
                    typeFields.Add(t, fields);
                }
                foreach (FieldInfo field in fields)
                {
                    JsonAttribute attribute = field.GetCustomAttribute<JsonAttribute>(true);
                    string name;
                    object value;
                    string valueString;
                    if (attribute != null)
                    {
                        // 非公有字段且不序列化
                        if (attribute.ProcessNonPublic == false && field.IsPublic == false)
                        {
                            continue;
                        }
                        // 不序列化此字段
                        if (attribute.Ignore == true)
                        {
                            continue;
                        }
                        value = field.GetValue(obj);
                        // 不序列化 null 字段
                        if (value == null && attribute.IgnoreNull == true)
                        {
                            continue;
                        }
                        // 使用自定义映射名字
                        if (attribute.Name != null)
                        {
                            name = "\"" + attribute.Name + "\"";
                        }
                        else
                        {
                            name = "\"" + field.Name + "\"";
                        }
                        // 使用自定义序列化
                        if (attribute.Converter != null)
                        {
                            JsonConverter converter = (JsonConverter)Activator.CreateInstance(attribute.Converter);
                            bool skip;
                            valueString = converter.Serialize(value, field.FieldType, out skip);
                            if (skip == true)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            valueString = SerializeObject(value);
                        }
                    }
                    else
                    {
                        if (field.IsPublic == false)
                        {
                            continue;
                        }
                        name = "\"" + field.Name + "\"";
                        value = field.GetValue(obj);
                        valueString = SerializeObject(value);
                    }
                    values.Add(name + ":" + valueString);
                }
                #endregion
                #region 序列化属性
                PropertyInfo[] properties;
                if (typeProperties.TryGetValue(t, out properties) == false)
                {
                    properties = t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    typeProperties.Add(t, properties);
                }
                foreach (PropertyInfo property in properties)
                {
                    if (property.GetIndexParameters().Length == 0)// 非索引器属性
                    {
                        JsonAttribute attribute = property.GetCustomAttribute<JsonAttribute>(true);
                        string name;
                        object value;
                        string valueString;
                        if (attribute != null)
                        {
                            // 非公有属性且不序列化
                            if (attribute.ProcessNonPublic == false && property.CanRead == false)
                            {
                                continue;
                            }
                            // 不序列化此属性
                            if (attribute.Ignore == true)
                            {
                                continue;
                            }
                            value = property.GetGetMethod(true).Invoke(obj, null);
                            // 不序列化 null 属性
                            if (value == null && attribute.IgnoreNull == true)
                            {
                                continue;
                            }
                            // 使用自定义映射名字
                            if (attribute.Name != null)
                            {
                                name = "\"" + attribute.Name + "\"";
                            }
                            else
                            {
                                name = "\"" + property.Name + "\"";
                            }
                            // 使用自定义序列化
                            if (attribute.Converter != null)
                            {
                                JsonConverter converter = (JsonConverter)Activator.CreateInstance(attribute.Converter);
                                bool skip;
                                valueString = converter.Serialize(value, property.PropertyType, out skip);
                                if (skip == true)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                valueString = SerializeObject(value);
                            }
                        }
                        else
                        {
                            if (property.CanRead == false)
                            {
                                continue;
                            }
                            name = "\"" + property.Name + "\"";
                            value = property.GetValue(obj);
                            valueString = SerializeObject(value);
                        }
                        values.Add(name + ":" + valueString);
                    }
                }
                #endregion
                return "{" + string.Join(",", values) + "}";
            }
            #endregion
        }
    }
}