using System;
using System.Collections;
using System.Threading;

namespace Common.Threading
{
    public static partial class ThreadHelper
    {
        public static ThreadHelperResult<TResult> StartFunc<TResult>(Func<TResult> method)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
            };
            ArrayList arglist = new ArrayList();
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, TResult>(Func<T1, TResult> method, T1 arg1)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, TResult>(Func<T1, T2, TResult> method, T1 arg1, T2 arg2)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> method, T1 arg1, T2 arg2, T3 arg3)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, T4, T5, T6, TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            arglist.Add(arg6);
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
            };
            ArrayList arglist = new ArrayList();
            arglist.Add(arg1);
            arglist.Add(arg2);
            arglist.Add(arg3);
            arglist.Add(arg4);
            arglist.Add(arg5);
            arglist.Add(arg6);
            arglist.Add(arg7);
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
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
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
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
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
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
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
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
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
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
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
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
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
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
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
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
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult<TResult> StartFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            ThreadHelperResult<TResult> result = new ThreadHelperResult<TResult>()
            {
                HasFinish = false,
                Value = default(TResult)
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
            Thread t = new Thread(ThreadHelperProcess<TResult>.Process)
            {
                IsBackground = true
            };
            t.Start(new ThreadHelperPackage<TResult>()
            {
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }
    }
}