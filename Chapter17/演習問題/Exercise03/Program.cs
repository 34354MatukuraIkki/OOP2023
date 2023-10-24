using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var services = new List<ITextFileService>() {
                new (),
                new (),
                new (),
            };

            //foreach (var obj in greetings) {
            //    string msg = obj.GetMessage();
            //    Console.WriteLine(msg);
            //}
        }
    }
    }
}
