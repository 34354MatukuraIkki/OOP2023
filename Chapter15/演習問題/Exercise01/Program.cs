using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var maxPrice = Library.Books.First(b=>b.Price==Library.Books.Max(m => m.Price));
            Console.WriteLine(maxPrice);
        }

        private static void Exercise1_3() {
            var countPublishedYear = Library.Books.GroupBy(b => b.PublishedYear).Select(g=>g.OrderBy(b=>b.Title).Count());
            foreach (var book in countPublishedYear) {
                Console.WriteLine(book);
            }
        }

        private static void Exercise1_4() {
            var selected = Library.Books.OrderByDescending(b => b.PublishedYear).ThenByDescending(b => b.Price);
            foreach (var book in selected) {
                Console.WriteLine(book);
            }
        }

        private static void Exercise1_5() {
            var names = Library.Books.Where(b => b.PublishedYear == 2016)
                .Join(Library.Categories,
                    book => book.CategoryId,
                    category => category.Id,
                    (book, category) => category.Name).Distinct();

            foreach (var name in names) {
                Console.WriteLine(name);
            }
        }

        private static void Exercise1_6() {
            
        }

        private static void Exercise1_7() {
        
        }

        private static void Exercise1_8() {
        
        }
    }
}
