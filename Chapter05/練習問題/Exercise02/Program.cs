using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("数字を入力してください");
            string str = Console.ReadLine();
            Console.WriteLine(int.TryParse(str, out int n));
        }
    }
}
