using System;

namespace Common.Threading
{
    public class ThreadHelperResult<TResult>
    {
        private bool hasFinish;

        internal ThreadHelperResult()
        {
            HasFinish = false;
            Value = default(TResult);
        }

        public event ThreadHelperFinishedHandler Finished;

        public delegate void ThreadHelperFinishedHandler(object sender, ThreadHelperFinishedEventArgs<TResult> e);

        /// <summary>
        /// 指示方法是否结束
        /// </summary>
        public bool HasFinish
        {
            get
            {
                return hasFinish;
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
                hasFinish = value;
            }
        }

        /// <summary>
        /// 获取方法的返回值
        /// </summary>
        public TResult Value
        {
            get;
            internal set;
        }

        /// <summary>
        /// 等待并获取方法的返回值
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
    }
}