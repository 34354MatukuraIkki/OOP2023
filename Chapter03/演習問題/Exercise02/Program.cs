using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                 "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            Console.WriteLine("＊＊＊＊３．１＊＊＊＊");
            Exercise2_1(names);
            Console.WriteLine();
            Console.WriteLine("＊＊＊＊３．２＊＊＊＊");
            Exercise2_2(names);
            Console.WriteLine();
            Console.WriteLine("＊＊＊＊３．３＊＊＊＊");
            Exercise2_3(names);
            Console.WriteLine();
            Console.WriteLine("＊＊＊＊３．４＊＊＊＊");
            Exercise2_4(names);
        }

        private static void Exercise2_1(List<string> names) {
            do {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;

                var index = names.FindIndex(s => s == line);
                Console.WriteLine(index);
            } while (true);
        }

        private static void Exercise2_2(List<string> names) {
            var count = names.Count(s => s.Contains("o"));
            Console.WriteLine(count);
        }

        private static void Exercise2_3(List<string> names) {
            var cityName = names.FindAll(s => s.Contains("o"));
            foreach (var city in cityName) {
                Console.WriteLine(city);
            }
        }

        private static void Exercise2_4(List<string> names) {
            var cities = names.Where(s => s.StartsWith("B")).Select(s => s.Length);
            foreach (var city in cities) { 
                Console.WriteLine(city);
            }
        }
    }
}
