using System;
using System.Text.RegularExpressions;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private static readonly Regex DateTimeCreateRegex = new Regex(@"^new\s+Date\(\s*(\d*)\s*\)$", RegexOptions.Compiled);

        private static readonly Regex DateTimeDefaultRegex = new Regex(@"^(\d{4})\-(\d{2})\-(\d{2})T(\d{2}):(\d{2}):(\d{2})(\.\d*)?([\+|\-]\d{2}:\d{2})?$", RegexOptions.Compiled);

        private static readonly Regex DateTimeFunctionRegex = new Regex(@"^\\/Date\((\d+)\)\\/$", RegexOptions.Compiled);

        private DateTime DeserializeToDateTime(string input, Type type)
        {
            Match match;
            match = DateTimeCreateRegex.Match(input);
            if (match.Success == true)
            {
                string sms = match.Groups[1].Value;
                double ms;
                if (double.TryParse(sms, out ms) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                return new DateTime(1970, 1, 1, 8, 0, 0).AddMilliseconds(ms);
            }
            match = DateTimeDefaultRegex.Match(input);
            if (match.Success == true)
            {
                string syear = match.Groups[1].Value;
                string smonth = match.Groups[2].Value;
                string sday = match.Groups[3].Value;
                string shour = match.Groups[4].Value;
                string sminute = match.Groups[5].Value;
                string ssecond = match.Groups[6].Value;
                string sms = match.Groups[7].Value;
                string szone = match.Groups[8].Value;

                int year;
                int month;
                int day;
                int hour;
                int minute;
                int second;
                double ms;

                if (int.TryParse(syear, out year) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                if (int.TryParse(smonth, out month) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                if (int.TryParse(sday, out day) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                if (int.TryParse(shour, out hour) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                if (int.TryParse(sminute, out minute) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                if (int.TryParse(ssecond, out second) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                if (double.TryParse("0" + sms, out ms) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }

                if (szone.Length == 0)
                {
                    return new DateTime((new DateTime(year, month, day, hour, minute, second)).Ticks + (long)(ms * 10000000));
                }
                else
                {
                    return new DateTime((new DateTime(year, month, day, hour, minute, second)).Ticks + (long)(ms * 10000000), DateTimeKind.Local);
                }
            }
            match = DateTimeFunctionRegex.Match(input);
            if (match.Success == true)
            {
                string sms = match.Groups[1].Value;
                double ms;
                if (double.TryParse(sms, out ms) == false)
                {
                    throw new JsonDeserializeException(input, type);
                }
                return new DateTime(1970, 1, 1, 8, 0, 0).AddMilliseconds(ms);
            }
            throw new JsonDeserializeException(input, type);
        }
    }
}
