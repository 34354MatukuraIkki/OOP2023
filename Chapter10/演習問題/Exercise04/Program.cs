using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            var lines = File.ReadAllLines("sample.txt");
            var pattern = @"[Vv]ersion\s*=\s*""v4.0""";
            
            var replaced = lines.Select(s => Regex.Replace(s, pattern, @"varion=""v5.0"""));

            File.WriteAllLines("sample.txt", replaced);

            // これ以降は確認用
            var text = File.ReadAllText("sample.txt");
            Console.WriteLine(text);
        }
    }
}
