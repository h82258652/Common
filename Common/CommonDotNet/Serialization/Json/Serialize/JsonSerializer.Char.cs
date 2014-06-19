
namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeChar(char c)
        {
            switch (c)
            {
                case '\"':
                    {
                        return "\"\\\"\"";
                    }
                case '\\':
                    {
                        return "\"\\\\\"";
                    }
                case '\b':
                    {
                        return "\"\\b\"";
                    }
                case '\f':
                    {
                        return "\"\\f\"";
                    }
                case '\n':
                    {
                        return "\"\\n\"";
                    }
                case '\r':
                    {
                        return "\"\\r\"";
                    }
                case '\t':
                    {
                        return "\"\\t\"";
                    }
                default:
                    {
                        return "\"" + c + "\"";
                    }
            }
        }
    }
}
