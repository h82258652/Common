
using System;
namespace Common.Threading
{
    public class ThreadHelperResult
    {
        private bool hasFinish;

        internal ThreadHelperResult()
        {
            HasFinish = false;
        }

        public event EventHandler Finished;

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
                        Finished(this, EventArgs.Empty);
                    }
                }
                hasFinish = value;
            }
        }

        /// <summary>
        /// 等待方法结束
        /// </summary>
        /// <returns></returns>
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
    }
}