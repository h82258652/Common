using System;
using System.Reflection;

namespace Common.Reflection
{
    public static partial class ReflectionHelper
    {
        /// <summary>
        /// 获取对象指定的字段。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="fieldName">字段名称。</param>
        /// <param name="option">字段名称的匹配方式。</param>
        /// <returns>字段的值。</returns>
        public static object GetField(object obj, string fieldName, SearchOption option = SearchOption.Default)
        {
            FieldInfo field;
            if (HasField(obj, fieldName, out field, option) == true)
            {
                return field.GetValue(obj);
            }
            return null;
        }

        /// <summary>
        /// 获取对象指定的字段。
        /// </summary>
        /// <typeparam name="T">字段的类型。</typeparam>
        /// <param name="obj">对象。</param>
        /// <param name="fieldName">字段名称。</param>
        /// <param name="option">字段名称的匹配方式。</param>
        /// <returns>字段的值。</returns>
        public static T GetField<T>(object obj, string fieldName, SearchOption option = SearchOption.Default)
        {
            return (T)GetField(obj, fieldName, option);
        }

        /// <summary>
        /// 指示对象是否具有指定名称的字段。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="fieldName">字段名称。</param>
        /// <param name="option">字段名称的匹配方式。</param>
        /// <returns>是否具有字段。</returns>
        public static bool HasField(object obj, string fieldName, SearchOption option = SearchOption.Default)
        {
            FieldInfo field;
            return HasField(obj, fieldName, out field, option);
        }

        /// <summary>
        /// 指示对象是否具有指定名称的字段。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="fieldName">字段名称。</param>
        /// <param name="field">若有，则返回字段。否则返回 null。</param>
        /// <param name="option">字段名称的匹配方式。</param>
        /// <returns>是否具有字段。</returns>
        public static bool HasField(object obj, string fieldName, out FieldInfo field, SearchOption option = SearchOption.Default)
        {
            Type t = obj.GetType();
            BindingFlags flags = BindingFlags.Default;
            if (option == SearchOption.IgnoreCase)
            {
                flags = flags | BindingFlags.IgnoreCase;
            }
            field = t.GetField(fieldName, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance | flags);
            return field != null;
        }

        /// <summary>
        /// 设置对象指定的字段。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="fieldName">字段名称。</param>
        /// <param name="value">值。</param>
        /// <param name="option">字段名称的匹配方式。</param>
        /// <returns>是否设置成功。</returns>
        public static bool SetField(object obj, string fieldName, object value, SearchOption option = SearchOption.Default)
        {
            FieldInfo field;
            if (HasField(obj, fieldName, out field, option) == true)
            {
                field.SetValue(obj, value);
                return true;
            }
            return false;
        }
    }
}
