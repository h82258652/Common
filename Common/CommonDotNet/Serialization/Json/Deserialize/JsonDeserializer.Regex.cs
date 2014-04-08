using System;
using System.Text.RegularExpressions;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private static readonly Regex RegexCreateRegex = new Regex("new\\s+RegExp\\(\\s*(\\\"(.*?)\\\"|\\'(.*?)\\')\\s*(,\\s*(\\\"(.*?)\\\"|\\'(.*?)\\')\\s*)?\\)", RegexOptions.Compiled);

        private static readonly Regex RegexDefaultRegex = new Regex(@"^/(.*?)/(g|i|m|gi|gm|ig|im|mg|mi|gim|gmi|igm|img|mgi|mig)?$", RegexOptions.Compiled);

        private Regex DeserializeToRegex(string input, Type type)
        {
            Match match;
            match = RegexCreateRegex.Match(input);
            if (match.Success == true)
            {
                string pattern = match.Groups[2].Success ? match.Groups[2].Value : match.Groups[3].Value;
                string attributes = match.Groups[6].Success ? match.Groups[6].Value : match.Groups[7].Value;
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
