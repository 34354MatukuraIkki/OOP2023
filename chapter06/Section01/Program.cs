using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };
            Console.WriteLine(numbers.Average());

            var books = Books.GetBooks();

            var date = books.Where(x => x.Title.Contains("物語")).OrderByDescending(x => x.Price);
            foreach (var book in date) {
                Console.WriteLine("{0}: {1}円", book.Title, book.Price);
            }

            var page = books.Where(x => x.Title.Contains("物語")).Average(x=>x.Pages);
            Console.WriteLine("平均ページ数 = {0}", page);

            var title = books.OrderByDescending(x => x.Title.Length);
            foreach (var book in title) {
                Console.WriteLine(book.Title);
            }
        }
    }
}
