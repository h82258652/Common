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