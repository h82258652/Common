using System;

namespace Common.Threading
{
    internal class ThreadHelperPackage
    {
        internal ThreadHelperResult Result
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
