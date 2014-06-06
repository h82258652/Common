
namespace Common.Threading
{
    internal class ThreadHelperProcess<TResult>
    {
        private ThreadHelperProcess()
        {
        }

        internal static void Process(object obj)
        {
            ThreadHelperPackage<TResult> package = (ThreadHelperPackage<TResult>)obj;
            package.Result.Value = (TResult)package.Method.DynamicInvoke(package.Args);
            package.Result.HasFinish = true;
        }
    }
}
