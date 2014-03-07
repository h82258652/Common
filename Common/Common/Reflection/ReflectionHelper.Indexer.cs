using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.Reflection
{
    public static partial class ReflectionHelper
    {
        /// <summary>
        /// 指示对象是否存在索引器
        /// </summary>
        /// <param name="obj">测试的对象</param>
        /// <returns></returns>
        public static bool HasIndexer(object obj)
        {
            return GetIndexerCount(obj) > 0;
        }

        /// <summary>
        /// 指示对象具有的索引器的数量
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetIndexerCount(object obj)
        {
            return GetAllIndexer(obj).Length;
        }

        /// <summary>
        /// 获取对象的所有索引器
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetAllIndexer(object obj)
        {
            Type t = obj.GetType();
            return t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(temp => temp.GetIndexParameters().Length > 0).ToArray();
        }

        /// <summary>
        /// 获取索引器的值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="args">索引器参数</param>
        /// <returns></returns>
        public static object GetIndexer(object obj, params object[] args)
        {
            foreach (var indexer in GetAllIndexer(obj).Where(temp => temp.GetIndexParameters().Length == args.Length))
            {
                try
                {
                    MethodInfo method = indexer.GetGetMethod(true);
                    return method.Invoke(obj, args);
                }
                catch
                {
                    continue;
                }
            }
            return null;
        }

        public static T GetIndexer<T>(object obj, params object[] args)
        {
            return (T)GetIndexer(obj, args);
        }

        /// <summary>
        /// 设置索引器的值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="value">值</param>
        /// <param name="args">索引器参数</param>
        public static void SetIndexer(object obj, object value, params object[] args)
        {
            foreach (var indexer in GetAllIndexer(obj).Where(temp => temp.GetIndexParameters().Length == args.Length))
            {
                try
                {
                    MethodInfo method = indexer.GetSetMethod(true);
                    List<object> list = new List<object>(args);
                    list.Add(value);
                    method.Invoke(obj, list.ToArray());
                    break;
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}