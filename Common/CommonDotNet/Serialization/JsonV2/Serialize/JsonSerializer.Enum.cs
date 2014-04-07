using System;
using System.ComponentModel;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeEnum(Enum e)
        {
            switch (this.EnumFormat)
            {
                case Json.EnumFormat.Default:
                    {
                        return Convert.ToInt32(e).ToString();
                    }
                case Json.EnumFormat.Name:
                    {
                        return "\"" + e.ToString() + "\"";
                    }
                default:
                    {
                        throw new InvalidEnumArgumentException("JsonHelper.EnumFormat", (int)this.EnumFormat, typeof(Json.EnumFormat));
                    }
            }
        }
    }
}
