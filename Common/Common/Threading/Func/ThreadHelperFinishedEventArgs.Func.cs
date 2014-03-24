using System;

namespace Common.Threading
{
    /// <summary>
    /// 线程帮助类执行完成事件。
    /// </summary>
    /// <typeparam name="TResult">异步执行方法的返回值类型。</typeparam>
    public class ThreadHelperFinishedEventArgs<TResult> : EventArgs
    {
        /// <summary>
        /// 创建一个 ThreadHelperFinishedEventArgs 的新实例。
        /// </summary>
        /// <param name="value">异步方法的返回值。</param>
        public ThreadHelperFinishedEventArgs(TResult value)
        {
            this.Value = value;
        }

        /// <summary>
        /// 异步方法的返回值。
        /// </summary>
        public TResult Value
        {
            get;
            internal set;
        }
    }
}
