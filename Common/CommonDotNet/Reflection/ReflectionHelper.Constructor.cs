using System;
using System.Linq;
using System.Reflection;

namespace Common.Reflection
{
    /// <summary>
    /// 反射帮助类。
    /// </summary>
    public static partial class ReflectionHelper
    {
        /// <summary>
        /// 创建指定类的实例。
        /// </summary>
        /// <param name="t">需创建实例的类。</param>
        /// <param name="args">构造函数参数。</param>
        /// <returns>类的实例。</returns>
        public static object Create(Type t, params object[] args)
        {
            try
            {
                return Activator.CreateInstance(t, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
            }
            catch
            {
                var constructors =
                    t.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).OrderBy(temp => temp.IsPublic == false).ThenBy(temp => temp.GetParameters().Length);
                var constructor = constructors.ElementAt(0);
                return constructor.Invoke(new object[constructor.GetParameters().Length]);
            }
        }

        /// <summary>
        /// 创建指定类的实例。
        /// </summary>
        /// <typeparam name="T">需创建实例的类。</typeparam>
        /// <param name="args">构造函数参数。</param>
        /// <returns>类的实例。</returns>
        public static T Create<T>(params object[] args)
        {
            return (T)Create(typeof(T), args);
        }
    }
}
