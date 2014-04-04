using System;
using System.Text.RegularExpressions;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        private static readonly Regex RegexCreateRegex = new Regex("new\\s+RegExp\\(\\s*(\\\"(.*?)\\\"|\\'(.*?)\\')\\s*(,\\s*(\\\"(.*?)\\\"|\\'(.*?)\\')\\s*)?\\)");

        private static readonly Regex RegexDefaultRegex = new Regex(@"^/(.*?)/(g|i|m|gi|gm|ig|im|mg|mi|gim|gmi|igm|img|mgi|mig)?$");

        internal static Regex DeserializeToRegex(string input, Type type)
        {
            Match match;
            match = RegexCreateRegex.Match(input);
            if (match.Success == true)
            {
                string pattern = match.Groups[3].Value;
                string attributes = match.Groups[7].Value;
                RegexOptions options = RegexOptions.None;
                if (attributes.Contains("i") == true)
                {
                    options = options | RegexOptions.IgnoreCase;
                }
                if (attributes.Contains("m") == true)
                {
                    options = options | RegexOptions.Multiline;
                }
                return new Regex(pattern, options);
            }
            match = RegexDefaultRegex.Match(input);
            if (match.Success == true)
            {
                string pattern = match.Groups[1].Value;
                string attributes = match.Groups[2].Value;
                RegexOptions options = RegexOptions.None;
                if (attributes.Contains("i") == true)
                {
                    options = options | RegexOptions.IgnoreCase;
                }
                if (attributes.Contains("m") == true)
                {
                    options = options | RegexOptions.Multiline;
                }
                return new Regex(pattern, options);
            }
            throw new JsonDeserializeException(input, type);
        }
    }
}
