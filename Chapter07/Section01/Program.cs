using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            //var flowerDict = new Dictionary<string, int>(){
            //    ["sunflower"] = 400,
            //    ["pansy"] = 300,
            //    ["tulip"] = 350,
            //    ["rose"] = 500,
            //    ["dahlia"] = 450,
            //};

            ////あさがお２５０円追加
            //flowerDict["morning glory"] = 250;

            //Console.WriteLine("ひまわりの価格は{0}円です。", flowerDict["sunflower"]);
            //Console.WriteLine("チューリップの価格は{0}円です。", flowerDict["tulip"]);
            //Console.WriteLine("あさがおの価格は{0}円です。", flowerDict["morning glory"]);

            var Dict = new Dictionary<string, string>() {
            };

            string place,location;

            while (true) {
                Console.WriteLine("県庁所在地の登録");
                Console.Write("県名：");
                place = Console.ReadLine();
                if (place == "９９９")
                    break;
                if (Dict.ContainsKey(place))
                    Console.WriteLine("すでに登録してあります。");
                else
                    Console.Write("所在地：");
                location = Console.ReadLine();
                Dict[place] = location;
            }
            Console.Write("県名を入力：");
            var search = Console.ReadLine();
            Console.WriteLine("{0}です。", Dict[search]);
        }
    }
}
