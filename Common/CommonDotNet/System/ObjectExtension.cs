
using System.ComponentModel;

namespace System
{
    /// <summary>
    /// System.Object 扩展类。
    /// </summary>
    public static partial class ObjectExtension
    {
        /// <summary>
        /// 如果当前对象为 null，则执行方法。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="action">若对象为 null，则执行的方法。</param>
        /// <returns>当前对象。</returns>
        public static T IfNull<T>(this T obj, Action<T> action) where T : class
        {
            if (obj == null)
            {
                action(obj);
            }
            return obj;
        }

        /// <summary>
        /// 如果当前对象为 null，则执行方法。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="action">若对象为 null，则执行的方法。</param>
        /// <returns>若对象为 null，则返回方法的返回值，否则返回当前对象。</returns>
        public static T IfNull<T>(this T obj, Func<T, T> action) where T : class
        {
            return obj == null ? action(obj) : obj;
        }

        /// <summary>
        /// 如果当前对象不为 null，则执行方法。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="action">若对象不为 null，则执行的方法。</param>
        /// <returns>当前对象。</returns>
        public static T IfNotNull<T>(this T obj, Action<T> action) where T : class
        {
            if (obj != null)
            {
                action(obj);
            }
            return obj;
        }

        /// <summary>
        /// 如果条件成立，则执行方法。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="predicate">判断条件。</param>
        /// <param name="action">条件成立时执行的方法。</param>
        /// <returns>当前对象。</returns>
        public static T If<T>(this T obj, Predicate<T> predicate, Action<T> action)
        {
            if (predicate(obj) == true)
            {
                action(obj);
            }
            return obj;
        }

        /// <summary>
        /// 如果条件成立，则执行方法。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="predicate">判断条件。</param>
        /// <param name="func">条件成立时执行的方法。</param>
        /// <returns></returns>
        public static T If<T>(this T obj, Predicate<T> predicate, Func<T, T> func)
        {
            return predicate(obj) == true ? func(obj) : obj;
        }

        public static T IfNot<T>(this T obj, Predicate<T> predicate, Action<T> action)
        {
            if (predicate(obj) == false)
            {
                action(obj);
            }
            return obj;
        }

        public static T IfNot<T>(this T obj, Predicate<T> predicate, Func<T, T> func)
        {
            return predicate(obj) == false ? func(obj) : obj;
        }

        public static T IfElse<T>(this T obj, Predicate<T> predicate, Action<T> trueAction, Action<T> falseAction)
        {
            if (predicate(obj) == true)
            {
                trueAction(obj);
            }
            else
            {
                falseAction(obj);
            }
            return obj;
        }

        public static T IfElse<T>(this T obj, Predicate<T> predicate, Func<T, T> trueFunc, Func<T, T> falseFunc)
        {
            return predicate(obj) == true ? trueFunc(obj) : falseFunc(obj);
        }
    }
}
