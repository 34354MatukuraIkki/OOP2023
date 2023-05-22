using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var sales = new SalesCounter(@"date\sales.csv");

            Console.WriteLine("＊＊売上集計＊＊");
            Console.WriteLine("1：店舗別売上");
            Console.WriteLine("2：商品カテゴリ別売上");
            Console.Write("＞");

            if (int.Parse(Console.ReadLine())==1) {
                var amountPerStore = sales.GetPerStoreSales();
                foreach (var obj in amountPerStore) {
                    Console.WriteLine("{0} {1:C}", obj.Key, obj.Value);
                }
            }
            else {
                var amountPerCategory = sales.GetPerCategorySales();
                foreach (var obj in amountPerCategory) {
                    Console.WriteLine("{0} {1:C}", obj.Key, obj.Value);
                }
            }
        }
    }
}
