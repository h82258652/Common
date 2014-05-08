using System.Collections.Generic;

namespace Common.Serialization.Json
{
    public static partial class JsonHelper
    {
        internal static void ItemSpliter(string keyValue, out string key, out string value)
        {
            key = string.Empty;
            value = string.Empty;
            for (int i = 1; i < keyValue.Length; i++)
            {
                if (keyValue[i] == '\"' && keyValue[i - 1] != '\\')
                {
                    key = keyValue.Substring(0, i + 1);
                    for (; i < keyValue.Length; i++)
                    {
                        if (keyValue[i] == ':')
                        {
                            value = keyValue.Substring(i + 1);
                            break;
                        }
                    }
                    break;
                }
            }
            key = key.Trim();
            value = value.Trim();
        }
    }
}
