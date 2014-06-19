
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

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
        /// <returns>若条件成立，则返回方法的返回值，否则返回当前对象。</returns>
        public static T If<T>(this T obj, Predicate<T> predicate, Func<T, T> func)
        {
            return predicate(obj) == true ? func(obj) : obj;
        }

        /// <summary>
        /// 如果条件不成立，则执行方法。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="predicate">判断条件。</param>
        /// <param name="action">条件成立时执行的方法。</param>
        /// <returns>当前对象。</returns>
        public static T IfNot<T>(this T obj, Predicate<T> predicate, Action<T> action)
        {
            if (predicate(obj) == false)
            {
                action(obj);
            }
            return obj;
        }

        /// <summary>
        /// 如果条件不成立，则执行方法。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="predicate">判断条件。</param>
        /// <param name="func">条件不成立时执行的方法。</param>
        /// <returns>若条件不成立，则返回方法的返回值，否则返回当前对象。</returns>
        public static T IfNot<T>(this T obj, Predicate<T> predicate, Func<T, T> func)
        {
            return predicate(obj) == false ? func(obj) : obj;
        }

        /// <summary>
        /// 根据条件，执行方法。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="predicate">判断条件。</param>
        /// <param name="trueAction">条件成立时执行的方法。</param>
        /// <param name="falseAction">条件不成立时执行的方法。</param>
        /// <returns>当前对象。</returns>
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

        /// <summary>
        /// 根据条件，执行方法。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="predicate">判断条件。</param>
        /// <param name="trueFunc">条件成立时执行的方法。</param>
        /// <param name="falseFunc">条件不成立时执行的方法。</param>
        /// <returns>方法的返回值。</returns>
        public static T IfElse<T>(this T obj, Predicate<T> predicate, Func<T, T> trueFunc, Func<T, T> falseFunc)
        {
            return predicate(obj) == true ? trueFunc(obj) : falseFunc(obj);
        }

        /// <summary>
        /// 获取字段或属性的名称。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="lambdaExpression">访问字段或属性表达式。</param>
        /// <returns>字段或属性的名称。</returns>
        public static string MemberName<T>(this T obj, Expression<Func<T, object>> lambdaExpression)
        {
            return GetNameFromExpression(lambdaExpression);
        }

        /// <summary>
        /// 获取无返回值方法的名称。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="lambdaExpression">访问方法表达式。</param>
        /// <returns>方法的名称。</returns>
        public static string MemberName<T>(this T obj, Expression<Func<T, Action>> lambdaExpression)
        {
            return GetNameFromExpression(lambdaExpression);
        }

        /// <summary>
        /// 获取无返回值方法的名称。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <typeparam name="T1">方法第一个参数的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="lambdaExpression">访问方法表达式。</param>
        /// <returns>方法的名称。</returns>
        public static string MemberName<T, T1>(this T obj, Expression<Func<T, Action<T1>>> lambdaExpression)
        {
            return GetNameFromExpression(lambdaExpression);
        }

        /// <summary>
        /// 获取无返回值方法的名称。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <typeparam name="T1">方法第一个参数的类型。</typeparam>
        /// <typeparam name="T2">方法第二个参数的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="lambdaExpression">访问方法表达式。</param>
        /// <returns>方法的名称。</returns>
        public static string MemberName<T, T1, T2>(this T obj, Expression<Func<T, Action<T1, T2>>> lambdaExpression)
        {
            return GetNameFromExpression(lambdaExpression);
        }

        /// <summary>
        /// 获取无返回值方法的名称。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <typeparam name="T1">方法第一个参数的类型。</typeparam>
        /// <typeparam name="T2">方法第二个参数的类型。</typeparam>
        /// <typeparam name="T3">方法第三个参数的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="lambdaExpression">访问方法表达式。</param>
        /// <returns>方法的名称。</returns>
        public static string MemberName<T, T1, T2, T3>(this T obj, Expression<Func<T, Action<T1, T2, T3>>> lambdaExpression)
        {
            return GetNameFromExpression(lambdaExpression);
        }

        /// <summary>
        /// 获取无返回值方法的名称。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <typeparam name="T1">方法第一个参数的类型。</typeparam>
        /// <typeparam name="T2">方法第二个参数的类型。</typeparam>
        /// <typeparam name="T3">方法第三个参数的类型。</typeparam>
        /// <typeparam name="T4">方法第四个参数的类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="lambdaExpression">访问方法表达式。</param>
        /// <returns>方法的名称。</returns>
        public static string MemberName<T, T1, T2, T3, T4>(this T obj, Expression<Func<T, Action<T1, T2, T3, T4>>> lambdaExpression)
        {
            return GetNameFromExpression(lambdaExpression);
        }

        /// <summary>
        /// 获取有返回值方法的名称。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <typeparam name="TResult">方法的返回值类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="lambdaExpression">访问方法表达式。</param>
        /// <returns>方法的名称。</returns>
        public static string MemberName<T, TResult>(this T obj, Expression<Func<T, Func<TResult>>> lambdaExpression)
        {
            return GetNameFromExpression(lambdaExpression);
        }

        /// <summary>
        /// 获取有返回值方法的名称。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <typeparam name="T1">方法第一个参数的类型。</typeparam>
        /// <typeparam name="TResult">方法的返回值类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="lambdaExpression">访问方法表达式。</param>
        /// <returns>方法的名称。</returns>
        public static string MemberName<T, T1, TResult>(this T obj, Expression<Func<T, Func<T1, TResult>>> lambdaExpression)
        {
            return GetNameFromExpression(lambdaExpression);
        }

        /// <summary>
        /// 获取有返回值方法的名称。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <typeparam name="T1">方法第一个参数的类型。</typeparam>
        /// <typeparam name="T2">方法第二个参数的类型。</typeparam>
        /// <typeparam name="TResult">方法的返回值类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="lambdaExpression">访问方法表达式。</param>
        /// <returns>方法的名称。</returns>
        public static string MemberName<T, T1, T2, TResult>(this T obj, Expression<Func<T, Func<T1, T2, TResult>>> lambdaExpression)
        {
            return GetNameFromExpression(lambdaExpression);
        }

        /// <summary>
        /// 获取有返回值方法的名称。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <typeparam name="T1">方法第一个参数的类型。</typeparam>
        /// <typeparam name="T2">方法第二个参数的类型。</typeparam>
        /// <typeparam name="T3">方法第三个参数的类型。</typeparam>
        /// <typeparam name="TResult">方法的返回值类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="lambdaExpression">访问方法表达式。</param>
        /// <returns>方法的名称。</returns>
        public static string MemberName<T, T1, T2, T3, TResult>(this T obj, Expression<Func<T, Func<T1, T2, T3, TResult>>> lambdaExpression)
        {
            return GetNameFromExpression(lambdaExpression);
        }

        /// <summary>
        /// 获取有返回值方法的名称。
        /// </summary>
        /// <typeparam name="T">当前对象的类型。</typeparam>
        /// <typeparam name="T1">方法第一个参数的类型。</typeparam>
        /// <typeparam name="T2">方法第二个参数的类型。</typeparam>
        /// <typeparam name="T3">方法第三个参数的类型。</typeparam>
        /// <typeparam name="T4">方法第四个参数的类型。</typeparam>
        /// <typeparam name="TResult">方法的返回值类型。</typeparam>
        /// <param name="obj">当前对象。</param>
        /// <param name="lambdaExpression">访问方法表达式。</param>
        /// <returns>方法的名称。</returns>
        public static string MemberName<T, T1, T2, T3, T4, TResult>(this T obj, Expression<Func<T, Func<T1, T2, T3, T4, TResult>>> lambdaExpression)
        {
            return GetNameFromExpression(lambdaExpression);
        }

        private static string GetNameFromExpression(LambdaExpression lambdaExpression)
        {
            Expression expressionBody = lambdaExpression.Body;
            {
                UnaryExpression unaryExpression = expressionBody as UnaryExpression;
                if (unaryExpression != null)
                {
                    MemberExpression memberExpression = unaryExpression.Operand as MemberExpression;
                    if (memberExpression != null)
                    {
                        return memberExpression.Member.Name;
                    }
                    MethodCallExpression methodCallExpression = unaryExpression.Operand as MethodCallExpression;
                    if (methodCallExpression != null)
                    {
                        ConstantExpression constantExpression = methodCallExpression.Object as ConstantExpression;
                        if (constantExpression != null)
                        {
                            MethodInfo methodInfo = constantExpression.Value as MethodInfo;
                            if (methodInfo != null)
                            {
                                return methodInfo.Name;
                            }
                            else
                            {
                                throw new Exception(lambdaExpression.ToString());
                            }
                        }
                        ParameterExpression parameterExpression = methodCallExpression.Object as ParameterExpression;
                        if (parameterExpression != null)
                        {
                            // 索引器访问。
                            return string.Empty;
                        }
                        else
                        {
                            throw new Exception(lambdaExpression.ToString());
                        }
                    }
                }
            }
            {
                MemberExpression memberExpression = expressionBody as MemberExpression;
                if (memberExpression != null)
                {
                    return memberExpression.Member.Name;
                }
            }
            {
                MethodCallExpression methodCallExpression = expressionBody as MethodCallExpression;
                if (methodCallExpression != null)
                {
                    return methodCallExpression.Method.Name;
                }
            }
            throw new Exception(lambdaExpression.ToString());
        }
    }
}
