using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var date = DateTime.Now;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {
                var dayOfWeek = culture.DateTimeFormat.GetDayName((DayOfWeek)dayofweek);
                DateTime nextDayOfWeek = NextDay(date, (DayOfWeek)dayofweek);
                Console.WriteLine("{0:yyyy/M/d}の次週の{1}: {2:yyyy/M/d} ({3})", date, dayofweek, nextDayOfWeek, dayOfWeek);
            }
        }
        public static DateTime NextDay(DateTime date,DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            if (days <= 0)
                days += 7;
            return date.AddDays(days);
        }
    }
}
