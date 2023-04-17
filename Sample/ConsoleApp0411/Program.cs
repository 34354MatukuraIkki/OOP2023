using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0411 {
    class Program {
        static void Main(string[] args) {

            string[] moneyString = { "一万円", "五千円", "二千円", "千円", "五百円", "百円", "五十円", "十円", "五円", "一円", };
            int[] moneyInteger = { 10000, 5000, 2000, 1000, 500, 100, 50, 10, 5, 1 };

            Console.Write("合計金額");
            int Total = int.Parse(Console.ReadLine());
            Console.Write("支払い金額");
            int Pay = int.Parse(Console.ReadLine());

            int Money = Pay - Total;

            Console.Write("おつり");
            Console.WriteLine(Money);

            for (int i = 0; i < moneyString.Length; i++)
            {
                //Console.WriteLine(moneyString[i] + ":{0}枚", Money / moneyInteger[i]);
                Console.Write(moneyString[i] + ":");
                astOut(Money / moneyInteger[i]);
                Money %= moneyInteger[i];
            }

            //直角三角
            //for (int i = 0; i < Count; i++)
            //{
            //    //空白を出力
            //    for (int j = 0; j < Count - (i + 1); j++)
            //    {
            //        Console.Write(" ");
            //    }
            //    //＊を出力
            //    for (int k = 0; k < i + 1; k++)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();    //改行
            //}

            //二等辺三角
            //for (int i = 0; i < Count; i++)
            //{
            //    //空白を出力
            //    for (int j = 0; j < i; j++)
            //    {
            //        Console.Write(" ");
            //    }

            //    //＊を出力
            //    for (int k = 0; k < Count - i; k++)
            //    {
            //        Console.Write("*");
            //        Console.Write(" ");

            //        //＊全角でもOK
            //        //Console.Write("＊");
            //    }
            //    Console.WriteLine();    //改行
            //}
        }

        //指定した個数の＊を表示
        private static void astOut(int count) {
            for (int i = 0; i < count; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
