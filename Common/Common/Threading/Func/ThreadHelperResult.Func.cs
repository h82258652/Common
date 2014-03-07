
namespace Common.Threading
{
    public class ThreadHelperResult<TResult>
    {
        internal ThreadHelperResult()
        {
            HasFinish = false;
            Value = default(TResult);
        }

        public bool HasFinish
        {
            get;
            internal set;
        }

        public TResult Value
        {
            get;
            internal set;
        }

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