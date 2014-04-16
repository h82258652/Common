using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private object DeserializeToClass(string input, Type type)
        {

            if (input.StartsWith("{") == true && input.EndsWith("}") == true)
            {
                string source = input;
                input = input.Substring(1, input.Length - 2);
                Dictionary<string, string> keyValue = new Dictionary<string, string>();
                foreach (var temp in JsonHelper.ItemReader(input))
                {
                    int index = temp.IndexOf(':');
                    if (index == -1)
                    {
                        throw new JsonDeserializeException(source, type);
                    }
                    else
                    {
                        string key = temp.Substring(0, index).Trim();
                        if (key.StartsWith("\"") == true && key.EndsWith("\"") == true)
                        {
                            key = key.Substring(1, key.Length - 2);
                        }
                        else
                        {
                            throw new JsonDeserializeException(source, type);
                        }

                        string value = temp.Substring(index + 1).Trim();

                        if (keyValue.ContainsKey(key) == false)
                        {
                            keyValue.Add(key, value);
                        }
                        else
                        {
                            throw new JsonDeserializeException(source, type);
                        }
                    }
                }
                #region 匿名类。
                if (type.Name.Contains("AnonymousType") == true && string.IsNullOrEmpty(type.Namespace) == true)
                {
                    // 获取匿名类唯一构造函数。
                    ConstructorInfo constructor = type.GetConstructors().Single();

                    // 获取匿名类构造函数的参数。
                    ParameterInfo[] parameters = constructor.GetParameters();

                    // 存放反序列化的参数。
                    List<object> args = new List<object>();

                    foreach (ParameterInfo parameter in parameters)
                    {
                        // 参数名字。
                        string parameterName = parameter.Name;
                        if (keyValue.ContainsKey(parameterName) == true)
                        {
                            // json 中存在对应的值。
                            args.Add(DeserializeToObject(keyValue[parameterName], parameter.ParameterType));
                        }
                        else
                        {
                            // json 中不存在对应的值，填充类型的默认值。
                            args.Add(FormatterServices.GetUninitializedObject(parameter.ParameterType));
                        }
                    }

                    // 执行构造函数。
                    return constructor.Invoke(args.ToArray());
                }
                #endregion
                object instance;
                try
                {
                    instance = Activator.CreateInstance(type, true);
                }
                catch
                {
                    var constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).OrderBy(temp => temp.IsPublic == false).ThenBy(temp => temp.GetParameters().Length);
                    var constructor = constructors.ElementAt(0);
                    instance = constructor.Invoke(new object[constructor.GetParameters().Length]);
                }
                #region 字段。
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
                foreach (FieldInfo field in fields)
                {
                    JsonAttribute attribute = field.GetCustomAttributes(typeof(JsonAttribute), false).FirstOrDefault() as JsonAttribute;
                    if (attribute != null)
                    {
                        if (field.IsPublic == false && attribute.ProcessNonPublic == false)
                        {
                            continue;
                        }
                        string name;
                        object value;
                        if (string.IsNullOrEmpty(attribute.Name) == true)
                        {
                            name = field.Name;
                        }
                        else
                        {
                            name = attribute.Name;
                        }
                        if (keyValue.ContainsKey(name) == true)
                        {
                            if (attribute.Converter != null)
                            {
                                JsonConverter converter = Activator.CreateInstance(attribute.Converter) as JsonConverter;
                                if (converter != null)
                                {
                                    bool skip = false;
                                    value = converter.Deserialize(keyValue[name], field.FieldType, ref skip);
                                    if (skip == true)
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    throw new JsonDeserializeException(source, type);
                                }
                            }
                            else
                            {
                                value = DeserializeToObject(keyValue[name], field.FieldType);
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
                        string name = field.Name;
                        if (keyValue.ContainsKey(name) == true)
                        {
                            field.SetValue(instance, DeserializeToObject(keyValue[name], field.FieldType));
                        }
                    }
                }
                #endregion
                #region 属性。
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
                foreach (PropertyInfo property in properties)
                {
                    if (property.GetIndexParameters().Length == 0)
                    {
                        JsonAttribute attribute = property.GetCustomAttributes(typeof(JsonAttribute), false).FirstOrDefault() as JsonAttribute;
                        if (attribute != null)
                        {
                            if (property.CanWrite == false && attribute.ProcessNonPublic == false)
                            {
                                continue;
                            }
                            MethodInfo setMethod = property.GetSetMethod(true);
                            if (setMethod == null)
                            {
                                continue;
                            }
                            string name;
                            object value;
                            if (string.IsNullOrEmpty(attribute.Name) == true)
                            {
                                name = property.Name;
                            }
                            else
                            {
                                name = attribute.Name;
                            }
                            if (keyValue.ContainsKey(name) == true)
                            {
                                if (attribute.Converter != null)
                                {
                                    JsonConverter converter =
                                        Activator.CreateInstance(attribute.Converter) as JsonConverter;
                                    if (converter != null)
                                    {
                                        bool skip = false;
                                        value = converter.Deserialize(keyValue[name], property.PropertyType, ref skip);
                                        if (skip == true)
                                        {
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        throw new JsonDeserializeException(source, type);
                                    }
                                }
                                else
                                {
                                    value = DeserializeToObject(keyValue[name], property.PropertyType);
                                }

                                setMethod.Invoke(instance, new object[1] { value });
                            }
                        }
                        else
                        {
                            if (property.CanWrite == false)
                            {
                                continue;
                            }
                            string name = property.Name;
                            if (keyValue.ContainsKey(name) == true)
                            {
                                property.SetValue(instance, DeserializeToObject(keyValue[name], property.PropertyType), null);
                            }
                        }
                    }
                }
                #endregion
                return instance;
            }
            else
            {
                throw new JsonDeserializeException(input, type);
            }
        }
    }
}
