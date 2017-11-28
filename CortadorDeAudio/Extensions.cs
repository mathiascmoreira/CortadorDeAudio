using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CortadorDeAudio
{
    public static class Extensions
    {
        private const string stringFormat = "mm':'ss':'ffff";

        public static string ToStringFormat(this TimeSpan time)
        {
            return time.ToString(stringFormat);
        }

        public static TimeSpan ToTimeSpan(this string time)
        {
            return TimeSpan.ParseExact(time, stringFormat, CultureInfo.InvariantCulture);
        }
    }
}
