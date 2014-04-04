using System.Text;

namespace System
{
    /// <summary>
    /// 伪随机数扩展类。
    /// </summary>
    public static partial class RandomExtension
    {
        private static readonly Random _rand;

        static RandomExtension()
        {
            _rand = new Random();
        }

        /// <summary>
        /// 返回随机真假。
        /// </summary>
        /// <returns>真或假。</returns>
        public static bool NextBool()
        {
            return _rand.Next(2) == 0;
        }

        /// <summary>
        /// 返回随机字节。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的无符号 8 位整数。</returns>
        public static byte NextByte()
        {
            byte[] buffer = new byte[1];
            _rand.NextBytes(buffer);
            return buffer[0];
        }

        /// <summary>
        /// 返回一个小于所指定最大值的字节。
        /// </summary>
        /// <param name="maxValue">要生成的随机字节的上限（随机字节不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于且小于 maxValue 的无符号 8 位整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static byte NextByte(byte maxValue)
        {
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue 必须大于或等于零。");
            }
            return (byte)_rand.Next(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机字节。
        /// </summary>
        /// <param name="minValue">返回的随机字节的下界（随机字节可取该下界值）。</param>
        /// <param name="maxValue">返回的随机字节的上界（随机字节不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的无符号 8 位整数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 <c>minValue</c>。</exception>
        public static byte NextByte(byte minValue, byte maxValue)
        {
            return (byte)_rand.Next(minValue, maxValue);
        }

        /// <summary>
        /// 用随机数填充指定字节数组的元素。
        /// </summary>
        /// <param name="buffer">包含随机数的字节数组。</param>
        /// <exception cref="System.ArgumentNullException"><c>buffer</c> 为 null。</exception>
        public static void NextBytes(byte[] buffer)
        {
            _rand.NextBytes(buffer);
        }

        /// <summary>
        /// 用随机数填充指定长度的字节数组。
        /// </summary>
        /// <param name="length">字节数组长度。</param>
        /// <returns>包含随机数的字节数组。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>length</c> 小于或等于 0。</exception>
        public static byte[] NextBytes(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException("length 不能小于或等于零。");
            }
            byte[] buffer = new byte[length];
            _rand.NextBytes(buffer);
            return buffer;
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 Decimal。</returns>
        public static decimal NextDecimal(bool containNegative = false)
        {
            byte[] buffer = new byte[4];
            _rand.NextBytes(buffer);
            int lo = BitConverter.ToInt32(buffer, 0);// 96 位整数的低 32 位。
            _rand.NextBytes(buffer);
            int mid = BitConverter.ToInt32(buffer, 0);// 96 位整数的中间 32 位。
            _rand.NextBytes(buffer);
            int hi = BitConverter.ToInt32(buffer, 0);// 96 位整数的高 32 位。
            bool isNegative = containNegative == false ? false : _rand.Next(2) == 0;// 正或负
            byte scale = (byte)_rand.Next(29);// 10 的指数（0 到 28 之间）。
            return new decimal(lo, mid, hi, isNegative, scale);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 Decimal，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static decimal NextDecimal(decimal maxValue)
        {
            if (maxValue == 0)
            {
                return maxValue;
            }
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("“maxValue”必须大于 0。", "maxValue");
            }
            decimal d;
            byte[] buffer = new byte[4];
            do
            {
                _rand.NextBytes(buffer);
                int lo = BitConverter.ToInt32(buffer, 0);// 96 位整数的低 32 位。
                _rand.NextBytes(buffer);
                int mid = BitConverter.ToInt32(buffer, 0);// 96 位整数的中间 32 位。
                _rand.NextBytes(buffer);
                int hi = BitConverter.ToInt32(buffer, 0);// 96 位整数的高 32 位。
                byte scale = (byte)_rand.Next(29);// 10 的指数（0 到 28 之间）。
                d = new decimal(lo, mid, hi, false, scale);
            } while ((d < maxValue) == false);
            return d;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 Decimal，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 <c>minValue</c>。</exception>
        public static decimal NextDecimal(decimal minValue, decimal maxValue)
        {
            if (minValue == maxValue)
            {
                return minValue;
            }
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("“minValue”不能大于 maxValue。", "minValue");
            }
            decimal d;
            byte[] buffer = new byte[4];
            do
            {
                _rand.NextBytes(buffer);
                int lo = BitConverter.ToInt32(buffer, 0);// 96 位整数的低 32 位。
                _rand.NextBytes(buffer);
                int mid = BitConverter.ToInt32(buffer, 0);// 96 位整数的中间 32 位。
                _rand.NextBytes(buffer);
                int hi = BitConverter.ToInt32(buffer, 0);// 96 位整数的高 32 位。
                bool isNegative = _rand.Next(2) == 0;// 正或负
                byte scale = (byte)_rand.Next(29);// 10 的指数（0 到 28 之间）。
                d = new decimal(lo, mid, hi, isNegative, scale);
            } while ((d >= minValue && d < maxValue) == false);
            return d;
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的双精度浮点数。</returns>
        public static double NextDouble(bool containNegative = false)
        {
            double d;
            byte[] buffer = new byte[8];
            if (containNegative == true)
            {
                do
                {
                    _rand.NextBytes(buffer);
                    d = BitConverter.ToDouble(buffer, 0);
                } while ((d >= double.MinValue && d < double.MaxValue) == false);
                return d;
            }
            else
            {
                do
                {
                    _rand.NextBytes(buffer);
                    d = BitConverter.ToDouble(buffer, 0);
                } while ((d >= 0 && d < double.MaxValue) == false);
                return d;
            }
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的双精度浮点数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static double NextDouble(double maxValue)
        {
            if (maxValue == 0)
            {
                return maxValue;
            }
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("“maxValue”必须大于 0。", "maxValue");
            }
            double d;
            byte[] buffer = new byte[8];
            do
            {
                _rand.NextBytes(buffer);
                d = BitConverter.ToDouble(buffer, 0);
            } while ((d >= 0 && d < maxValue) == false);
            return d;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的双精度浮点数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 <c>minValue</c>。</exception>
        public static double NextDouble(double minValue, double maxValue)
        {
            if (minValue == maxValue)
            {
                return minValue;
            }
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("“minValue”不能大于 maxValue。", "minValue");
            }
            double d;
            byte[] buffer = new byte[8];
            do
            {
                _rand.NextBytes(buffer);
                d = BitConverter.ToDouble(buffer, 0);
            } while ((d >= minValue && d < maxValue) == false);
            return d;
        }

        /// <summary>
        /// 返回枚举类型中随机一个枚举值。
        /// </summary>
        /// <typeparam name="T">可枚举类型。</typeparam>
        /// <returns>返回其中一个枚举。</returns>
        /// <exception cref="System.InvalidOperationException"><c>T</c> 不是枚举类型。</exception>
        public static T NextEnum<T>()
        {
            return (T)NextEnum(typeof(T));
        }

        /// <summary>
        /// 返回枚举类型中随机一个枚举值。
        /// </summary>
        /// <param name="type">可枚举类型</param>
        /// <returns>返回其中一个枚举值。</returns>
        /// <exception cref="System.ArgumentNullException"><c>type</c> 为 null。</exception>
        /// <exception cref="System.InvalidOperationException"><c>type</c> 不是枚举类型。</exception>
        public static object NextEnum(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type 不能为空。");
            }
            if (type.IsEnum == false)
            {
                throw new InvalidOperationException(type.Name + "不可枚举");
            }
            var array = Enum.GetValues(type);
            var index = _rand.Next(array.GetLowerBound(0), array.GetLowerBound(0) + 1);
            return array.GetValue(index);
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的单精度浮点数。</returns>
        public static float NextFloat(bool containNegative = false)
        {
            float f;
            byte[] buffer = new byte[4];
            if (containNegative == true)
            {
                do
                {
                    _rand.NextBytes(buffer);
                    f = BitConverter.ToSingle(buffer, 0);
                } while ((f >= float.MinValue && f < float.MaxValue) == false);
                return f;
            }
            else
            {
                do
                {
                    _rand.NextBytes(buffer);
                    f = BitConverter.ToSingle(buffer, 0);
                } while ((f >= 0 && f < float.MaxValue) == false);
                return f;
            }
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的单精度浮点数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static float NextFloat(float maxValue)
        {
            if (maxValue == 0)
            {
                return maxValue;
            }
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("“maxValue”必须大于 0。", "maxValue");
            }
            float f;
            byte[] buffer = new byte[4];
            do
            {
                _rand.NextBytes(buffer);
                f = BitConverter.ToSingle(buffer, 0);
            } while ((f >= 0 && f < maxValue) == false);
            return f;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的单精度浮点数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 <c>minValue</c>。</exception>
        public static float NextFloat(float minValue, float maxValue)
        {
            if (minValue == maxValue)
            {
                return minValue;
            }
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("“minValue”不能大于 maxValue。", "minValue");
            }
            float f;
            byte[] buffer = new byte[4];
            do
            {
                _rand.NextBytes(buffer);
                f = BitConverter.ToSingle(buffer, 0);
            } while ((f >= minValue && f < maxValue) == false);
            return f;
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 32 位带符号整数。</returns>
        public static int NextInt(bool containNegative = false)
        {
            if (containNegative == true)
            {
                return _rand.Next(int.MinValue, int.MaxValue);
            }
            else
            {
                return _rand.Next();
            }
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 32 位带符号整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static int NextInt(int maxValue)
        {
            return _rand.Next(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 32 位带符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 <c>minValue</c>。</exception>
        public static int NextInt(int minValue, int maxValue)
        {
            return _rand.Next(minValue, maxValue);
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 64 位带符号整数。</returns>
        public static long NextLong(bool containNegative = false)
        {
            if (containNegative == true)
            {
                byte[] buffer = new byte[8];
                _rand.NextBytes(buffer);
                return BitConverter.ToInt64(buffer, 0);
            }
            else
            {
                long l;
                byte[] buffer = new byte[8];
                do
                {
                    _rand.NextBytes(buffer);
                    l = BitConverter.ToInt64(buffer, 0);
                } while ((l >= 0 && l < long.MaxValue) == false);
                return l;
            }
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 64 位带符号整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static long NextLong(long maxValue)
        {
            if (maxValue == 0)
            {
                return maxValue;
            }
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("“maxValue”必须大于 0。", "maxValue");
            }
            long l;
            byte[] buffer = new byte[8];
            do
            {
                _rand.NextBytes(buffer);
                l = BitConverter.ToInt64(buffer, 0);
            } while ((l >= 0 && l < maxValue) == false);
            return l;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 64 位带符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 <c>minValue</c>。</exception>
        public static long NextLong(long minValue, long maxValue)
        {
            if (minValue == maxValue)
            {
                return minValue;
            }
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("“minValue”不能大于 maxValue。", "minValue");
            }
            long l;
            byte[] buffer = new byte[8];
            do
            {
                _rand.NextBytes(buffer);
                l = BitConverter.ToInt64(buffer, 0);
            } while ((l >= minValue && l < maxValue) == false);
            return l;
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 SByte。</returns>
        public static sbyte NextSByte(bool containNegative = false)
        {
            if (containNegative == true)
            {
                return (sbyte)_rand.Next(sbyte.MinValue, sbyte.MaxValue);
            }
            else
            {
                return (sbyte)_rand.Next(0, sbyte.MaxValue);
            }
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 SByte，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static sbyte NextSByte(sbyte maxValue)
        {
            return (sbyte)_rand.Next(0, maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 SByte，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 <c>minValue</c>。</exception>
        public static sbyte NextSByte(sbyte minValue, sbyte maxValue)
        {
            return (sbyte)_rand.Next(minValue, maxValue);
        }

        /// <summary>
        /// 返回随机数。
        /// </summary>
        /// <param name="containNegative">是否包含负数。</param>
        /// <returns>返回一个随机的 16 位带符号整数。</returns>
        public static short NextShort(bool containNegative = false)
        {
            if (containNegative == true)
            {
                return (short)_rand.Next(short.MinValue, short.MaxValue);
            }
            else
            {
                return (short)_rand.Next(short.MaxValue);
            }
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 16 位带符号整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static short NextShort(short maxValue)
        {
            return (short)_rand.Next(maxValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 16 位带符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 <c>minValue</c>。</exception>
        public static short NextShort(short minValue, short maxValue)
        {
            return (short)_rand.Next(minValue, maxValue);
        }

        /// <summary>
        /// 从字符串数组中随机返回一个字符串。
        /// </summary>
        /// <param name="strs">字符串数组。</param>
        /// <returns>字符串数组中随机一个字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>strs</c> 为 null。</exception>
        public static string NextString(params string[] strs)
        {
            if (strs == null)
            {
                throw new ArgumentNullException("strs 不能为空。");
            }
            return strs[_rand.Next(strs.Length)];
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 32 位无符号整数。</returns>
        public static uint NextUInt()
        {
            return (uint)_rand.Next(int.MinValue, int.MaxValue) - Convert.ToUInt32(int.MinValue);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 32 位无符号整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static uint NextUInt(uint maxValue)
        {
            if (maxValue == 0)
            {
                return maxValue;
            }
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("“maxValue”必须大于 0。", "maxValue");
            }
            return (uint)_rand.Next(int.MinValue, (int)(maxValue + Convert.ToUInt32(int.MinValue))) - Convert.ToUInt32(int.MinValue);
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 32 位无符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 <c>minValue</c>。</exception>
        public static uint NextUInt(uint minValue, uint maxValue)
        {
            if (minValue == maxValue)
            {
                return minValue;
            }
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("“minValue”不能大于 maxValue。", "minValue");
            }
            return (uint)_rand.Next((int)(minValue + Convert.ToUInt32(int.MaxValue)), (int)(maxValue + Convert.ToUInt32(int.MinValue))) - Convert.ToUInt32(int.MinValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 64 位无符号长整数。</returns>
        public static ulong NextULong()
        {
            ulong ul;
            byte[] buffer = new byte[8];
            do
            {
                _rand.NextBytes(buffer);
                ul = BitConverter.ToUInt64(buffer, 0);
            } while ((ul >= 0 && ul < ulong.MaxValue) == false);
            return ul;
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 64 位无符号长整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static ulong NextULong(ulong maxValue)
        {
            if (maxValue == 0)
            {
                return maxValue;
            }
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("“maxValue”必须大于 0。", "maxValue");
            }
            ulong ul;
            byte[] buffer = new byte[8];
            do
            {
                _rand.NextBytes(buffer);
                ul = BitConverter.ToUInt64(buffer, 0);
            } while ((ul >= 0 && ul < maxValue) == false);
            return ul;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 64 位无符号长整数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 <c>minValue</c>。</exception>
        public static ulong NextULong(ulong minValue, ulong maxValue)
        {
            if (minValue == maxValue)
            {
                return minValue;
            }
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("“minValue”不能大于 maxValue。", "minValue");
            }
            ulong ul;
            byte[] buffer = new byte[8];
            do
            {
                _rand.NextBytes(buffer);
                ul = BitConverter.ToUInt64(buffer, 0);
            } while ((ul >= minValue && ul < maxValue) == false);
            return ul;
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 16 位无符号长整数。</returns>
        public static ushort NextUShort()
        {
            ushort us;
            byte[] buffer = new byte[2];
            do
            {
                _rand.NextBytes(buffer);
                us = BitConverter.ToUInt16(buffer, 0);
            } while ((us >= 0 && us < ushort.MaxValue) == false);
            return us;
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 16 位无符号长整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 0。</exception>
        public static ushort NextUShort(ushort maxValue)
        {
            if (maxValue == 0)
            {
                return maxValue;
            }
            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("“maxValue”必须大于 0。", "maxValue");
            }
            ushort us;
            byte[] buffer = new byte[2];
            do
            {
                _rand.NextBytes(buffer);
                us = BitConverter.ToUInt16(buffer, 0);
            } while ((us >= 0 && us < maxValue) == false);
            return us;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 16 位无符号长整数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>maxValue</c> 小于 <c>minValue</c>。</exception>
        public static ushort NextUShort(ushort minValue, ushort maxValue)
        {
            if (minValue == maxValue)
            {
                return minValue;
            }
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("“minValue”不能大于 maxValue。", "minValue");
            }
            ushort us;
            byte[] buffer = new byte[2];
            do
            {
                _rand.NextBytes(buffer);
                us = BitConverter.ToUInt16(buffer, 0);
            } while ((us >= minValue && us < maxValue) == false);
            return us;
        }

        /// <summary>
        /// 返回一个随机汉字。
        /// </summary>
        /// <returns>一个随机汉字。</returns>
        public static char NextChinese()
        {
            Encoding gb2312 = Encoding.GetEncoding("gb2312");

            int r1 = _rand.Next(11, 14);
            int r2;
            if (r1 == 13)
            {
                r2 = _rand.Next(0, 7);
            }
            else
            {
                r2 = _rand.Next(0, 16);
            }
            int r3 = _rand.Next(10, 16);
            int r4;
            if (r3 == 10)
            {
                r4 = _rand.Next(1, 16);
            }
            else if (r3 == 15)
            {
                r4 = _rand.Next(0, 15);
            }
            else
            {
                r4 = _rand.Next(0, 16);
            }

            string sr1 = r1.ToString("x");
            string sr2 = r2.ToString("x");
            string sr3 = r3.ToString("x");
            string sr4 = r4.ToString("x");

            byte b1 = Convert.ToByte(sr1 + sr2, 16);
            byte b2 = Convert.ToByte(sr3 + sr4, 16);

            return gb2312.GetString(new byte[] { b1, b2 }, 0, 2)[0];
        }


        /// <summary>
        /// 返回指定个数的随机汉字。
        /// </summary>
        /// <param name="length">随机汉字的个数。</param>
        /// <returns>指定个数的随机汉字。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"><c>length</c> 小于或等于 0。</exception>
        public static string NextChinese(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException("length 不能小于等于0。");
            }
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sb.Append(NextChinese());
            }
            return sb.ToString();
        }
    }
}
