using System.Reflection;

namespace Common.Threading
{
    internal class ThreadHelperPackage<TResult>
    {
        public ThreadHelperResult<TResult> Result
        {
            get;
            set;
        }

        public MethodInfo Method
        {
            get;
            set;
        }

        public object[] Args
        {
            get;
            set;
        }
    }
}