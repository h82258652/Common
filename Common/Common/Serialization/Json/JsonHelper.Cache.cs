using System;
using System.Collections.Generic;
using System.Reflection;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        /// <summary>
        /// 缓存类的字段。
        /// </summary>
        internal static volatile Dictionary<Type, FieldInfo[]> typeFields = new Dictionary<Type, FieldInfo[]>();

        /// <summary>
        /// 缓存类的属性。
        /// </summary>
        internal static volatile Dictionary<Type, PropertyInfo[]> typeProperties = new Dictionary<Type, PropertyInfo[]>();
    }
}
