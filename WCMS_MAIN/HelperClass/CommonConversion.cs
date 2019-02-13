using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WCMS_MAIN.HelperClass
{
    public static class CommonConversion
    {
        public static string AddOrdinal(int? num = 0)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }

        }
        public static string ToPrettyFormat(TimeSpan span)
        {

            if (span == TimeSpan.Zero) return "0 minutes";

            var sb = new StringBuilder();
            if (span.Days > 0)
                sb.AppendFormat("{0} d", span.Days);
            else if (span.Hours > 0)
                sb.AppendFormat("{0} h", span.Hours);
            else if (span.Minutes > 0)
                sb.AppendFormat("{0} m", span.Minutes);
            else
            {
                sb.AppendFormat("a m. ago");
            }
            return sb.ToString();

        }
    }
}