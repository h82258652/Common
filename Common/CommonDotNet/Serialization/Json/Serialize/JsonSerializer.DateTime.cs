using System;
using System.ComponentModel;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeDateTime(DateTime dateTime)
        {
            switch (this.DateTimeFormat)
            {
                case Json.DateTimeFormat.Create:
                    {
                        return "new Date(" + (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0)).Ticks / 0x2710 + ")";
                    }
                case Json.DateTimeFormat.Default:
                    {
                        return "\"" + dateTime.ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFFK") + "\"";
                    }
                case Json.DateTimeFormat.Function:
                    {
                        return "\"\\/Date(" + (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0)).Ticks / 0x2710 + ")\\/\"";
                    }
                default:
                    {
                        throw new InvalidEnumArgumentException("JsonHelper.DateTimeFormat", (int)this.DateTimeFormat, typeof(Json.DateTimeFormat));
                    }
            }
        }
    }
}
