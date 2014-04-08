using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeRegex(Regex regex)
        {
            switch (this.RegexFormat)
            {
                case Json.RegexFormat.Create:
                    {
                        StringBuilder flags = new StringBuilder(2);
                        if (regex.Options.HasFlag(RegexOptions.IgnoreCase) == true)
                        {
                            flags.Append("i");
                        }
                        if (regex.Options.HasFlag(RegexOptions.Multiline) == true)
                        {
                            flags.Append("m");
                        }
                        if (flags.Length > 0)
                        {
                            return "new RegExp(\"" + regex.ToString() + "\",\"" + flags.ToString() + "\")";
                        }
                        else
                        {
                            return "new RegExp(\"" + regex.ToString() + "\")";
                        }
                    }
                case Json.RegexFormat.Default:
                    {
                        StringBuilder sb = new StringBuilder("/");
                        sb.Append(regex.ToString());
                        sb.Append("/");
                        if (regex.Options.HasFlag(RegexOptions.IgnoreCase) == true)
                        {
                            sb.Append("i");
                        }
                        if (regex.Options.HasFlag(RegexOptions.Multiline) == true)
                        {
                            sb.Append("m");
                        }
                        return sb.ToString();
                    }
                default:
                    {
                        throw new InvalidEnumArgumentException("JsonHelper.RegexFormat", (int)this.RegexFormat, typeof(Json.RegexFormat));
                    }
            }
        }
    }
}
