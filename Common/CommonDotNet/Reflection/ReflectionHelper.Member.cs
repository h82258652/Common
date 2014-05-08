using System.Diagnostics;

namespace Common.Reflection
{
    public static partial class ReflectionHelper
    {
        /// <summary>
        /// 获取调用当前上下文的成员的名字。
        /// </summary>
        /// <returns>成员名字。</returns>
        public static string GetCallerMemberName()
        {
            string name = new StackTrace(true).GetFrame(2).GetMethod().Name;
            if (name.StartsWith("get_") == true)
            {
                return name.Substring("get_".Length);
            }
            if (name.StartsWith("set_") == true)
            {
                return name.Substring("set_".Length);
            }
            return name;
        }

        /// <summary>
        /// 获取正在调用的成员的名字。
        /// </summary>
        /// <returns>成员名字。</returns>
        public static string GetCurrentMemberName()
        {
            string name = new StackTrace(true).GetFrame(1).GetMethod().Name;
            if (name.StartsWith("get_") == true)
            {
                return name.Substring("get_".Length);
            }
            if (name.StartsWith("set_") == true)
            {
                return name.Substring("set_".Length);
            }
            return name;
        }
    }
}
