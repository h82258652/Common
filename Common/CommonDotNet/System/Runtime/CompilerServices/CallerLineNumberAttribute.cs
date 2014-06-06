
namespace System.Runtime.CompilerServices
{
#if Net40
    /// <summary>
    /// 允许您获取调用了方法的源文件的行号。（需在 Visual Studio 2012 以上使用。）
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public sealed class CallerLineNumberAttribute : Attribute
    {
    }
#endif
}
