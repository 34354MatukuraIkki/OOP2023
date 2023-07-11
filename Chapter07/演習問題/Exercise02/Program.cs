using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            //コンストラクタ呼び出し
            var abbrs = new Abbreviations();

            //Addメソッド
            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核拡散防止条約");

            //7.2.3
            //上のAddメソッドで、２つのオブジェクトを追加しているので読み込んだ単語数+2が、Countの値になる
            Console.WriteLine(abbrs.Count);
            Console.WriteLine();
            //7.2.3(Removeの呼び出し)
            if (abbrs.Remove("IOC")) 
                Console.WriteLine(abbrs.Count);
            if (!abbrs.Remove("IOc"))
                Console.WriteLine("削除できません");
            Console.WriteLine();

            //7.2.4
            //IEnumerable<>を実装したのでLINQが使える
            foreach (var item in abbrs.Where(abb => abb.Key.Length == 3)) {
            Console.WriteLine("{0}={1}", item.Key, item.Value);
            }
        }
    }
}
