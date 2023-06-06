
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
#if true
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


#endif
        }
    }
}
