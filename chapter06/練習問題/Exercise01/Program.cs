﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);
        }

        private static void Exercise1_1(int[] numbers) {
            Console.WriteLine(numbers.Max());
        }

        private static void Exercise1_2(int[] numbers) {
            var reverse = numbers.Reverse();
            foreach (var number in reverse) {
                Console.WriteLine(number);
                if (number == 3)
                    break;
            }
        }

        private static void Exercise1_3(int[] numbers) {
            var strNumbers = numbers.Select(x => x.ToString());
            foreach (var strNum in strNumbers) {
                Console.WriteLine(strNum);
            }
        }

        private static void Exercise1_4(int[] numbers) {
            var smallNumbers = numbers.OrderBy(x => x);
            foreach (var smallNum in smallNumbers.Take(3)) {
                Console.WriteLine(smallNum);
            }
        }

        private static void Exercise1_5(int[] numbers) {
            var number = numbers.Distinct().Count(n => n > 10);
            Console.WriteLine(number);
        }
    }
}
