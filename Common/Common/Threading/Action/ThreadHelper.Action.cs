using System;
using System.Collections;
using System.Threading;

namespace Common.Threading
{
    public static partial class ThreadHelper
    {
        public static ThreadHelperResult StartAction(Action method)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1>(Action<T1> method, T1 arg1)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2>(Action<T1, T2> method, T1 arg1, T2 arg2)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3>(Action<T1, T2, T3> method, T1 arg1, T2 arg2, T3 arg3)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }

        public static ThreadHelperResult StartAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
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
                Method = method.Method,
                Args = arglist.ToArray(),
                Result = result
            });
            return result;
        }
    }
}