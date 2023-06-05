using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
            //{\rtf1}
        }

        private static void Exercise3_1(string text) {
            //int count = 0;
            //foreach (var str in text) {
            //    if (string.IsNullOrWhiteSpace(str.ToString()))
            //        count++;
            //}

            int count = text.Count(s => s.ToString().Contains(' '));
            //int count = text.Count(c => c == ' ');

            Console.WriteLine("空白数：" + count);
        }

        private static void Exercise3_2(string text) {
            var target = text;  //省略可
            var replaced = target.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3_3(string text) {
            string[] words = text.Split(' ');
            Console.WriteLine("単語数：" + words.Length);
        }

        private static void Exercise3_4(string text) {
            string[] words = text.Split(' ');
            foreach (var word in words) {
                if (word.Length < 5)
                    Console.WriteLine(word);
            }

            //string[] words = text.Split(' ').Where(word => word.Length <= 4);
            //foreach (var word in words)
                //Console.WriteLine(word);
        }

        private static void Exercise3_5(string text) {
            string[] words = text.Split(' ');

            if (words.Length > 0) {
                var sb = new StringBuilder();
                foreach (var word in words) {
                    if (word != words[0]) {
                        sb.Append(' ');
                        sb.Append(word);
                    }
                    else
                        sb.Append(word);
                }
                var texts = sb.ToString();
                Console.WriteLine(texts);
            }

            //var array = text.Split(' ').ToArray();
            //var sb = new StringBuilder(words[0]);
            //foreach (var word in words.Skip(1)) {
            //    if (word != words[0]) {
            //        sb.Append(' ');
            //        sb.Append(word);
            //    }
            //    else
            //        sb.Append(word);
            //}
        }
    }
}
