using System;
using System.Reflection;

namespace Common.Reflection
{
    public static partial class ReflectionHelper
    {
        public static bool HasField(object obj, string fieldName, SearchOption option = SearchOption.Default)
        {
            FieldInfo field;
            return HasField(obj, fieldName, out field, option);
        }

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

        public static object GetField(object obj, string fieldName, SearchOption option = SearchOption.Default)
        {
            FieldInfo field;
            if (HasField(obj, fieldName, out field, option) == true)
            {
                return field.GetValue(obj);
            }
            return null;
        }

        public static T GetField<T>(object obj, string fieldName, SearchOption option = SearchOption.Default)
        {
            return (T)GetField(obj, fieldName, option);
        }

        public static void SetField(object obj, string fieldName, object value, SearchOption option = SearchOption.Default)
        {
            FieldInfo field;
            if (HasField(obj, fieldName, out field, option) == true)
            {
                field.SetValue(obj, value);
            }
        }
    }
}