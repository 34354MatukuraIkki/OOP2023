using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
#if false
            var line = "NoveList=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var texts = line.Split(';');
            string[] words = { "NoveList=", "BestWork=", "Born=" };
            string[] label = { "作家　：", "代表作：", "誕生年：" };
            int num = 0;
            foreach (var word in texts) {
                var index = word.IndexOf(words[num]) + words[num].Length;
                Console.WriteLine(label[num] + word.Substring(index));
                num++;
            }

#else
            string[] lines = {
                "NoveList=谷崎潤一郎;BestWork=春琴抄;Born=1886",
                "NoveList=夏目漱石;BestWork=坊ちゃん;Born=1867",
                "NoveList=太宰治;BestWork=人間失格;Born=1909",
                "NoveList=宮沢賢治;BestWork=銀河鉄道の夜;Born=1896",
            };

            //string[] texts = { };

            //foreach (var item in lines) {
            //    texts = item.Split(';');
            //}

            //string[] words = { "NoveList=", "BestWork=", "Born=" };
            //string[] label = { "作家　：", "代表作：", "誕生年：" };
            //int num = 0;
            //int labelNum = 0;
            //foreach (var word in texts) {
            //    var index = word.IndexOf(words[num]) + words[num].Length;
            //    Console.WriteLine(label[num] + word.Substring(index));
            //    num++;
            //    labelNum++;
            //    if (labelNum == 4)
            //        labelNum = 0;
            //    }

            foreach (var line in lines) {
                foreach (var pair in line.Split(';')) {
                    var array = pair.Split('=');
                    Console.WriteLine("{0},{1}", ToJapanese(array[0]), array[1]);
                }
            }
#endif
            Console.WriteLine("実行時間" + sw.Elapsed.ToString(@"ss\.ffff"));
        }

        static string ToJapanese(string key) {
            switch (key) {
                case "NoveList":
                    return "作家　：";
                case "BestWork":
                    return "代表作：";
                case "Born":
                    return "誕生年：";

            }
            throw new AggregateException("正しい引数ではありません");
        }
    }
}
