using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeEnum(Enum e)
        {
            switch (JsonHelper.EnumFormat)
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
                        throw new InvalidEnumArgumentException("Enum 类型的序列化格式未指定。");
                    }
            }
        }
    }
}
