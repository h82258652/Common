using System.Net;
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
        /// 指示指定正则表达式在字符串中是否找到了匹配项。
        /// </summary>
        /// <param name="input">字符串。</param>
        /// <param name="regex">正则表达式。</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false。</returns>
        /// <exception cref="System.ArgumentException">出现正则表达式分析错误。</exception>
        /// <exception cref="System.ArgumentNullException"><c>input</c> 为 null。</exception>
        /// <exception cref="System.Text.RegularExpressions.RegexMatchTimeoutException">发生超时。</exception>
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
        /// 指示指定字符串是否为 E-mail 地址。
        /// </summary>
        /// <param name="value">要测试的字符串。</param>
        /// <returns>若符合 E-mail 格式，则为 true，否则为 false。</returns>
        /// <exception cref="System.Text.RegularExpressions.RegexMatchTimeoutException">发生超时。</exception>
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
        /// 将当前字符串转换为全角
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
            foreach (var c in value)
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

        /// <summary>
        /// 将当前字符串转换为半角
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
            foreach (var c in value)
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
        /// 返回一个值，该值指示指定的 System.String 对象是否出现在此字符串中。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="comparisonValue">要搜寻的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值。</param>
        /// <returns>如果 value 参数出现在此字符串中，或者 value 为空字符串 ("")，则为 true；否则为 false。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        public static bool Contains(this string value, string comparisonValue, StringComparison comparisonType)
        {
            if (value == string.Empty)
            {
                return true;
            }
            return value.IndexOf(comparisonValue, comparisonType) != -1;
        }

        /// <summary>
        /// 将当前字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="parameters">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns>format 的一个副本，其中格式项已替换为 args 中相应对象的字符串表示形式。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        public static string Format(this string value, params object[] parameters)
        {
            return string.Format(value, parameters);
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
        /// 将当前字符串进行 Base64 编码。
        /// </summary>
        /// <param name="value">需编码的字符串。</param>
        /// <returns>编码后的字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        public static string Base64Encode(this string value)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(value));
        }

        /// <summary>
        /// 将当前字符串进行 Base64 解码。
        /// </summary>
        /// <param name="value">需解码的字符串。</param>
        /// <returns>解码后的字符串。</returns>
        /// <exception cref="System.ArgumentNullException"><c>value</c> 为 null。</exception>
        public static string Base64Decode(this string value)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(value));
        }

        /// <summary>
        /// 指示当前字符串是否为 IP 地址。
        /// </summary>
        /// <param name="value">测试的字符串。</param>
        /// <returns>是否为 IP 地址。</returns>
        public static bool IsIPAddress(this string value)
        {
            if (value == null)
            {
                return false;
            }
            IPAddress address;
            return IPAddress.TryParse(value, out address);
        }
    }
}
