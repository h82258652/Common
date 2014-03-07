
namespace Common.Threading
{
    public class ThreadHelperResult<TResult>
    {
        internal ThreadHelperResult()
        {
            HasFinish = false;
            Value = default(TResult);
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