using System;
using System.Reflection;

namespace Common.Reflection
{
    public static partial class ReflectionHelper
    {
        /// <summary>
        /// 创建指定类的实例
        /// </summary>
        /// <param name="t">需创建实例的类</param>
        /// <param name="args">构造函数参数</param>
        /// <returns>类的实例</returns>
        public static object Create(Type t, params object[] args)
        {
            return Activator.CreateInstance(t, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, args, null);
        }

        /// <summary>
        /// 创建指定类的实例
        /// </summary>
        /// <typeparam name="T">需创建实例的类</typeparam>
        /// <param name="args">构造函数参数</param>
        /// <returns>类的实例</returns>
        public static T Create<T>(params object[] args)
        {
            return (T)Create(typeof(T), args);
        }
    }
}
