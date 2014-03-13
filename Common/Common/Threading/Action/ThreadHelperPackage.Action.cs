using System;
using System.Reflection;

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
