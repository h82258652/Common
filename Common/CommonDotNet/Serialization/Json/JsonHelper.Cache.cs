using System;
using System.Collections.Generic;
using System.Reflection;

namespace Common.Serialization.Json
{
    /// <summary>
    /// JSON ���л��뷴���л������ࡣ
    /// </summary>
    public static partial class JsonHelper
    {
        /// <summary>
        /// ��������ֶΡ�
        /// </summary>
        internal static volatile Dictionary<Type, FieldInfo[]> _typeFields = new Dictionary<Type, FieldInfo[]>();

        /// <summary>
        /// ����������ԡ�
        /// </summary>
        internal static volatile Dictionary<Type, PropertyInfo[]> _typeProperties = new Dictionary<Type, PropertyInfo[]>();
    }
}
