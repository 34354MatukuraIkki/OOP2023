using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {

    class Program {
        static void Main(string[] args) {

            #region P26のサンプルプログラム
            //インスタンスの生成
            //Product karinto = new Product(123, "かりんとう", 180);
            //Product daihuku = new Product(235, "大福もち", 160);

            //Console.WriteLine("かりんとうの税込価格：" + karinto.GetPriceIncludingTax());
            //Console.WriteLine("大福もちの税込価格：" + daihuku.GetPriceIncludingTax());
            #endregion

            #region 演習１
            ////DateTime date = new DateTime(2023, 5, 8);
            //DateTime date = DateTime.Today;
            //Console.WriteLine("今日の日付：" + date.Year + "年" + date.Month + "月" + date.Day + "日");

            ////10日後を求める
            //DateTime daysAfter10 = date.AddDays(10);
            //Console.WriteLine("10日後は" + daysAfter10.Year + "年" + daysAfter10.Month + "月" + daysAfter10.Day + "日です。");
            ////10日前を求める
            //DateTime daysBefor10 = date.AddDays(-10);
            //Console.WriteLine("10日前は" + daysBefor10.Year + "年" + daysBefor10.Month + "月" + daysBefor10.Day + "日です。");
            #endregion

            Console.WriteLine("誕生日を入力してください。");
            Console.Write("西暦：");
            int birthYear  = int.Parse(Console.ReadLine());
            Console.Write("月：");
            int birthMonth = int.Parse(Console.ReadLine());
            Console.Write("日：");
            int birthDay   = int.Parse(Console.ReadLine());

            DateTime today      = DateTime.Today;
            DateTime birthday   = new DateTime(birthYear, birthMonth, birthDay);

            TimeSpan difference = today - birthday;
            Console.WriteLine("あなたが生まれてから今日まで" + difference.Days + "日目です。");
        }
    }
}
