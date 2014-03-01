using System;
using System.Reflection;

namespace Common.Reflection
{
    public static partial class ReflectionHelper
    {
        public static bool HasMethod(object obj, string methodName, SearchOption option = SearchOption.Default)
        {
            MethodInfo method;
            return HasMethod(obj, methodName, out method, option);
        }

        public static bool HasMethod(object obj, string methodName, out MethodInfo method, SearchOption option = SearchOption.Default)
        {
            Type t = obj.GetType();
            BindingFlags flags = BindingFlags.Default;
            if (option == SearchOption.IgnoreCase)
            {
                flags = flags | BindingFlags.IgnoreCase;
            }
            method = t.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance | flags);
            return method != null;
        }

        public static object InvokeMethod(object obj, string methodName, params object[] args)
        {
            return InvokeMethod(obj, methodName, SearchOption.Default, args);
        }

        public static T InvokeMethod<T>(object obj, string methodName, params object[] args)
        {
            return (T)InvokeMethod(obj, methodName, args);
        }

        public static object InvokeMethod(object obj, string methodName, SearchOption option = SearchOption.Default, params object[] args)
        {
            MethodInfo method;
            if (HasMethod(obj, methodName, out method, option) == true)
            {
                return method.Invoke(obj, args);
            }
            return null;
        }

        public static T InvokeMethod<T>(object obj, string methodName, SearchOption option = SearchOption.Default, params object[] args)
        {
            return (T)InvokeMethod(obj, methodName, option, args);
        }
    }
}