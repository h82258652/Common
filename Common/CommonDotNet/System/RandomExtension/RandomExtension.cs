
namespace System
{
    /// <summary>
    /// Random 扩展类。
    /// </summary>
    public partial class RandomExtension : Random
    {
        /// <summary>
        /// 使用与时间相关的默认种子值，初始化 System.RandomExtension 类的新实例。
        /// </summary>
        public RandomExtension()
        {
        }

        /// <summary>
        /// 使用指定的种子值初始化 System.RandomExtension 类的新实例。
        /// </summary>
        /// <param name="seed">用来计算伪随机数序列起始值的数字。 如果指定的是负数，则使用其绝对值。</param>
        public RandomExtension(int seed)
            : base(seed)
        {
        }
    }
}
