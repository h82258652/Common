using System;

namespace Common.Threading
{
    internal class ThreadHelperPackage<TResult>
    {
        internal ThreadHelperResult<TResult> Result
        {
            get;
            set;
        }

        internal Delegate Method
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
