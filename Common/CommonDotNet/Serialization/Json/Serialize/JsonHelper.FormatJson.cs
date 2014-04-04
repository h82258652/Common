using System;
using System.Text;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        private static string BuildIndentation(int level)
        {
            return new string(' ', SerializeIndentationWhiteSpaceCount * level);
        }

        /// <summary>
        /// 格式化 JSON 字符串。
        /// </summary>
        /// <param name="json">JSON 字符串。</param>
        /// <returns>格式化后的JSON 字符串。</returns>
        public static string FormatJson(string json)
        {
            if (SerializeIndentationWhiteSpaceCount < 0)
            {
                throw new ArgumentOutOfRangeException("json", "JSON 格式化缩进空格数不能小于0。");
            }

            if (SerializeIndentationWhiteSpaceCount == 0 && SerializeWapp == false)
            {
                return json;
            }

            StringBuilder sb = new StringBuilder();

            // 缩进
            int level = 0;

            // 换行
            string wrap = SerializeWapp == true ? Environment.NewLine : string.Empty;

            // 是否在字符串中
            bool instring = false;

            for (int i = 0; i < json.Length; i++)
            {
                if (json[i] == '\"' && i - 1 >= 0 && json[i - 1] != '\\')
                {
                    instring = !instring;
                }
                if (json[i] == '{' && instring == false)
                {
                    sb.Append('{');
                    sb.Append(wrap);
                    level++;
                    sb.Append(BuildIndentation(level));
                }
                else if (json[i] == '}' && instring == false)
                {
                    sb.Append(wrap);
                    level--;
                    sb.Append(BuildIndentation(level));
                    sb.Append('}');
                }
                else if (json[i] == '[' && instring == false)
                {
                    sb.Append('[');
                    sb.Append(wrap);
                    level++;
                    sb.Append(BuildIndentation(level));
                }
                else if (json[i] == ']' && instring == false)
                {
                    sb.Append(wrap);
                    level--;
                    sb.Append(BuildIndentation(level));
                    sb.Append(']');
                }
                else if (json[i] == ':' && instring == false)
                {
                    sb.Append(':');
                    sb.Append(' ');
                }
                else if (json[i] == ',' && instring == false)
                {
                    sb.Append(',');
                    sb.Append(wrap);
                    sb.Append(BuildIndentation(level));
                }
                else if (json[i] == ' ' && instring == false)
                {
                    continue;
                }
                else
                {
                    sb.Append(json[i]);
                }
            }

            return sb.ToString();
        }
    }
}
