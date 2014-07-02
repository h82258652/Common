
namespace System
{
    public partial class RandomExtension
    {
        /// <summary>
        /// 返回随机真假。
        /// </summary>
        /// <returns>真或假。</returns>
        public bool NextBoolean()
        {
            return Next(2) == 0;
        }
    }
}
