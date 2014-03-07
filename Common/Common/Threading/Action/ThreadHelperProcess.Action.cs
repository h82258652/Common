
namespace Common.Threading
{
    internal class ThreadHelperProcess
    {
        public static void Process(object obj)
        {
            ThreadHelperPackage package = (ThreadHelperPackage)obj;
            package.Method.Invoke(null, package.Args);
            package.Result.HasFinish = true;
        }
    }
}