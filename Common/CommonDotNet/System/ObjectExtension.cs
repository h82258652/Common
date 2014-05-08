
using System.ComponentModel;

namespace System
{
    public static partial class ObjectExtension
    {
        public static T IfNull<T>(this T obj, Action<T> action) where T : class
        {
            if (obj == null)
            {
                action(obj);
            }
            return obj;
        }

        public static T IfNotNull<T>(this T obj, Action<T> action) where T : class
        {
            if (obj != null)
            {
                action(obj);
            }
            return obj;
        }

        public static T If<T>(this T obj, Predicate<T> predicate, Action<T> action)
        {
            if (predicate(obj) == true)
            {
                action(obj);
            }
            return obj;
        }

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
        
        public static T IfElse<T>(this T obj, Predicate<T> predicate, Action< T> trueAction, Action<T> falseAction)
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
