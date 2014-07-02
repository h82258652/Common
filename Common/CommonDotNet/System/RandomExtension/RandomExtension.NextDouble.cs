
namespace System
{
    public partial class RandomExtension
    {
        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 System.Double.MaxValue 的双精度浮点数。</returns>
        public override double NextDouble()
        {
            return Sample() * double.MaxValue;
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的双精度浮点数。</returns>
        public double NextDouble(bool containNegative)
        {
            if (containNegative)
            {
                var negative = NextBoolean() ? 1.0 : -1.0;
                return NextDouble() * negative;
            }
            else
            {
                return NextDouble();
            }
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的双精度浮点数，即：返回值的范围通常包括零但不包括 maxValue。不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public double NextDouble(double maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue", "maxValue 必须大于或等于零。");
            }
            return Sample() * maxValue;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的双精度浮点数，即：返回的值范围包括 minValue 但不包括 maxValue。如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>minValue</c> 大于 <c>maxValue</c>。</exception>
        public double NextDouble(double minValue, double maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue", "“minValue”不能大于 maxValue。");
            }
            var mid = maxValue / 2 + minValue / 2;
            var leftOrRight = NextBoolean();
            if (leftOrRight)
            {
                var range = mid - minValue;
                return minValue + Sample() * range;
            }
            else
            {
                var range = maxValue - mid;
                return mid + Sample() * range;
            }
        }
    }
}
