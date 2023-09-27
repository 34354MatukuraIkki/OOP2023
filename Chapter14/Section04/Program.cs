using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {
    class Program {
        static void Main(string[] args) {
            OpenReadSample();
        }
        //List 14.18
        private static void OpenReadSample() {
            var wc = new WebClient();
            using (var stream = wc.OpenRead(@"http://gihyo.jp/book/list"))
            using (var sr = new StreamReader(stream, Encoding.UTF8)) {
                string html = sr.ReadToEnd();
                Console.WriteLine(html);
            }
        }
    }
}
