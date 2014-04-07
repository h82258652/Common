using System.Collections.Generic;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        private static IEnumerable<string> ItemReader(string input)
        {
            int length = input.Length;
            if (length == 0)
            {
                yield return null;
                yield break;
            }
            int startIndex = 0;
            int doubleQuote = 0;// 双引号。
            int bracket = 0;// 中括号。
            int brace = 0;// 大括号。
            for (int i = 0; i < length; i++)
            {
                if (input[i] == '\\')
                {
                    i++;
                }
                else if (input[i] == '\"')
                {
                    doubleQuote = 1 - doubleQuote;
                }
                else if (input[i] == '[')
                {
                    bracket++;
                }
                else if (input[i] == ']')
                {
                    bracket--;
                }
                else if (input[i] == '{')
                {
                    brace++;
                }
                else if (input[i] == '}')
                {
                    brace--;
                }
                else if (input[i] == ',' && bracket == 0 && brace == 0)
                {
                    string item = input.Substring(startIndex, i - startIndex);
                    startIndex = i + 1;
                    item = item.Trim();
                    yield return item;
                }
            }
            {
                string item = input.Substring(startIndex, length - startIndex);
                item = item.Trim();
                yield return item;
            }
        }
    }
}
