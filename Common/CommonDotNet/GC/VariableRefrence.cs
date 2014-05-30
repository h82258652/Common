using System;
using System.Threading;

namespace Common.GC
{
    /// <summary>
    /// 变量引用类。
    /// </summary>
    public class VariableRefrence
    {
        private static void ListenThread(object obj)
        {
            var tuple = obj as Tuple<WeakReference, Action>;
            if (tuple == null)
            {
                return;
            }
            WeakReference wk = tuple.Item1;
            Action action = tuple.Item2;
            if (wk == null || action == null)
            {
                return;
            }
            while (true)
            {
                if (wk.IsAlive == false)
                {
                    action();
                    break;
                }
            }
        }

        /// <summary>
        /// 监听对象被 GC 回收。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="obj">监听的对象。</param>
        /// <param name="action">当对象被 GC 回收完成时执行的方法。</param>
        public static void Listen<T>(T obj, Action action)
        {
            if (obj.GetType().IsValueType == false && object.Equals(obj, default(T)) == true)
            {
                // 引用类型，且值为 null。
                return;
            }
            else
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(ListenThread), Tuple.Create(new WeakReference(obj), action));
            }
        }
    }
}
