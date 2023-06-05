﻿using System;
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
            int count = 0;
            foreach (var str in text) {
                if (String.IsNullOrWhiteSpace(str.ToString()))
                    count++;
            }
            Console.WriteLine(count);
        }

        private static void Exercise3_2(string text) {
            var target = text;
            var replaced = target.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3_3(string text) {
            string[] words = text.Split(' ');
            Console.WriteLine(words.Length);
        }

        private static void Exercise3_4(string text) {
            string[] words = text.Split(' ');
            foreach (var word in words) {
                if (word.Length < 5)
                    Console.WriteLine(word);
            }
        }

        private static void Exercise3_5(string text) {
        
        }
    }
}
