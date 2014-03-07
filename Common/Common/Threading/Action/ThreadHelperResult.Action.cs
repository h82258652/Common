
namespace Common.Threading
{
    public class ThreadHelperResult
    {
        internal ThreadHelperResult()
        {
            HasFinish = false;
        }

        /// <summary>
        /// 指示方法是否结束
        /// </summary>
        public bool HasFinish
        {
            get;
            internal set;
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