using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.Text.RegularExpressions.RegexMatchTimeoutException"></exception>
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
        /// <exception cref="System.Text.RegularExpressions.RegexMatchTimeoutException"></exception>
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
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSBC(this string value)
        {
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
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDBC(this string value)
        {
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
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static string[] GetWords(this string value)
        {
            return Regex.Split(value, @"\W");
        }

        /// <summary>
        /// 返回一个值，该值指示指定的 System.String 对象是否出现在此字符串中。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparisonValue">要搜寻的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值。</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static bool Contains(this string value, string comparisonValue, StringComparison comparisonType)
        {
            return value.IndexOf(comparisonValue, comparisonType) != -1;
        }

        /// <summary>
        /// 将当前字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameters">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static string Format(this string value, params object[] parameters)
        {
            return string.Format(value, parameters);
        }

        /// <summary>
        /// 返回一个值，该值指示当前字符串是否包含指定字符串对象中的任意一个。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="values">要搜寻的字符串列表。</param>
        /// <returns></returns>
        public static bool ContainsAny(this string value, params  string[] values)
        {
            return ContainsAny(value, StringComparison.CurrentCulture, values);
        }

        /// <summary>
        /// 返回一个值，该值指示当前字符串是否包含指定字符串对象中的任意一个。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparisonType">指定搜索规则的枚举值。</param>
        /// <param name="values">要搜寻的字符串列表。</param>
        /// <returns></returns>
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
    }
}