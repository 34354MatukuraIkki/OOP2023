using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("数字を入力してください");
            var str = Console.ReadLine();
            
            int height;
            
            if (int.TryParse(str, out height)) {
                Console.WriteLine("{0:#,0}",height);
            }
            else {
                Console.WriteLine("変換できません");
            }
        }
    }
}
