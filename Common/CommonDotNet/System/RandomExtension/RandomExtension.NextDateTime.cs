
namespace System
{
    public partial class RandomExtension
    {
        /// <summary>
        /// 返回随机时间。
        /// </summary>
        /// <returns>随机时间。</returns>
        public DateTime NextDateTime()
        {
            return NextDateTime(DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// 返回指定时间范围内的随机一个时间。
        /// </summary>
        /// <param name="minValue">起始时间。</param>
        /// <param name="maxValue">结束时间。</param>
        /// <returns>起始时间与结束时间之间的随机一个时间。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public DateTime NextDateTime(DateTime minValue, DateTime maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            if (minValue == maxValue)
            {
                return minValue;
            }
            return new DateTime(NextInt64(minValue.Ticks, maxValue.Ticks));
        }
    }
}
