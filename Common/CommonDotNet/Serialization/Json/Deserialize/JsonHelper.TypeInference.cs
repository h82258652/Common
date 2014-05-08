using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serialization.Json
{
    public static partial class JsonHelper
    {
        /// <summary>
        /// 推断当前 json 基础字符串的类型。
        /// </summary>
        /// <param name="json">json 基础字符串。</param>
        /// <returns>推断类型。</returns>
        public static Type TypeInference(string json)
        {
            json = json.Trim();
            if (json.StartsWith("[") == true && json.EndsWith("]") == true)
            {
                return typeof(Array);
            }
            else if (json.StartsWith("\"") == true && json.EndsWith("\"") == true)
            {
                if (JsonDeserializer.DateTimeDefaultRegex.IsMatch(json) == true)
                {
                    return typeof(DateTime);
                }
                else if (JsonDeserializer.DateTimeFunctionRegex.IsMatch(json) == true)
                {
                    return typeof(DateTime);
                }
                else
                {
                    return typeof(string);
                }
            }
            else if (json.StartsWith("{") == true && json.EndsWith("}") == true)
            {
                return typeof(object);
            }
            else if (json == "true" || json == "false")
            {
                return typeof(bool);
            }
            else if (json == "null")
            {
                return typeof(object);
            }
            else
            {
                if (JsonDeserializer.DateTimeCreateRegex.IsMatch(json) == true)
                {
                    return typeof(DateTime);
                }
                int i;
                if (int.TryParse(json, out i) == true)
                {
                    return typeof(int);
                }
                double d;
                if (double.TryParse(json, out d) == true)
                {
                    return typeof(double);
                }

                return null;
            }
        }
    }
}
