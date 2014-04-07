using System;
using System.Reflection;

namespace Common.Reflection
{
    public static partial class ReflectionHelper
    {
        /// <summary>
        /// 指示对象是否具有指定名称的方法。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="methodName">方法名称。</param>
        /// <param name="option">方法名称的匹配方式。</param>
        /// <returns>是否具有方法。</returns>
        public static bool HasMethod(object obj, string methodName, SearchOption option = SearchOption.Default)
        {
            MethodInfo method;
            return HasMethod(obj, methodName, out method, option);
        }

        /// <summary>
        /// 指示对象是否具有指定名称的方法。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="methodName">方法名称。</param>
        /// <param name="method">若有，则返回方法。否则返回 null。</param>
        /// <param name="option">方法名称的匹配方式。</param>
        /// <returns>是否具有方法。</returns>
        public static bool HasMethod(object obj, string methodName, out MethodInfo method, SearchOption option = SearchOption.Default)
        {
            Type t = obj.GetType();
            BindingFlags flags = (BindingFlags)0;
            if (option == SearchOption.IgnoreCase)
            {
                flags = flags | BindingFlags.IgnoreCase;
            }
            method = t.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance | flags);
            return method != null;
        }

        /// <summary>
        /// 执行对象指定的实例方法。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="methodName">方法名称。</param>
        /// <param name="args">方法参数。</param>
        /// <returns>方法的返回值。</returns>
        public static object InvokeMethod(object obj, string methodName, params object[] args)
        {
            return InvokeMethod(obj, methodName, SearchOption.Default, args);
        }

        /// <summary>
        /// 执行对象指定的实例方法。
        /// </summary>
        /// <param name="obj">对象。</param>
        /// <param name="methodName">方法名称。</param>
        /// <param name="option">方法名称的匹配方式。</param>
        /// <param name="args">方法参数。</param>
        /// <returns>方法的返回值。</returns>
        public static object InvokeMethod(object obj, string methodName, SearchOption option = SearchOption.Default, params object[] args)
        {
            MethodInfo method;
            if (HasMethod(obj, methodName, out method, option) == true)
            {
                return method.Invoke(obj, args);
            }
            return null;
        }

        /// <summary>
        /// 执行对象指定的实例方法。
        /// </summary>
        /// <typeparam name="T">方法的返回值类型。</typeparam>
        /// <param name="obj">对象。</param>
        /// <param name="methodName">方法名称。</param>
        /// <param name="args">方法参数。</param>
        /// <returns>方法的返回值。</returns>
        public static T InvokeMethod<T>(object obj, string methodName, params object[] args)
        {
            return (T)InvokeMethod(obj, methodName, args);
        }

        /// <summary>
        /// 执行对象指定的实例方法。
        /// </summary>
        /// <typeparam name="T">方法的返回值类型。</typeparam>
        /// <param name="obj">对象。</param>
        /// <param name="methodName">方法名称。</param>
        /// <param name="option">方法名称的匹配方式。</param>
        /// <param name="args">方法参数。</param>
        /// <returns>方法的返回值。</returns>
        public static T InvokeMethod<T>(object obj, string methodName, SearchOption option = SearchOption.Default, params object[] args)
        {
            return (T)InvokeMethod(obj, methodName, option, args);
        }
    }
}
