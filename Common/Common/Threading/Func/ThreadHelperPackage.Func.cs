using System.Reflection;

namespace Common.Threading
{
    internal class ThreadHelperPackage<TResult>
    {
        internal ThreadHelperResult<TResult> Result
        {
            get;
            set;
        }

        internal MethodInfo Method
        {
            get;
            set;
        }

        internal object[] Args
        {
            get;
            set;
        }
    }
}