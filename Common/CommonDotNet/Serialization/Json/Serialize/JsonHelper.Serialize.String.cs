using System.Text;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeString(string s)
        {
            StringBuilder sb = new StringBuilder("\"");
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\\':
                        {
                            sb.Append("\\\\");
                            break;
                        }
                    case '\b':
                        {
                            sb.Append("\\b");
                            break;
                        }
                    case '\f':
                        {
                            sb.Append("\\\f");
                            break;
                        }
                    case '\n':
                        {
                            sb.Append("\\n");
                            break;
                        }
                    case '\r':
                        {
                            sb.Append("\\r");
                            break;
                        }
                    case '\t':
                        {
                            sb.Append("\\t");
                            break;
                        }
                    default:
                        {
                            sb.Append(c);
                            break;
                        }
                }
            }
            sb.Append("\"");
            return sb.ToString();
        }
    }
}
