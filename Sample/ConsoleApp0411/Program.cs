using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0411 {
    class Program {
        static void Main(string[] args) {
            string[] moneyString = { "一万円札", "五千円札", "二千円札", "千円札", "五百円玉", "百円玉", "五十円玉", "十円玉", "五円玉", "一円玉" };
            int[] moneyInteger = { 10000, 5000, 2000, 1000, 500, 100, 50, 10, 5, 1 };
            Program obj = new Program();

            Console.Write("金額：");
            int price = int.Parse(Console.ReadLine());

            Console.Write("支払：");
            int pay = int.Parse(Console.ReadLine());

            int backPrice = pay - price;
            Console.WriteLine("お釣:" + backPrice);

            for (int i = 0; i < moneyString.Length; i++)
            {
                Console.Write(moneyString[i] + ":");
                obj.payCount(backPrice / moneyInteger[i]);
                backPrice %= moneyInteger[i];
            }
        }

        private void payCount(int cash) {
            for (int i = 0; i < cash; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
