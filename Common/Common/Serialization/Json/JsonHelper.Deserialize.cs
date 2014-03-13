using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Serialization
{
    /// <summary>
    /// 为启用 AFAX 的应用程序提供序列化和反序列化功能。
    /// </summary>
    public static partial class JsonHelper
    {
        private static IEnumerable<string> JsonItemReader(string input)
        {
            if (input.Length == 0)
            {
                yield return null;
                yield break;
            }
            int startIndex = 0;
            int doubleQuote = 0;// 双引号
            int bracket = 0;// 中括号
            int brace = 0;// 大括号
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\')
                {
                    i++;
                    continue;
                }
                if (input[i] == '\"')
                {
                    doubleQuote = 1 - doubleQuote;
                }
                if (input[i] == '[')
                {
                    bracket++;
                }
                if (input[i] == ']')
                {
                    bracket--;
                }
                if (input[i] == '{')
                {
                    brace++;
                }
                if (input[i] == '}')
                {
                    brace--;
                }
                if (input[i] == ',' && bracket == 0 && brace == 0)
                {
                    string item = input.Substring(startIndex, i - startIndex);
                    startIndex = i + 1;
                    item = item.Trim();
                    yield return item;
                }
            }
            {
                string item = input.Substring(startIndex, input.Length - startIndex);
                item = item.Trim();
                yield return item;
            }
            yield break;
        }

        /// <summary>
        /// 将指定的 JSON 字符串转换为 T 类型的对象。
        /// </summary>
        /// <param name="input">要进行反序列化的 JSON 字符串。</param>
        /// <param name="type">所生成对象的类型。</param>
        /// <returns>反序列化的对象。</returns>
        /// <exception cref="Common.Serialization.JsonFormatException"></exception>
        public static object Deserialize(string input, Type type)
        {
            input = input.Trim();
            #region null
            if (input == "null")
            {
                return null;
            }
            #endregion
            #region bool
            if (type == typeof(bool))
            {
                return input == "true";
            }
            #endregion bool
            #region char
            if (type == typeof(char))
            {
                string s = (string)Deserialize(input, typeof(string));
                if (s.Length == 1)
                {
                    return s[0];
                }
                else
                {
                    // char 长度不为1
                    throw new JsonFormatException("无法将“" + s + "”转换为 " + type.Name + " 类型。");
                }
            }
            #endregion char
            #region string
            if (type == typeof(string))
            {
                if (input.StartsWith("\"") && input.EndsWith("\""))
                {
                    input = input.Substring(1, input.Length - 2);
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == '\\')
                        {
                            if (i + 1 == input.Length)
                            {
                                // 转义符错误
                                throw new Exception("JSON格式错误");
                            }
                            if (input[i + 1] == '\\')
                            {
                                sb.Append("\\");
                            }
                            else if (input[i + 1] == '0')
                            {
                                sb.Append("\0");
                            }
                            else if (input[i + 1] == 'a')
                            {
                                sb.Append("\a");
                            }
                            else if (input[i + 1] == 'b')
                            {
                                sb.Append("\b");
                            }
                            else if (input[i + 1] == 'f')
                            {
                                sb.Append("\f");
                            }
                            else if (input[i + 1] == 'n')
                            {
                                sb.Append("\n");
                            }
                            else if (input[i + 1] == 'r')
                            {
                                sb.Append("\r");
                            }
                            else if (input[i + 1] == 't')
                            {
                                sb.Append("\t");
                            }
                            else if (input[i + 1] == 'v')
                            {
                                sb.Append("\v");
                            }
                            else
                            {
                                // 转义符错误
                                throw new JsonFormatException("转义符错误。");
                            }
                            i++;
                        }
                        else
                        {
                            sb.Append(input[i]);
                        }
                    }
                    return sb.ToString();
                }
                else
                {
                    // 缺少前后的双引号
                    throw new JsonFormatException("字符串缺失双引号。");
                }
            }
            #endregion
            #region number
            if (type == typeof(byte) || type == typeof(sbyte) || type == typeof(short) || type == typeof(int) || type == typeof(long) || type == typeof(float) || type == typeof(double) || type == typeof(ushort) || type == typeof(uint) || type == typeof(ulong) || type == typeof(decimal))
            {
                return Convert.ChangeType(input, type);
            }
            if (type == typeof(BigInteger))
            {
                return BigInteger.Parse(input);
            }
            #endregion
            #region DateTime
            if (type == typeof(DateTime))
            {
                Regex r;
                r = new Regex(@"^new\s+Date\((\d*)\)$");
                if (r.IsMatch(input) == true)
                {
                    Match m = r.Match(input);
                    string msString = m.Groups[1].Value;
                    DateTime dt = new DateTime(1970, 1, 1, 8, 0, 0);
                    return dt.AddMilliseconds(double.Parse(msString));
                }
                if (input.StartsWith("\"") && input.EndsWith("\""))
                {
                    input = input.Substring(1, input.Length - 2);
                    r = new Regex(@"^(\d{4})\-(\d{2})\-(\d{2})T(\d{2}):(\d{2}):(\d{2})(\.\d*)?([\+|\-]\d{2}:\d{2})?$");
                    if (r.IsMatch(input) == true)
                    {
                        Match m = r.Match(input);
                        string syear = m.Groups[1].Value;
                        string smonth = m.Groups[2].Value;
                        string sday = m.Groups[3].Value;
                        string shour = m.Groups[4].Value;
                        string sminute = m.Groups[5].Value;
                        string ssecond = m.Groups[6].Value;
                        string sms = m.Groups[7].Value;
                        string szone = m.Groups[8].Value;

                        int year = int.Parse(syear);
                        int month = int.Parse(smonth);
                        int day = int.Parse(sday);
                        int hour = int.Parse(shour);
                        int minute = int.Parse(sminute);
                        int second = int.Parse(ssecond);
                        double ms = double.Parse("0" + sms);

                        if (szone.Length == 0)// 不存在时区
                        {
                            return new DateTime((new DateTime(year, month, day, hour, minute, second)).Ticks + (long)(ms * 10000000));
                        }
                        else
                        {
                            return new DateTime((new DateTime(year, month, day, hour, minute, second)).Ticks + (long)(ms * 10000000), DateTimeKind.Local);
                        }
                    }
                    r = new Regex(@"^\\/Date\((\d+)\)\\/$");
                    if (r.IsMatch(input) == true)
                    {
                        Match m = r.Match(input);
                        string msString = m.Groups[1].Value;
                        DateTime dt = new DateTime(1970, 1, 1, 8, 0, 0);
                        return dt.AddMilliseconds(double.Parse(msString));
                    }
                }
                throw new JsonFormatException("无法将“" + input + "”转换为 " + type.Name + " 类型。");
            }
            #endregion
            #region Array
            if (type.IsArray == true)
            {
                if (input.StartsWith("[") && input.EndsWith("]"))
                {
                    input = input.Substring(1, input.Length - 2).Trim();
                    ArrayList arr = new ArrayList();
                    Type elementType = type.GetElementType();// 获取元素类型
                    foreach (var s in JsonItemReader(input))
                    {
                        arr.Add(Deserialize(s, elementType));
                    }
                    return arr.ToArray(elementType);
                }
                else
                {
                    throw new JsonFormatException(" " + input + " 缺失中括号。");
                }
            }
            #endregion
            #region List
            if (type is IList)
            {
                if (input.StartsWith("[") && input.EndsWith("]"))
                {
                    input = input.Substring(1, input.Length - 2).Trim();
                    IList list = (IList)Activator.CreateInstance(type);
                    Type elementType = type.GetGenericTypeDefinition();// 获取元素类型
                    foreach (var s in JsonItemReader(input))
                    {
                        list.Add(Deserialize(s, elementType));
                    }
                    return list;
                }
                else
                {
                    throw new JsonFormatException(" " + input + " 缺失中括号。");
                }
            }
            #endregion
            #region Dictionary
            if (type is IDictionary)
            {
                if (input.StartsWith("{") && input.EndsWith("}"))
                {
                    IDictionary dic = Activator.CreateInstance(type) as IDictionary;
                    Type valueType = dic.Values.GetType().GenericTypeArguments[1];
                    foreach (var s in JsonItemReader(input))
                    {
                        string key = s.Substring(0, s.IndexOf(':'));
                        string value = s.Substring(s.IndexOf(':') + 1);
                        dic.Add(key, Deserialize(value, valueType));
                    }
                    return dic;
                }
                else
                {
                    throw new JsonFormatException(" " + input + " 缺失大括号。");
                }
            }
            #endregion
            #region Class
            if (input.StartsWith("{") && input.EndsWith("}"))
            {
                input = input.Substring(1, input.Length - 2);
                object instance = Activator.CreateInstance(type);
                Dictionary<string, string> keyValue = new Dictionary<string, string>();
                foreach (var s in JsonItemReader(input))
                {
                    string key = s.Substring(0, s.IndexOf(':'));
                    string valueString = s.Substring(s.IndexOf(':') + 1);
                    key = key.Trim();
                    key = key.Substring(1, key.Length - 2);// 去除开始结尾的双引号
                    valueString = valueString.Trim();
                    keyValue.Add(key, valueString);
                }
                #region 字段
                FieldInfo[] fields;
                if (typeFields.TryGetValue(type, out fields) == false)
                {
                    fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
                    if (typeFields.ContainsKey(type) == false)
                    {
                        lock (typeFields)
                        {
                            if (typeFields.ContainsKey(type) == false)
                            {
                                typeFields.Add(type, fields);
                            }
                        }
                    }
                }
                foreach (FieldInfo field in fields)
                {
                    JsonAttribute attribute = field.GetCustomAttribute<JsonAttribute>(true);
                    if (attribute != null)
                    {
                        if (attribute.ProcessNonPublic == false && field.IsPublic == false)
                        {
                            continue;
                        }
                        string fieldName;
                        object value;
                        if (attribute.Name != null)
                        {
                            fieldName = attribute.Name;
                        }
                        else
                        {
                            fieldName = field.Name;
                        }
                        if (keyValue.ContainsKey(fieldName))
                        {
                            if (attribute.Converter != null)
                            {
                                JsonConverter converter = (JsonConverter)Activator.CreateInstance(attribute.Converter);
                                bool skip;
                                value = converter.Deserialize(keyValue[fieldName], field.FieldType, out skip);
                                if (skip == true)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                value = Deserialize(keyValue[fieldName], field.FieldType);
                            }
                            field.SetValue(instance, value);
                        }
                    }
                    else
                    {
                        if (field.IsPublic == false)
                        {
                            continue;
                        }
                        else
                        {
                            string fieldName = field.Name;
                            if (keyValue.ContainsKey(fieldName))
                            {
                                field.SetValue(instance, Deserialize(keyValue[fieldName], field.FieldType));
                            }
                        }
                    }
                }
                #endregion
                #region 属性
                PropertyInfo[] properties;
                if (typeProperties.TryGetValue(type, out properties) == false)
                {
                    properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    if (typeProperties.ContainsKey(type) == false)
                    {
                        lock (typeProperties)
                        {
                            if (typeProperties.ContainsKey(type) == false)
                            {
                                typeProperties.Add(type, properties);
                            }
                        }
                    }
                }
                foreach (PropertyInfo property in properties)
                {
                    JsonAttribute attribute = property.GetCustomAttribute<JsonAttribute>(true);
                    if (attribute != null)
                    {
                        if (attribute.ProcessNonPublic == false && property.CanWrite == false)
                        {
                            continue;
                        }
                        string propertyName;
                        object value;
                        if (attribute.Name != null)
                        {
                            propertyName = attribute.Name;
                        }
                        else
                        {
                            propertyName = property.Name;
                        }
                        if (keyValue.ContainsKey(propertyName))
                        {
                            if (attribute.Converter != null)
                            {
                                JsonConverter converter = (JsonConverter)Activator.CreateInstance(attribute.Converter);
                                bool skip;
                                value = converter.Deserialize(keyValue[propertyName], property.PropertyType, out skip);
                                if (skip == true)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                value = Deserialize(keyValue[propertyName], property.PropertyType);
                            }
                            property.GetSetMethod(true).Invoke(instance, new object[] { value });
                        }
                    }
                    else
                    {
                        if (property.CanWrite == false)
                        {
                            continue;
                        }
                        else
                        {
                            string propertyName = property.Name;
                            if (keyValue.ContainsKey(propertyName))
                            {
                                property.SetValue(instance, Deserialize(keyValue[propertyName], property.PropertyType));
                            }
                        }
                    }
                }
                #endregion
                return instance;
            }
            #endregion
            throw new JsonFormatException("无法将“" + input + "”转换为 " + type.Name + " 类型。");
        }

        /// <summary>
        /// 将指定的 JSON 字符串转换为 T 类型的对象。
        /// </summary>
        /// <typeparam name="T">所生成对象的类型。</typeparam>
        /// <param name="input">要进行反序列化的 JSON 字符串。</param>
        /// <returns>反序列化的对象。</returns>
        /// <exception cref="Common.Serialization.JsonFormatException"></exception>
        public static T Deserialize<T>(string input)
        {
            return (T)Deserialize(input, typeof(T));
        }
    }
}
