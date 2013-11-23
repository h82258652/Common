using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// 伪随机数扩展类
    /// </summary>
    public static partial class RandomExt
    {
        private static readonly Random _rand;

        static RandomExt()
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
        public static byte NextByte(byte maxValue)
        {
            checked
            {
                return (byte)_rand.Next(maxValue);
            }
        }

        /// <summary>
        /// 返回一个指定范围内的随机字节。
        /// </summary>
        /// <param name="minValue">返回的随机字节的下界（随机字节可取该下界值）。</param>
        /// <param name="maxValue">返回的随机字节的上界（随机字节不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的无符号 8 位整数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
        public static byte NextByte(byte minValue, byte maxValue)
        {
            checked
            {
                return (byte)_rand.Next(minValue, maxValue);
            }
        }

        /// <summary>
        /// 用随机数填充指定字节数组的元素。
        /// </summary>
        /// <param name="buffer">包含随机数的字节数组。</param>
        public static void NextBytes(byte[] buffer)
        {
            _rand.NextBytes(buffer);
        }

        /// <summary>
        /// 用随机数填充指定长度的字节数组。
        /// </summary>
        /// <param name="length">字节数组长度。</param>
        /// <returns>包含随机数的字节数组。</returns>
        public static byte[] NextBytes(int length)
        {
            byte[] buffer = new byte[length];
            _rand.NextBytes(buffer);
            return buffer;
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的Decimal。</returns>
        public static decimal NextDecimal()
        {
            byte[] buffer = new byte[4];
            _rand.NextBytes(buffer);
            int lo = BitConverter.ToInt32(buffer, 0);// 96 位整数的低 32 位。
            _rand.NextBytes(buffer);
            int mid = BitConverter.ToInt32(buffer, 0);// 96 位整数的中间 32 位。
            _rand.NextBytes(buffer);
            int hi = BitConverter.ToInt32(buffer, 0);// 96 位整数的高 32 位。
            byte scale = (byte)_rand.Next(29);// 10 的指数（0 到 28 之间）。
            return new decimal(lo, mid, hi, true, scale);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 Decimal，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
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
            do
            {
                byte[] buffer = new byte[4];
                _rand.NextBytes(buffer);
                int lo = BitConverter.ToInt32(buffer, 0);// 96 位整数的低 32 位。
                _rand.NextBytes(buffer);
                int mid = BitConverter.ToInt32(buffer, 0);// 96 位整数的中间 32 位。
                _rand.NextBytes(buffer);
                int hi = BitConverter.ToInt32(buffer, 0);// 96 位整数的高 32 位。
                byte scale = (byte)_rand.Next(29);// 10 的指数（0 到 28 之间）。
                d = new decimal(lo, mid, hi, true, scale);
            } while (d < maxValue);
            return d;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 Decimal，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
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
            do
            {
                byte[] buffer = new byte[4];
                _rand.NextBytes(buffer);
                int lo = BitConverter.ToInt32(buffer, 0);// 96 位整数的低 32 位。
                _rand.NextBytes(buffer);
                int mid = BitConverter.ToInt32(buffer, 0);// 96 位整数的中间 32 位。
                _rand.NextBytes(buffer);
                int hi = BitConverter.ToInt32(buffer, 0);// 96 位整数的高 32 位。
                bool isNegative = _rand.Next(2) == 0;// 正或负
                byte scale = (byte)_rand.Next(29);// 10 的指数（0 到 28 之间）。
                d = new decimal(lo, mid, hi, isNegative, scale);
            } while (d >= minValue && d < maxValue);
            return d;
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 双精度浮点数。</returns>
        public static double NextDouble()
        {
            double d;
            do
            {
                byte[] buffer = new byte[8];
                _rand.NextBytes(buffer);
                d = BitConverter.ToDouble(buffer, 0);
            } while (d >= 0 && d < double.MaxValue);
            return d;
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的双精度浮点数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
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
            do
            {
                byte[] buffer = new byte[8];
                _rand.NextBytes(buffer);
                d = BitConverter.ToDouble(buffer, 0);
            } while (d >= 0 && d < maxValue);
            return d;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的双精度浮点数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
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
            do
            {
                byte[] buffer = new byte[8];
                _rand.NextBytes(buffer);
                d = BitConverter.ToDouble(buffer, 0);
            } while (d >= minValue && d < maxValue);
            return d;
        }

        /// <summary>
        /// 返回一个枚举。
        /// </summary>
        /// <typeparam name="T">可枚举类型。</typeparam>
        /// <returns>返回其中一个枚举。</returns>
        public static T NextEnum<T>()
        {
            Type type = typeof(T);
            if (type.IsEnum == false)
            {
                throw new InvalidOperationException(type.Name + " 不可枚举");
            }
            var array = Enum.GetValues(type);
            var index = _rand.Next(array.GetLowerBound(0), array.GetLowerBound(0) + 1);
            return (T)array.GetValue(index);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的单精度浮点数。</returns>
        public static float NextFloat()
        {
            float f;
            do
            {
                byte[] buffer = new byte[4];
                _rand.NextBytes(buffer);
                f = BitConverter.ToSingle(buffer, 0);
            } while (f >= 0 && f < float.MaxValue);
            return f;
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的单精度浮点数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
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
            do
            {
                byte[] buffer = new byte[4];
                _rand.NextBytes(buffer);
                f = BitConverter.ToSingle(buffer, 0);
            } while (f >= 0 && f < maxValue);
            return f;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的单精度浮点数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
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
            do
            {
                byte[] buffer = new byte[4];
                _rand.NextBytes(buffer);
                f = BitConverter.ToSingle(buffer, 0);
            } while (f >= minValue && f < maxValue);
            return f;
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 32 位带符号整数。</returns>
        public static int NextInt()
        {
            return _rand.Next();
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 32 位带符号整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
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
        public static int NextInt(int minValue, int maxValue)
        {
            return _rand.Next(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 64 位带符号整数。</returns>
        public static long NextLong()
        {
            long l;
            do
            {
                byte[] buffer = new byte[8];
                _rand.NextBytes(buffer);
                l = BitConverter.ToInt64(buffer, 0);
            } while (l >= 0 && l < long.MaxValue);
            return l;
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 64 位带符号整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
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
            do
            {
                byte[] buffer = new byte[8];
                _rand.NextBytes(buffer);
                l = BitConverter.ToInt64(buffer, 0);
            } while (l >= 0 && l < maxValue);
            return l;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 64 位带符号整数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
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
            do
            {
                byte[] buffer = new byte[8];
                _rand.NextBytes(buffer);
                l = BitConverter.ToInt64(buffer, 0);
            } while (l >= minValue && l < maxValue);
            return l;
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 SByte。</returns>
        public static sbyte NextSByte()
        {
            return (sbyte)_rand.Next(0, sbyte.MaxValue);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 SByte，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
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
        public static sbyte NextSByte(sbyte minValue, sbyte maxValue)
        {
            return (sbyte)_rand.Next(minValue, maxValue);
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 16 位带符号整数。</returns>
        public static short NextShort()
        {
            return (short)_rand.Next(short.MaxValue);
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 16 位带符号整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
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
        public static short NextShort(short minValue, short maxValue)
        {
            return (short)_rand.Next(minValue, maxValue);
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
            do
            {
                byte[] buffer = new byte[8];
                _rand.NextBytes(buffer);
                ul = BitConverter.ToUInt64(buffer, 0);
            } while (ul >= 0 && ul < ulong.MaxValue);
            return ul;
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 64 位无符号长整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
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
            do
            {
                byte[] buffer = new byte[8];
                _rand.NextBytes(buffer);
                ul = BitConverter.ToUInt64(buffer, 0);
            } while (ul >= 0 && ul < maxValue);
            return ul;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 64 位无符号长整数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
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
            do
            {
                byte[] buffer = new byte[8];
                _rand.NextBytes(buffer);
                ul = BitConverter.ToUInt64(buffer, 0);
            } while (ul >= minValue && ul < maxValue);
            return ul;
        }

        /// <summary>
        /// 返回非负随机数。
        /// </summary>
        /// <returns>大于等于零且小于 MaxValue 的 16 位无符号长整数。</returns>
        public static ushort NextUShort()
        {
            ushort us;
            do
            {
                byte[] buffer = new byte[2];
                _rand.NextBytes(buffer);
                us = BitConverter.ToUInt16(buffer, 0);
            } while (us >= 0 && us < ushort.MaxValue);
            return us;
        }

        /// <summary>
        /// 返回一个小于所指定最大值的非负随机数。
        /// </summary>
        /// <param name="maxValue">要生成的随机数的上限（随机数不能取该上限值）。 maxValue 必须大于或等于零。</param>
        /// <returns>大于等于零且小于 maxValue 的 16 位无符号长整数，即：返回值的范围通常包括零但不包括 maxValue。 不过，如果 maxValue 等于零，则返回 maxValue。</returns>
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
            do
            {
                byte[] buffer = new byte[2];
                _rand.NextBytes(buffer);
                us = BitConverter.ToUInt16(buffer, 0);
            } while (us >= 0 && us < maxValue);
            return us;
        }

        /// <summary>
        /// 返回一个指定范围内的随机数。
        /// </summary>
        /// <param name="minValue">返回的随机数的下界（随机数可取该下界值）。</param>
        /// <param name="maxValue">返回的随机数的上界（随机数不能取该上界值）。 maxValue 必须大于或等于 minValue。</param>
        /// <returns>一个大于等于 minValue 且小于 maxValue 的 16 位无符号长整数，即：返回的值范围包括 minValue 但不包括 maxValue。 如果 minValue 等于 maxValue，则返回 minValue。</returns>
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
            do
            {
                byte[] buffer = new byte[2];
                _rand.NextBytes(buffer);
                us = BitConverter.ToUInt16(buffer, 0);
            } while (us >= minValue && us < maxValue);
            return us;
        }
    }
}
