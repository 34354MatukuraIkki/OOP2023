using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {

            var prefDict = new Dictionary<string, List<CityInfo>>();
            string pref, city;
            int population;

            Console.WriteLine("都市の登録");
            while (true) {
                Console.Write("県名：");
                pref = Console.ReadLine();
                if (pref == "999") break;

                Console.Write("市町村：");
                city = Console.ReadLine();

                Console.Write("人口：");
                population = int.Parse(Console.ReadLine());

                var cities = new CityInfo
                {
                    City = city,
                    Population=population
                };

                //既に県名が登録済みか？
                if (prefDict.ContainsKey(pref)) {
                    prefDict[pref].Add(cities);
                }
                else{
                    prefDict[pref] = new List<CityInfo> { cities };
                }
            }

            Console.WriteLine();
            Console.WriteLine("1:一覧表示,2:県名指定");
            Console.Write(">");
            var selected = Console.ReadLine();

            if (selected == "1") {
                //一覧表示
                foreach (var item in prefDict) {
                    foreach (var term in item.Value) {
                    Console.WriteLine("{0}【{1}(人口：{2}人)】", item.Key, term.City, term.Population);
                    }
                }
            }
            else {
                //県名指定表示
                Console.Write("県名を入力：");
                var inputPref = Console.ReadLine();
                foreach (var item in prefDict[inputPref]) {
                Console.WriteLine("{0}【{1}(人口：{2}人)】", inputPref, item.City, item.Population);
                }
            }
        }
    }
}

class CityInfo {
    public string City { get; set; }        //都市
    public int Population { get; set; }     //人口
}

