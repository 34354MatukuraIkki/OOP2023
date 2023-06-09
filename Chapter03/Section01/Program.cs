﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };

            //５の倍数をカウント
            //int count = numbers.Count(n => n % 5 == 0);

            //偶数の合計値
            var count = numbers.Where(n => n % 2 == 0).Sum();
            
            Console.WriteLine(count);
        }
    }
}
