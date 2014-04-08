using System;
using System.Collections.Generic;
using System.Reflection;

namespace Common.Serialization.Json
{
    /// <summary>
    /// JSON 序列化与反序列化帮助类。
    /// </summary>
    public static partial class JsonHelper
    {
        /// <summary>
        /// 缓存类的字段。
        /// </summary>
        internal static volatile Dictionary<Type, FieldInfo[]> _typeFields = new Dictionary<Type, FieldInfo[]>();

        /// <summary>
        /// 缓存类的属性。
        /// </summary>
        internal static volatile Dictionary<Type, PropertyInfo[]> _typeProperties = new Dictionary<Type, PropertyInfo[]>();
    }
}
