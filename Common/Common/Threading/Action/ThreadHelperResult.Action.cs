
namespace Common.Threading
{
    public class ThreadHelperResult
    {
        internal ThreadHelperResult()
        {
            HasFinish = false;
        }

        public bool HasFinish
        {
            get;
            internal set;
        }

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