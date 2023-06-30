using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var dateTime = DateTime.Now;
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
            DisplayDatePattern3_2(dateTime);
        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            var day = string.Format("{0:yyyy/M/d HH:mm}", dateTime);
            Console.WriteLine(day);
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            var day = dateTime.ToString("yyyy年MM月dd日 HH時mm分ss秒");
            Console.WriteLine(day);
        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = dateTime.ToString("ggyy年M月d日", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);
            Console.WriteLine("{0}({1})",str,dayOfWeek);
        }

        private static void DisplayDatePattern3_2(DateTime dateTime) {
           
        }
    }
}
