using System.Reflection;

namespace Common.Threading
{
    internal class ThreadHelperPackage
    {
        public ThreadHelperResult Result
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