
namespace Common.Threading
{
    /// <summary>
    /// 线程帮助类返回结果。
    /// </summary>
    /// <typeparam name="TResult">返回值类型。</typeparam>
    public class ThreadHelperResult<TResult>
    {
        private bool _hasFinish;

        /// <summary>
        /// 异步方法执行完成时触发该事件。
        /// </summary>
        public event ThreadHelperFinishedHandler Finished;

        /// <summary>
        /// 指定异步方法执行完成时的方法。
        /// </summary>
        /// <param name="sender">触发该事件的源头。</param>
        /// <param name="e">异步方法完成的事件。</param>
        public delegate void ThreadHelperFinishedHandler(object sender, ThreadHelperFinishedEventArgs<TResult> e);

        /// <summary>
        /// 指示方法是否结束。
        /// </summary>
        public bool HasFinish
        {
            get
            {
                return _hasFinish;
            }
            internal set
            {
                if (value == true)
                {
                    if (Finished != null)
                    {
                        Finished(this, new ThreadHelperFinishedEventArgs<TResult>(Value));
                    }
                }
                _hasFinish = value;
            }
        }

        /// <summary>
        /// 获取方法的返回值。
        /// </summary>
        public TResult Value
        {
            get;
            internal set;
        }

        /// <summary>
        /// 等待并获取方法的返回值。
        /// </summary>
        public TResult WaitForValue
        {
            get
            {
                while (true)
                {
                    if (HasFinish == true)
                    {
                        return Value;
                    }
                }
            }
        }

        internal ThreadHelperResult()
        {
            HasFinish = false;
            Value = default(TResult);
        }
    }
}
