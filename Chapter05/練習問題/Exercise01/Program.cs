﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("文字列１：");
            var s1 = Console.ReadLine();

            Console.WriteLine("文字列１：");
            var s2 = Console.ReadLine();

            if (string.Compare(s1, s2, ignoreCase: true) == 0)
                Console.WriteLine("等しい");
            else
                Console.WriteLine("等しくない");

        }
    }
}
