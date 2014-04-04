using System;
using System.ComponentModel;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeDateTime(DateTime dateTime)
        {
            switch (JsonHelper.DateTimeFormat)
            {
                case Json.DateTimeFormat.Create:
                    {
                        return "new Date(" + (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0)).Ticks / 0x2710 +
                               ")";
                    }
                case Json.DateTimeFormat.Default:
                    {
                        return "\"" + dateTime.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFFK") + "\"";
                    }
                case Json.DateTimeFormat.Function:
                    {
                        return "\"\\/Date(" + (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0)).Ticks / 0x2710 +
                               ")\\/\"";
                    }
                default:
                    {
                        throw new ArgumentException("DateTime 类型的序列化格式未指定。");
                    }
            }
        }
    }
}
