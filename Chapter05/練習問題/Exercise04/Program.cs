using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            var noveList = "谷崎潤一郎";
            var bestWork = "春琴抄";
            var born = "1886";

            var bookLine = string.Format("作家：={0}代表作：={1}誕生年：={2}", noveList, bestWork, born);
            Console.WriteLine(bookLine);
        }
    }
}
