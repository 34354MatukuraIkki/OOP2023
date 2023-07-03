using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var date = DateTime.Now;
            DateTime nextDayOfWeek = NextDay(date, DayOfWeek.Monday);
            Console.WriteLine("{0:yyyy/M/d}の次週の{1}: {2:yyyy/M/d}", date, date.DayOfWeek,nextDayOfWeek);
        }
        public static DateTime NextDay(DateTime date,DayOfWeek dayOfWeek) {
            var days = (int)dayOfWeek - (int)(date.DayOfWeek);
            if (days <= 0)
                days += 7;
            return date.AddDays(days);
        }
    }
}
