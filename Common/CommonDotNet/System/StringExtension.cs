using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// 字符串扩展类。
    /// </summary>
    public static partial class StringExtension
    {
        /// <summary>
        /// 将当前字符串转换为任意大的带符号整数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的任意大的带符号整数，失败则返回指定的默认值。</returns>
        public static BigInteger AsBigInteger(this string value, BigInteger failureValue)
        {
            BigInteger bigInteger;
            if (BigInteger.TryParse(value, out bigInteger) == true)
            {
                return bigInteger;
            }
            else
            {
                return failureValue;
            }
        }

        /// <summary>
        /// 将当前字符串转换为 8 位无符号整数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的双精度浮点数，失败则返回指定的默认值。</returns>
        public static byte AsByte(this string value, byte failureValue)
        {
            byte b;
            if (byte.TryParse(value, out b) == true)
            {
                return b;
            }
            else
            {
                return failureValue;
            }
        }

        /// <summary>
        /// 将当前字符串转换为十进制数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的十进制数，失败则返回指定的默认值。</returns>
        public static decimal AsDecimal(this string value, decimal failureValue)
        {
            decimal d;
            if (decimal.TryParse(value, out d) == true)
            {
                return d;
            }
            else
            {
                return failureValue;
            }
        }

        /// <summary>
        /// 将当前字符串转换为双精度浮点数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的双精度浮点数，失败则返回指定的默认值。</returns>
        public static double AsDouble(this string value, double failureValue)
        {
            double d;
            if (double.TryParse(value, out d) == true)
            {
                return d;
            }
            else
            {
                return failureValue;
            }
        }

        /// <summary>
        /// 将当前字符串转换为 16 位有符号整数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <returns>成功则返回相应的 16 位有符号整数，失败则返回 -1。</returns>
        public static short AsInt16(this string value)
        {
            return AsInt16(value, -1);
        }

        /// <summary>
        /// 将当前字符串转换为 16 位有符号整数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的 16 位有符号整数，失败则返回指定的默认值。</returns>
        public static short AsInt16(this string value, short failureValue)
        {
            short s;
            if (short.TryParse(value, out s) == true)
            {
                return s;
            }
            else
            {
                return failureValue;
            }
        }

        /// <summary>
        /// 将当前字符串转换为 32 位有符号整数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <returns>成功则返回相应的 32 位有符号整数，失败则返回 -1。</returns>
        public static int AsInt32(this string value)
        {
            return AsInt32(value, -1);
        }

        /// <summary>
        /// 将当前字符串转换为 32 位有符号整数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的 32 位有符号整数，失败则返回指定的默认值。</returns>
        public static int AsInt32(this string value, int failureValue)
        {
            int i;
            if (int.TryParse(value, out i) == true)
            {
                return i;
            }
            else
            {
                return failureValue;
            }
        }

        /// <summary>
        /// 将当前字符串转换为 64 位有符号整数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <returns>成功则返回相应的 64 位有符号整数，失败则返回 -1。</returns>
        public static long AsInt64(this string value)
        {
            return AsInt64(value, -1);
        }

        /// <summary>
        /// 将当前字符串转换为 64 位有符号整数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的 64 位有符号整数，失败则返回指定的默认值。</returns>
        public static long AsInt64(this string value, long failureValue)
        {
            long l;
            if (long.TryParse(value, out l) == true)
            {
                return l;
            }
            else
            {
                return failureValue;
            }
        }

        /// <summary>
        /// 将当前字符串转换为 8 位有符号整数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的 8 位有符号整数，失败则返回指定的默认值。</returns>
        public static sbyte AsSByte(this string value, sbyte failureValue)
        {
            sbyte sb;
            if (sbyte.TryParse(value, out sb) == true)
            {
                return sb;
            }
            else
            {
                return failureValue;
            }
        }

        /// <summary>
        /// 将当前字符串转换为单精度浮点数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的双精度浮点数，失败则返回指定的默认值。</returns>
        public static float AsSingle(this string value, float failureValue)
        {
            float f; ;
            if (float.TryParse(value, out f) == true)
            {
                return f;
            }
            else
            {
                return failureValue;
            }
        }

        /// <summary>
        /// 将当前字符串转换为 16 位无符号整数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的 16 位无符号整数，失败则返回指定的默认值。</returns>
        [CLSCompliant(false)]
        public static ushort AsUInt16(this string value, ushort failureValue)
        {
            ushort us;
            if (ushort.TryParse(value, out us) == true)
            {
                return us;
            }
            else
            {
                return failureValue;
            }
        }

        /// <summary>
        /// 将当前字符串转换为 32 位无符号整数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的 32 位无符号整数，失败则返回指定的默认值。</returns>
        [CLSCompliant(false)]
        public static uint AsUInt32(this string value, uint failureValue)
        {
            uint ui;
            if (uint.TryParse(value, out ui) == true)
            {
                return ui;
            }
            else
            {
                return failureValue;
            }
        }

        /// <summary>
        /// 将当前字符串转换为 64 位无符号整数。
        /// </summary>
        /// <param name="value">转换的字符串。</param>
        /// <param name="failureValue">无法转换时返回的默认值。</param>
        /// <returns>成功则返回相应的 64 位无符号整数，失败则返回指定的默认值。</returns>
        public static ulong AsUInt64(this string value, ulong failureValue)
        {
            ulong ul;
            if (ulong.TryParse(value, out ul) == true)
            {
                return ul;
            }
            else
            {
                return failureValue;
            }
        }

        /// <summary>
        /// 将当前字符串进行 Base64 解码。
        /// </summary>
        /// <param name="value">需解码的字符串。</param>
        /// <returns>解码后的字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        public static string Base64Decode(this string value)
        {
            byte[] bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// 将当前字符串进行 Base64 编码。
        /// </summary>
        /// <param name="value">需编码的字符串。</param>
        /// <returns>编码后的字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        public static string Base64Encode(this string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 返回一个值，该值指示指定的 System.String 对象是否出现在此字符串中。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="comparisonValue">要搜寻的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值。</param>
        /// <returns>如果 value 参数出现在此字符串中，或者 value 为空字符串 ("")，则为 true；否则为 false。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        public static bool Contains(this string value, string comparisonValue, StringComparison comparisonType)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (string.IsNullOrEmpty(value) == true)
            {
                return true;
            }
            return value.IndexOf(comparisonValue, comparisonType) != -1;
        }

        /// <summary>
        /// 返回一个值，该值指示当前字符串是否包含指定字符串对象中的全部。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="values">要搜寻的字符串列表。</param>
        /// <returns>是否包含所有。</returns>
        public static bool ContainsAll(this string value, params string[] values)
        {
            return ContainsAll(value, StringComparison.CurrentCulture, values);
        }

        /// <summary>
        /// 返回一个值，该值指示当前字符串是否包含指定字符串对象中的全部。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值。</param>
        /// <param name="values">要搜寻的字符串列表。</param>
        /// <returns>是否包含所有。</returns>
        public static bool ContainsAll(this string value, StringComparison comparisonType, params string[] values)
        {
            foreach (string temp in values)
            {
                if (value.IndexOf(temp, comparisonType) == -1)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 返回一个值，该值指示当前字符串是否包含指定字符串对象中的任意一个。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="values">要搜寻的字符串列表。</param>
        /// <returns>是否包含其中的一个。</returns>
        public static bool ContainsAny(this string value, params  string[] values)
        {
            return ContainsAny(value, StringComparison.CurrentCulture, values);
        }

        /// <summary>
        /// 返回一个值，该值指示当前字符串是否包含指定字符串对象中的任意一个。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值。</param>
        /// <param name="values">要搜寻的字符串列表。</param>
        /// <returns>是否包含其中的一个。</returns>
        public static bool ContainsAny(this string value, StringComparison comparisonType, params string[] values)
        {
            foreach (string temp in values)
            {
                if (value.IndexOf(temp, comparisonType) != -1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 确定此字符串是否与指定的 System.String 对象具有相同的值。 参数指定区域性、大小写以及比较所用的排序规则。
        /// </summary>
        /// <param name="this">测试的字符串。</param>
        /// <param name="value">要与此实例进行比较的字符串。</param>
        /// <returns>如果 value 参数的值为空或与此字符串相同，则为 true；否则为 false。</returns>
        public static bool EqualsSafely(this string @this, string value)
        {
            return EqualsSafely(@this, value, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// 确定此字符串是否与指定的 System.String 对象具有相同的值。 参数指定区域性、大小写以及比较所用的排序规则。
        /// </summary>
        /// <param name="this">测试的字符串。</param>
        /// <param name="value">要与此实例进行比较的字符串。</param>
        /// <param name="comparisonType">枚举值之一，用于指定将如何比较字符串。</param>
        /// <returns>如果 value 参数的值为空或与此字符串相同，则为 true；否则为 false。</returns>
        public static bool EqualsSafely(this string @this, string value, StringComparison comparisonType)
        {
            if (@this == null)
            {
                if (value == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (Enum.IsDefined(typeof(StringComparison), comparisonType) == true)
            {
                return @this.Equals(value, comparisonType);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 将当前字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="parameters">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns>format 的一个副本，其中格式项已替换为 args 中相应对象的字符串表示形式。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        [SuppressMessage("Microsoft.Globalization", "CA1305")]
        public static string Format(this string value, params object[] parameters)
        {
            return string.Format(value, parameters);
        }

        /// <summary>
        /// 以空白分割当前字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <returns>单词数组。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        public static string[] GetWords(this string value)
        {
            return Regex.Split(value, @"\W");
        }

        /// <summary>
        /// 指示当前字符串能否转换为任意大的带符号整数。
        /// </summary>
        /// <param name="value">测试的字符串。</param>
        /// <returns>是否能转换为任意大的带符号整数。</returns>
        public static bool IsBigInteger(this string value)
        {
            BigInteger bigInteger;
            return BigInteger.TryParse(value, out bigInteger);
        }

        /// <summary>
        /// 指示当前字符串能否转换为 8 位无符号整数。
        /// </summary>
        /// <param name="value">测试的字符串。</param>
        /// <returns>是否能转换为 8 位无符号整数。</returns>
        public static bool IsByte(this string value)
        {
            byte b;
            return byte.TryParse(value, out b);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为十进制数。
        /// </summary>
        /// <param name="value">测试的字符串。</param>
        /// <returns>是否能转换为十进制数。</returns>
        public static bool IsDecimal(this string value)
        {
            decimal d;
            return decimal.TryParse(value, out d);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为双精度浮点数。
        /// </summary>
        /// <param name="value">测试的字符串。</param>
        /// <returns>是否能转换为双精度浮点数。</returns>
        public static bool IsDouble(this string value)
        {
            double d;
            return double.TryParse(value, out d);
        }

#if Net40
        /// <summary>
        /// 指示指定字符串是否为 E-mail 地址。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>若符合 E-mail 格式，则为 true，否则为 false。</returns>
#endif
#if Net45
        /// <summary>
        /// 指示指定字符串是否为 E-mail 地址。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>若符合 E-mail 格式，则为 true，否则为 false。</returns>
        /// <exception cref="System.Text.RegularExpressions.RegexMatchTimeoutException">发生超时。</exception>
#endif
        public static bool IsEmail(this string value)
        {
            if (value == null)
            {
                return false;
            }
            Regex r = new Regex(@"^\S+@\S+\.\S+$");
            return r.IsMatch(value);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 16 位有符号整数。
        /// </summary>
        /// <param name="value">测试的字符串。</param>
        /// <returns>能否转换为 16 位有符号整数。</returns>
        public static bool IsInt16(this string value)
        {
            short s;
            return short.TryParse(value, out s);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 32 位有符号整数。
        /// </summary>
        /// <param name="value">测试的字符串。</param>
        /// <returns>是否能转换为 32 位有符号整数。</returns>
        public static bool IsInt32(this string value)
        {
            int i;
            return int.TryParse(value, out i);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 64 位有符号整数。
        /// </summary>
        /// <param name="value">测试的字符串。</param>
        /// <returns>是否能转换为 64 位有符号整数。</returns>
        public static bool IsInt64(this string value)
        {
            long l;
            return long.TryParse(value, out l);
        }

#if Net40
        /// <summary>
        /// 指示指定正则表达式在字符串中是否找到了匹配项。
        /// </summary>
        /// <param name="input">字符串。</param>
        /// <param name="regex">正则表达式。</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false。</returns>
        /// <exception cref="System.ArgumentException">出现正则表达式分析错误。</exception>
        /// <exception cref="System.ArgumentNullException"><c>input</c> 为 null。</exception>
#endif
#if Net45
        /// <summary>
        /// 指示指定正则表达式在字符串中是否找到了匹配项。
        /// </summary>
        /// <param name="input">字符串。</param>
        /// <param name="regex">正则表达式。</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false。</returns>
        /// <exception cref="System.ArgumentException">出现正则表达式分析错误。</exception>
        /// <exception cref="System.ArgumentNullException"><c>input</c> 为 null。</exception>
        /// <exception cref="System.Text.RegularExpressions.RegexMatchTimeoutException">发生超时。</exception>
#endif
        public static bool IsMatch(this string input, string regex)
        {
            Regex r = new Regex(regex);
            return r.IsMatch(input);
        }

        /// <summary>
        /// 指示指定的字符串是 null 还是 Empty 字符串。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果 value 参数为 null 或空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>如果 value 参数为 null 或 String.Empty，或者如果 value 仅由空白字符组成，则为 true。</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 8 位有符号整数。
        /// </summary>
        /// <param name="value">测试的字符串。</param>
        /// <returns>是否能转换为 8 位有符号整数。</returns>
        public static bool IsSByte(this string value)
        {
            sbyte sb;
            return sbyte.TryParse(value, out sb);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为单精度浮点数。
        /// </summary>
        /// <param name="value">测试的字符串。</param>
        /// <returns>是否能转换为单精度浮点数。</returns>
        public static bool IsSingle(this string value)
        {
            float f;
            return float.TryParse(value, out f);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 16 位无符号整数。
        /// </summary>
        /// <param name="value">测试的字符串。</param>
        /// <returns>是否能转换为 16 位无符号整数。</returns>
        public static bool IsUInt16(this string value)
        {
            ushort us;
            return ushort.TryParse(value, out us);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 32 位无符号整数。
        /// </summary>
        /// <param name="value">测试的字符串。</param>
        /// <returns>是否能转换为 32 位无符号整数。</returns>
        public static bool IsUInt32(this string value)
        {
            uint ui;
            return uint.TryParse(value, out ui);
        }

        /// <summary>
        /// 指示当前字符串是否能转换为 64 位无符号整数。
        /// </summary>
        /// <param name="value">测试的字符串。</param>
        /// <returns>是否能转换为 64 位无符号整数。</returns>
        public static bool IsUInt64(this string value)
        {
            ulong ul;
            return ulong.TryParse(value, out ul);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的所有指定字符串都替换为另一个指定的字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="oldValue">要被替换的字符串。</param>
        /// <param name="newValue">要替换出现的所有 oldValue 的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>等效于当前字符串（除了 oldValue 的所有实例都已替换为 newValue 外）的字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        /// <exception cref="System.ArgumentNullException"><c>oldValue</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>oldValue</c> 是空字符串 ("")。</exception>
        public static string Replace(this string value, string oldValue, string newValue,
            StringComparison comparisonType)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "未将对象引用设置到对象的实例。");
            }
            if (oldValue == null)
            {
                throw new ArgumentNullException("oldValue", "值不能为 null。");
            }
            if (oldValue.Length == 0)
            {
                throw new ArgumentException("字符串的长度不能为零。", "oldValue");
            }
            while (true)
            {
                int index = value.IndexOf(oldValue, comparisonType);
                if (index == -1)
                {
                    return value;
                }
                value = value.Substring(0, index) + newValue + value.Substring(index + oldValue.Length);
            }
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的第一个指定字符串会被替换为另一个指定的字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="oldValue">要被替换的字符串。</param>
        /// <param name="newValue">要替换第一次出现的 oldValue 的字符串。</param>
        /// <returns>等效于当前字符串（除了 oldValue 的第一个实例都已替换为 newValue 外）的字符串。</returns>
        /// <exception cref="System.NullReferenceException"><c>value</c> 为 null。</exception>
        /// <exception cref="System.ArgumentNullException"><c>oldValue</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>oldValue</c> 是空字符串 ("")。</exception>
        public static string ReplaceFirst(this string value, string oldValue, string newValue)
        {
            return ReplaceFirst(value, oldValue, newValue, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的第一个指定字符串会被替换为另一个指定的字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="oldValue">要被替换的字符串。</param>
        /// <param name="newValue">要替换第一次出现的 oldValue 的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>等效于当前字符串（除了 oldValue 的第一个实例都已替换为 newValue 外）的字符串。</returns>
        /// <exception cref="System.NullReferenceException"><c>value</c> 为 null。</exception>
        /// <exception cref="System.ArgumentNullException"><c>oldValue</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>oldValue</c> 是空字符串 ("")。</exception>
        public static string ReplaceFirst(this string value, string oldValue, string newValue,
            StringComparison comparisonType)
        {
            if (value == null)
            {
                throw new NullReferenceException("未将对象引用设置到对象的实例。");
            }
            if (oldValue == null)
            {
                throw new ArgumentNullException("oldValue", "值不能为 null。");
            }
            if (oldValue.Length == 0)
            {
                throw new ArgumentException("字符串的长度不能为零。", "oldValue");
            }
            int index = value.IndexOf(oldValue, comparisonType);
            if (index == -1)
            {
                return value;
            }
            return value.Substring(0, index) + newValue + value.Substring(index + oldValue.Length);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的第一个指定字符串会被替换为另一个指定的字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="oldValue">要被替换的字符串。</param>
        /// <param name="newValue">要替换第一次出现的 oldValue 的字符串。</param>
        /// <returns>等效于当前字符串（除了 oldValue 的第一个实例都已替换为 newValue 外）的字符串。</returns>
        public static string ReplaceFirstSafely(this string value, string oldValue, string newValue)
        {
            return ReplaceFirstSafely(value, oldValue, newValue, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的第一个指定字符串会被替换为另一个指定的字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="oldValue">要被替换的字符串。</param>
        /// <param name="newValue">要替换第一次出现的 oldValue 的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>等效于当前字符串（除了 oldValue 的第一个实例都已替换为 newValue 外）的字符串。</returns>
        public static string ReplaceFirstSafely(this string value, string oldValue, string newValue,
            StringComparison comparisonType)
        {
            if (value == null)
            {
                return null;
            }
            if (string.IsNullOrEmpty(oldValue) == true)
            {
                return value;
            }
            return ReplaceFirst(value, oldValue, newValue, comparisonType);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的最后一个指定字符串会被替换为另一个指定的字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="oldValue">要被替换的字符串。</param>
        /// <param name="newValue">要替换最后一次出现的 oldValue 的字符串。</param>
        /// <returns>等效于当前字符串（除了 oldValue 的最后一个实例都已替换为 newValue 外）的字符串。</returns>
        /// <exception cref="System.NullReferenceException"><c>value</c> 为 null。</exception>
        /// <exception cref="System.ArgumentNullException"><c>oldValue</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>oldValue</c> 是空字符串 ("")。</exception>
        public static string ReplaceLast(this string value, string oldValue, string newValue)
        {
            return ReplaceLast(value, oldValue, newValue, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的最后一个指定字符串会被替换为另一个指定的字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="oldValue">要被替换的字符串。</param>
        /// <param name="newValue">要替换最后一次出现的 oldValue 的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>等效于当前字符串（除了 oldValue 的最后一个实例都已替换为 newValue 外）的字符串。</returns>
        /// <exception cref="System.NullReferenceException"><c>value</c> 为 null。</exception>
        /// <exception cref="System.ArgumentNullException"><c>oldValue</c> 为 null。</exception>
        /// <exception cref="System.ArgumentException"><c>oldValue</c> 是空字符串 ("")。</exception>
        public static string ReplaceLast(this string value, string oldValue, string newValue,
            StringComparison comparisonType)
        {
            if (value == null)
            {
                throw new NullReferenceException("未将对象引用设置到对象的实例。");
            }
            if (oldValue == null)
            {
                throw new ArgumentNullException("oldValue", "值不能为 null。");
            }
            if (oldValue.Length == 0)
            {
                throw new ArgumentException("字符串的长度不能为零。", "oldValue");
            }
            int index = value.LastIndexOf(oldValue, comparisonType);
            if (index == -1)
            {
                return value;
            }
            return value.Substring(0, index) + newValue + value.Substring(index + oldValue.Length);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的最后一个指定字符串会被替换为另一个指定的字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="oldValue">要被替换的字符串。</param>
        /// <param name="newValue">要替换最后一次出现的 oldValue 的字符串。</param>
        /// <returns>等效于当前字符串（除了 oldValue 的最后一个实例都已替换为 newValue 外）的字符串。</returns>
        public static string ReplaceLastSafely(this string value, string oldValue, string newValue)
        {
            return ReplaceLast(value, oldValue, newValue, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的最后一个指定字符串会被替换为另一个指定的字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="oldValue">要被替换的字符串。</param>
        /// <param name="newValue">要替换最后一次出现的 oldValue 的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>等效于当前字符串（除了 oldValue 的最后一个实例都已替换为 newValue 外）的字符串。</returns>
        public static string ReplaceLastSafely(this string value, string oldValue, string newValue,
            StringComparison comparisonType)
        {
            if (value == null)
            {
                return value;
            }
            if (string.IsNullOrEmpty(oldValue) == true)
            {
                return value;
            }
            return ReplaceLast(value, oldValue, newValue, comparisonType);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的所有指定字符串都替换为另一个指定的字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="oldValue">要被替换的字符串。</param>
        /// <param name="newValue">要替换出现的所有 oldValue 的字符串。</param>
        /// <returns>等效于当前字符串（除了 oldValue 的所有实例都已替换为 newValue 外）的字符串。</returns>
        public static string ReplaceSafely(this string value, string oldValue, string newValue)
        {
            return value.ReplaceSafely(oldValue, newValue, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的所有指定字符串都替换为另一个指定的字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="oldValue">要被替换的字符串。</param>
        /// <param name="newValue">要替换出现的所有 oldValue 的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>等效于当前字符串（除了 oldValue 的所有实例都已替换为 newValue 外）的字符串。</returns>
        public static string ReplaceSafely(this string value, string oldValue, string newValue, StringComparison comparisonType)
        {
            if (value == null)
            {
                return value;
            }
            if (string.IsNullOrEmpty(oldValue) == true)
            {
                return value;
            }
            return Replace(value, oldValue, newValue, comparisonType);
        }

        /// <summary>
        /// 将当前字符串转换为半角。
        /// </summary>
        /// <param name="value">需要转换的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        public static string ToDBC(this string value)
        {
            if (string.IsNullOrEmpty(value) == true)
            {
                return value;
            }
            StringBuilder sb = new StringBuilder();
            foreach (char c in value)
            {
                if (c == 12288)
                {
                    sb.Append((char)32);
                    continue;
                }
                if (c > 65280 && c < 65375)
                {
                    sb.Append((char)(c - 65248));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将当前字符串转换为全角。
        /// </summary>
        /// <param name="value">需要转换的字符串。</param>
        /// <returns>转换后的字符串。</returns>
        public static string ToSBC(this string value)
        {
            if (string.IsNullOrEmpty(value) == true)
            {
                return value;
            }
            StringBuilder sb = new StringBuilder();
            foreach (char c in value)
            {
                if (c == 32)
                {
                    sb.Append((char)12288);
                    continue;
                }
                if (c < 127)
                {
                    sb.Append((char)(c + 65248));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string TrimSafely(this string value)
        {
            if (string.IsNullOrEmpty(value) == true)
            {
                return value;
            }
            else
            {
                return value.Trim();
            }
        }

        public static string TrimSafely(this string value, params char[] trimChars)
        {
            if (string.IsNullOrEmpty(value) == true)
            {
                return value;
            }
            else
            {
                return value.Trim(trimChars);
            }
        }

        [SuppressMessage("", "")]
        public static string TrimStartSafely(this string value, params char[] trimChars)
        {
            if (string.IsNullOrEmpty(value) == true)
            {
                return value;
            }
            else
            {
                return value.TrimStart(trimChars);
            }
        }

        public static string TrimEndSafely(this string value, params char[] trimChars)
        {
            if (string.IsNullOrEmpty(value) == true)
            {
                return value;
            }
            else
            {
                return value.TrimEnd(trimChars);
            }
        }

        public static string SwapCase(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            var sb = new StringBuilder(value.Length);
            foreach (var c in value)
            {
                if (char.IsUpper(c))
                {
                    sb.Append(char.ToLower(c));
                }
                else if (char.IsLower(c))
                {
                    sb.Append(char.ToUpper(c));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
