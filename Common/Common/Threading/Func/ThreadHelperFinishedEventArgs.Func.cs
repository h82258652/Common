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
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ThreadHelperFinishedEventArgs(TResult value)
        {
            this.Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public TResult Value
        {
            get;
            internal set;
        }
    }
}
