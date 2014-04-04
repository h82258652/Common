using System;
using System.Collections;
using System.Threading;

namespace Common.Threading
{
    /// <summary>
    /// 线程帮助类。用于异步执行方法。
    /// </summary>
    public static partial class ThreadHelper
    {
        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <param name="method">不带参数的方法。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction(Action method)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <param name="method">带一个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1>(Action<T1> method, T1 arg1)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <param name="method">带两个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2>(Action<T1, T2> method, T1 arg1, T2 arg2)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <param name="method">带三个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3>(Action<T1, T2, T3> method, T1 arg1, T2 arg2, T3 arg3)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <typeparam name="T4">第四个参数类型。</typeparam>
        /// <param name="method">带四个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <param name="arg4">方法的第四个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <typeparam name="T4">第四个参数类型。</typeparam>
        /// <typeparam name="T5">第五个参数类型。</typeparam>
        /// <param name="method">带五个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <param name="arg4">方法的第四个参数。</param>
        /// <param name="arg5">方法的第五个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <typeparam name="T4">第四个参数类型。</typeparam>
        /// <typeparam name="T5">第五个参数类型。</typeparam>
        /// <typeparam name="T6">第六个参数类型。</typeparam>
        /// <param name="method">带六个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <param name="arg4">方法的第四个参数。</param>
        /// <param name="arg5">方法的第五个参数。</param>
        /// <param name="arg6">方法的第六个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            arglist.Add(arg6);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <typeparam name="T4">第四个参数类型。</typeparam>
        /// <typeparam name="T5">第五个参数类型。</typeparam>
        /// <typeparam name="T6">第六个参数类型。</typeparam>
        /// <typeparam name="T7">第七个参数类型。</typeparam>
        /// <param name="method">带七个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <param name="arg4">方法的第四个参数。</param>
        /// <param name="arg5">方法的第五个参数。</param>
        /// <param name="arg6">方法的第六个参数。</param>
        /// <param name="arg7">方法的第七个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            arglist.Add(arg6);
            arglist.Add(arg7);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <typeparam name="T4">第四个参数类型。</typeparam>
        /// <typeparam name="T5">第五个参数类型。</typeparam>
        /// <typeparam name="T6">第六个参数类型。</typeparam>
        /// <typeparam name="T7">第七个参数类型。</typeparam>
        /// <typeparam name="T8">第八个参数类型。</typeparam>
        /// <param name="method">带八个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <param name="arg4">方法的第四个参数。</param>
        /// <param name="arg5">方法的第五个参数。</param>
        /// <param name="arg6">方法的第六个参数。</param>
        /// <param name="arg7">方法的第七个参数。</param>
        /// <param name="arg8">方法的第八个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            arglist.Add(arg6);
            arglist.Add(arg7);
            arglist.Add(arg8);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <typeparam name="T4">第四个参数类型。</typeparam>
        /// <typeparam name="T5">第五个参数类型。</typeparam>
        /// <typeparam name="T6">第六个参数类型。</typeparam>
        /// <typeparam name="T7">第七个参数类型。</typeparam>
        /// <typeparam name="T8">第八个参数类型。</typeparam>
        /// <typeparam name="T9">第九个参数类型。</typeparam>
        /// <param name="method">带九个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <param name="arg4">方法的第四个参数。</param>
        /// <param name="arg5">方法的第五个参数。</param>
        /// <param name="arg6">方法的第六个参数。</param>
        /// <param name="arg7">方法的第七个参数。</param>
        /// <param name="arg8">方法的第八个参数。</param>
        /// <param name="arg9">方法的第九个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            arglist.Add(arg6);
            arglist.Add(arg7);
            arglist.Add(arg8);
            arglist.Add(arg9);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <typeparam name="T4">第四个参数类型。</typeparam>
        /// <typeparam name="T5">第五个参数类型。</typeparam>
        /// <typeparam name="T6">第六个参数类型。</typeparam>
        /// <typeparam name="T7">第七个参数类型。</typeparam>
        /// <typeparam name="T8">第八个参数类型。</typeparam>
        /// <typeparam name="T9">第九个参数类型。</typeparam>
        /// <typeparam name="T10">第十个参数类型。</typeparam>
        /// <param name="method">带十个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <param name="arg4">方法的第四个参数。</param>
        /// <param name="arg5">方法的第五个参数。</param>
        /// <param name="arg6">方法的第六个参数。</param>
        /// <param name="arg7">方法的第七个参数。</param>
        /// <param name="arg8">方法的第八个参数。</param>
        /// <param name="arg9">方法的第九个参数。</param>
        /// <param name="arg10">方法的第十个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            arglist.Add(arg6);
            arglist.Add(arg7);
            arglist.Add(arg8);
            arglist.Add(arg9);
            arglist.Add(arg10);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <typeparam name="T4">第四个参数类型。</typeparam>
        /// <typeparam name="T5">第五个参数类型。</typeparam>
        /// <typeparam name="T6">第六个参数类型。</typeparam>
        /// <typeparam name="T7">第七个参数类型。</typeparam>
        /// <typeparam name="T8">第八个参数类型。</typeparam>
        /// <typeparam name="T9">第九个参数类型。</typeparam>
        /// <typeparam name="T10">第十个参数类型。</typeparam>
        /// <typeparam name="T11">第十一个参数类型。</typeparam>
        /// <param name="method">带十一个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <param name="arg4">方法的第四个参数。</param>
        /// <param name="arg5">方法的第五个参数。</param>
        /// <param name="arg6">方法的第六个参数。</param>
        /// <param name="arg7">方法的第七个参数。</param>
        /// <param name="arg8">方法的第八个参数。</param>
        /// <param name="arg9">方法的第九个参数。</param>
        /// <param name="arg10">方法的第十个参数。</param>
        /// <param name="arg11">方法的第十一个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            arglist.Add(arg6);
            arglist.Add(arg7);
            arglist.Add(arg8);
            arglist.Add(arg9);
            arglist.Add(arg10);
            arglist.Add(arg11);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <typeparam name="T4">第四个参数类型。</typeparam>
        /// <typeparam name="T5">第五个参数类型。</typeparam>
        /// <typeparam name="T6">第六个参数类型。</typeparam>
        /// <typeparam name="T7">第七个参数类型。</typeparam>
        /// <typeparam name="T8">第八个参数类型。</typeparam>
        /// <typeparam name="T9">第九个参数类型。</typeparam>
        /// <typeparam name="T10">第十个参数类型。</typeparam>
        /// <typeparam name="T11">第十一个参数类型。</typeparam>
        /// <typeparam name="T12">第十二个参数类型。</typeparam>
        /// <param name="method">带十二个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <param name="arg4">方法的第四个参数。</param>
        /// <param name="arg5">方法的第五个参数。</param>
        /// <param name="arg6">方法的第六个参数。</param>
        /// <param name="arg7">方法的第七个参数。</param>
        /// <param name="arg8">方法的第八个参数。</param>
        /// <param name="arg9">方法的第九个参数。</param>
        /// <param name="arg10">方法的第十个参数。</param>
        /// <param name="arg11">方法的第十一个参数。</param>
        /// <param name="arg12">方法的第十二个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            arglist.Add(arg6);
            arglist.Add(arg7);
            arglist.Add(arg8);
            arglist.Add(arg9);
            arglist.Add(arg10);
            arglist.Add(arg11);
            arglist.Add(arg12);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <typeparam name="T4">第四个参数类型。</typeparam>
        /// <typeparam name="T5">第五个参数类型。</typeparam>
        /// <typeparam name="T6">第六个参数类型。</typeparam>
        /// <typeparam name="T7">第七个参数类型。</typeparam>
        /// <typeparam name="T8">第八个参数类型。</typeparam>
        /// <typeparam name="T9">第九个参数类型。</typeparam>
        /// <typeparam name="T10">第十个参数类型。</typeparam>
        /// <typeparam name="T11">第十一个参数类型。</typeparam>
        /// <typeparam name="T12">第十二个参数类型。</typeparam>
        /// <typeparam name="T13">第十三个参数类型。</typeparam>
        /// <param name="method">带十三个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <param name="arg4">方法的第四个参数。</param>
        /// <param name="arg5">方法的第五个参数。</param>
        /// <param name="arg6">方法的第六个参数。</param>
        /// <param name="arg7">方法的第七个参数。</param>
        /// <param name="arg8">方法的第八个参数。</param>
        /// <param name="arg9">方法的第九个参数。</param>
        /// <param name="arg10">方法的第十个参数。</param>
        /// <param name="arg11">方法的第十一个参数。</param>
        /// <param name="arg12">方法的第十二个参数。</param>
        /// <param name="arg13">方法的第十三个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            arglist.Add(arg6);
            arglist.Add(arg7);
            arglist.Add(arg8);
            arglist.Add(arg9);
            arglist.Add(arg10);
            arglist.Add(arg11);
            arglist.Add(arg12);
            arglist.Add(arg13);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <typeparam name="T4">第四个参数类型。</typeparam>
        /// <typeparam name="T5">第五个参数类型。</typeparam>
        /// <typeparam name="T6">第六个参数类型。</typeparam>
        /// <typeparam name="T7">第七个参数类型。</typeparam>
        /// <typeparam name="T8">第八个参数类型。</typeparam>
        /// <typeparam name="T9">第九个参数类型。</typeparam>
        /// <typeparam name="T10">第十个参数类型。</typeparam>
        /// <typeparam name="T11">第十一个参数类型。</typeparam>
        /// <typeparam name="T12">第十二个参数类型。</typeparam>
        /// <typeparam name="T13">第十三个参数类型。</typeparam>
        /// <typeparam name="T14">第十四个参数类型。</typeparam>
        /// <param name="method">带十四个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <param name="arg4">方法的第四个参数。</param>
        /// <param name="arg5">方法的第五个参数。</param>
        /// <param name="arg6">方法的第六个参数。</param>
        /// <param name="arg7">方法的第七个参数。</param>
        /// <param name="arg8">方法的第八个参数。</param>
        /// <param name="arg9">方法的第九个参数。</param>
        /// <param name="arg10">方法的第十个参数。</param>
        /// <param name="arg11">方法的第十一个参数。</param>
        /// <param name="arg12">方法的第十二个参数。</param>
        /// <param name="arg13">方法的第十三个参数。</param>
        /// <param name="arg14">方法的第十四个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            arglist.Add(arg6);
            arglist.Add(arg7);
            arglist.Add(arg8);
            arglist.Add(arg9);
            arglist.Add(arg10);
            arglist.Add(arg11);
            arglist.Add(arg12);
            arglist.Add(arg13);
            arglist.Add(arg14);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <typeparam name="T4">第四个参数类型。</typeparam>
        /// <typeparam name="T5">第五个参数类型。</typeparam>
        /// <typeparam name="T6">第六个参数类型。</typeparam>
        /// <typeparam name="T7">第七个参数类型。</typeparam>
        /// <typeparam name="T8">第八个参数类型。</typeparam>
        /// <typeparam name="T9">第九个参数类型。</typeparam>
        /// <typeparam name="T10">第十个参数类型。</typeparam>
        /// <typeparam name="T11">第十一个参数类型。</typeparam>
        /// <typeparam name="T12">第十二个参数类型。</typeparam>
        /// <typeparam name="T13">第十三个参数类型。</typeparam>
        /// <typeparam name="T14">第十四个参数类型。</typeparam>
        /// <typeparam name="T15">第十五个参数类型。</typeparam>
        /// <param name="method">带十五个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <param name="arg4">方法的第四个参数。</param>
        /// <param name="arg5">方法的第五个参数。</param>
        /// <param name="arg6">方法的第六个参数。</param>
        /// <param name="arg7">方法的第七个参数。</param>
        /// <param name="arg8">方法的第八个参数。</param>
        /// <param name="arg9">方法的第九个参数。</param>
        /// <param name="arg10">方法的第十个参数。</param>
        /// <param name="arg11">方法的第十一个参数。</param>
        /// <param name="arg12">方法的第十二个参数。</param>
        /// <param name="arg13">方法的第十三个参数。</param>
        /// <param name="arg14">方法的第十四个参数。</param>
        /// <param name="arg15">方法的第十五个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            arglist.Add(arg6);
            arglist.Add(arg7);
            arglist.Add(arg8);
            arglist.Add(arg9);
            arglist.Add(arg10);
            arglist.Add(arg11);
            arglist.Add(arg12);
            arglist.Add(arg13);
            arglist.Add(arg14);
            arglist.Add(arg15);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        /// <summary>
        /// 异步执行一个没有返回值的方法。
        /// </summary>
        /// <typeparam name="T1">第一个参数类型。</typeparam>
        /// <typeparam name="T2">第二个参数类型。</typeparam>
        /// <typeparam name="T3">第三个参数类型。</typeparam>
        /// <typeparam name="T4">第四个参数类型。</typeparam>
        /// <typeparam name="T5">第五个参数类型。</typeparam>
        /// <typeparam name="T6">第六个参数类型。</typeparam>
        /// <typeparam name="T7">第七个参数类型。</typeparam>
        /// <typeparam name="T8">第八个参数类型。</typeparam>
        /// <typeparam name="T9">第九个参数类型。</typeparam>
        /// <typeparam name="T10">第十个参数类型。</typeparam>
        /// <typeparam name="T11">第十一个参数类型。</typeparam>
        /// <typeparam name="T12">第十二个参数类型。</typeparam>
        /// <typeparam name="T13">第十三个参数类型。</typeparam>
        /// <typeparam name="T14">第十四个参数类型。</typeparam>
        /// <typeparam name="T15">第十五个参数类型。</typeparam>
        /// <typeparam name="T16">第十六个参数类型。</typeparam>
        /// <param name="method">第十六个参数的方法。</param>
        /// <param name="arg1">方法的第一个参数。</param>
        /// <param name="arg2">方法的第二个参数。</param>
        /// <param name="arg3">方法的第三个参数。</param>
        /// <param name="arg4">方法的第四个参数。</param>
        /// <param name="arg5">方法的第五个参数。</param>
        /// <param name="arg6">方法的第六个参数。</param>
        /// <param name="arg7">方法的第七个参数。</param>
        /// <param name="arg8">方法的第八个参数。</param>
        /// <param name="arg9">方法的第九个参数。</param>
        /// <param name="arg10">方法的第十个参数。</param>
        /// <param name="arg11">方法的第十一个参数。</param>
        /// <param name="arg12">方法的第十二个参数。</param>
        /// <param name="arg13">方法的第十三个参数。</param>
        /// <param name="arg14">方法的第十四个参数。</param>
        /// <param name="arg15">方法的第十五个参数。</param>
        /// <param name="arg16">方法的第十六个参数。</param>
        /// <returns>线程帮助类返回结果。</returns>
        /// <exception cref="System.ArgumentNullException"><c>method</c> 为 null。</exception>
        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method 不能为空。");
            }
            ThreadHelperResult result = new ThreadHelperResult()
            {
                HasFinish = false
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            arglist.Add(arg6);
            arglist.Add(arg7);
            arglist.Add(arg8);
            arglist.Add(arg9);
            arglist.Add(arg10);
            arglist.Add(arg11);
            arglist.Add(arg12);
            arglist.Add(arg13);
            arglist.Add(arg14);
            arglist.Add(arg15);
            arglist.Add(arg16);
            Thread t = new Thread(ThreadHelperProcess.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage()
            {
                Method = method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }
    }
}
