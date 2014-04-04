
namespace Common.Threading
{
    internal class ThreadHelperProcess
    {
        internal static void Process(object obj)
        {
            ThreadHelperPackage package = (ThreadHelperPackage)obj;
            package.Method.DynamicInvoke(package.Args);
            package.Result.HasFinish = true;
        }
    }
}
