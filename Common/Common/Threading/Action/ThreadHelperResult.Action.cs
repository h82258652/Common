using System;

namespace Common.Threading
{
    /// <summary>
    /// 线程帮助类返回的结果。
    /// </summary>
    public class ThreadHelperResult
    {
        private bool _hasFinish;

        /// <summary>
        /// 异步方法执行完成时触发该事件。
        /// </summary>
        public event EventHandler Finished;

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
                        Finished(this, EventArgs.Empty);
                    }
                }
                _hasFinish = value;
            }
        }

        /// <summary>
        /// 等待方法结束。
        /// </summary>
        /// <returns>当前实例。</returns>
        public ThreadHelperResult WaitForFinish()
        {
            while (true)
            {
                if (HasFinish == true)
                {
                    return this;
                }
            }
        }

        internal ThreadHelperResult()
        {
            HasFinish = false;
        }
    }
}
