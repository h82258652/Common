using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeClass(object obj)
        {
            Type type = obj.GetType();
            List<string> values = new List<string>();
            #region 字段
            FieldInfo[] fields;
            if (JsonHelper._typeFields.TryGetValue(type, out fields) == false)
            {
                fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
                if (JsonHelper._typeFields.ContainsKey(type) == false)
                {
                    lock (JsonHelper._typeFields)
                    {
                        if (JsonHelper._typeFields.ContainsKey(type) == false)
                        {
                            JsonHelper._typeFields.Add(type, fields);
                        }
                    }
                }
            }
            foreach (var field in fields)
            {
                JsonAttribute attribute = field.GetCustomAttributes(typeof(JsonAttribute), false).FirstOrDefault() as JsonAttribute;
                string name;
                object value;
                string valueString;
                if (attribute != null)
                {
                    // 不序列化此字段。
                    if (attribute.Ignore == true)
                    {
                        continue;
                    }
                    // 非公有字段且不序列化。
                    if (field.IsPublic == false && attribute.ProcessNonPublic == false)
                    {
                        continue;
                    }
                    value = field.GetValue(obj);
                    // 不序列化 null 字段。
                    if (attribute.IgnoreNull == true && value == null)
                    {
                        continue;
                    }
                    // 字段是否必须。
                    if (attribute.Required == true && value == null)
                    {
                        throw new ArgumentNullException(field.Name, "该字段不能为 null。");
                    }
                    // 检查数量约束。
                    IEnumerable<object> enumerable = value as IEnumerable<object>;
                    if (enumerable != null)
                    {
                        if (attribute.CountLessThan > -1 && enumerable.Count() >= attribute.CountLessThan)
                        {
                            throw JsonCountException.CreateLessThanException(value, attribute.CountLessThan);
                        }
                        if (attribute.CountGreaterThan > -1 && enumerable.Count() <= attribute.CountGreaterThan)
                        {
                            throw JsonCountException.CreateGreaterThanException(value, attribute.CountGreaterThan);
                        }
                    }
                    // 使用自定义序列化。
                    if (attribute.Converter != null)
                    {
                        JsonConverter converter = (JsonConverter)Activator.CreateInstance(attribute.Converter);
                        bool skip = false;
                        valueString = converter.Serialize(value, field.FieldType, ref skip);
                        if (skip == true)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        valueString = SerializeObject(value);
                    }
                    // 使用自定义映射名字。
                    if (string.IsNullOrEmpty(attribute.Name) == false)
                    {
                        name = "\"" + attribute.Name + "\"";
                    }
                    else
                    {
                        name = "\"" + field.Name + "\"";
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
            #region 属性
            PropertyInfo[] properties;
            if (JsonHelper._typeProperties.TryGetValue(type, out properties) == false)
            {
                properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
                if (JsonHelper._typeProperties.ContainsKey(type) == false)
                {
                    lock (JsonHelper._typeProperties)
                    {
                        if (JsonHelper._typeProperties.ContainsKey(type) == false)
                        {
                            JsonHelper._typeProperties.Add(type, properties);
                        }
                    }
                }
            }
            foreach (var property in properties)
            {
                if (property.GetIndexParameters().Length == 0)
                {
                    JsonAttribute attribute = property.GetCustomAttributes(typeof(JsonAttribute), false).FirstOrDefault() as JsonAttribute;
                    string name;
                    object value;
                    string valueString;
                    if (attribute != null)
                    {
                        // 不序列化此属性。
                        if (attribute.Ignore == true)
                        {
                            continue;
                        }
                        // 非公有属性且不序列化。
                        if (property.CanRead == false && attribute.ProcessNonPublic == false)
                        {
                            continue;
                        }
                        value = property.GetGetMethod(true).Invoke(obj, null);
                        // 不序列化 null 属性。
                        if (attribute.IgnoreNull == true && value == null)
                        {
                            continue;
                        }
                        // 属性是否必须。
                        if (attribute.Required == true && value == null)
                        {
                            throw new ArgumentNullException(property.Name, "该属性不能为 null。");
                        }
                        // 检查数量约束。
                        IEnumerable<object> enumerable = value as IEnumerable<object>;
                        if (enumerable != null)
                        {
                            if (attribute.CountLessThan > -1 &&
                                enumerable.Count() >= attribute.CountLessThan)
                            {
                                throw JsonCountException.CreateLessThanException(value,
                                    attribute.CountLessThan);
                            }
                            if (attribute.CountGreaterThan > -1 &&
                                enumerable.Count() <= attribute.CountGreaterThan)
                            {
                                throw JsonCountException.CreateGreaterThanException(value,
                                    attribute.CountGreaterThan);
                            }
                        }
                        // 使用自定义序列化。
                        if (attribute.Converter != null)
                        {
                            JsonConverter converter = (JsonConverter)Activator.CreateInstance(attribute.Converter);
                            bool skip = false;
                            valueString = converter.Serialize(value, property.PropertyType, ref skip);
                            if (skip == true)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            valueString = SerializeObject(value);
                        }
                        // 使用自定义映射名字。
                        if (string.IsNullOrEmpty(attribute.Name) == false)
                        {
                            name = "\"" + attribute.Name + "\"";
                        }
                        else
                        {
                            name = "\"" + property.Name + "\"";
                        }
                    }
                    else
                    {
                        if (property.CanRead == false)
                        {
                            continue;
                        }
                        name = "\"" + property.Name + "\"";
                        value = property.GetValue(obj, null);
                        valueString = SerializeObject(value);
                    }
                    values.Add(name + ":" + valueString);
                }
            }
            #endregion
            return "{" + string.Join(",", values) + "}";
        }
    }
}
