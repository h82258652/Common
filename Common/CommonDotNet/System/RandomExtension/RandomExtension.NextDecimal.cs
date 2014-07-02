
namespace System
{
    public partial class RandomExtension
    {
        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>返回一个非负随机的 Decimal。</returns>
        public decimal NextDecimal()
        {
            return NextDecimal(false);
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 Decimal。</returns>
        public decimal NextDecimal(bool containNegative)
        {
            var buffer = new byte[4];
            // 96 位整数的低 32 位。
            NextBytes(buffer);
            var lo = BitConverter.ToInt32(buffer, 0);
            // 96 位整数的中间 32 位。
            NextBytes(buffer);
            var mid = BitConverter.ToInt32(buffer, 0);
            // 96 位整数的高 32 位。
            NextBytes(buffer);
            var hi = BitConverter.ToInt32(buffer, 0);
            // 正或负。
            var isNegative = containNegative && Next(2) == 0;
            // 10 的指数（0 到 28 之间）。
            var scale = (byte)Next(29);
            return new decimal(lo, mid, hi, isNegative, scale);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限制）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 Decimal，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public decimal NextDecimal(decimal maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue 必须大于或等于零。");
            }
            return NextDecimal(0, maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 Decimal，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public decimal NextDecimal(decimal minValue, decimal maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            if (minValue == maxValue)
            {
                return minValue;
            }
            var mid = maxValue / 2 + minValue / 2;
            var leftOrRight = NextBoolean();
            if (leftOrRight)
            {
                var range = mid - minValue;
                return minValue + ((decimal)Sample()) * range;
            }
            else
            {
                var range = maxValue - mid;
                return mid + ((decimal)Sample()) * range;
            }
        }
    }
}
