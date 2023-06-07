﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
    class Program {
        static void Main(string[] args) {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var numbers = Enumerable.Range(1, 1000000).ToArray();
            WriteTotalMemory("配列確保後");

            var evenNumbers = numbers.Where(n => n % 2 == 0);

            WriteTotalMemory("偶数抽出後");
            //foreach (var number in evenNumbers) {
            //    Console.WriteLine(number);
            //}

            var ave = evenNumbers.Average();
            WriteTotalMemory("偶数抽出後平均");

            Console.WriteLine("実行時間" + sw.Elapsed.ToString(@"ss\.ffff"));
        }

        static void WriteTotalMemory(string header) {
            var totalMemory = GC.GetTotalMemory(true) / 1024.0 / 1024.0;
            Console.WriteLine($"{header}: {totalMemory:0.000 MB}");
        }
    }
}
