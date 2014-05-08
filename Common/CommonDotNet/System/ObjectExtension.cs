
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
    }
}
