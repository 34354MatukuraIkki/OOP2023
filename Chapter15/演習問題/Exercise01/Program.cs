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
            var countPublishedYear = Library.Books.GroupBy(b => b.PublishedYear)
                                   .Select(g => new { PublishedYear = g.Key, Count = g.Count() })
                                   .OrderBy(p => p.PublishedYear);
            foreach (var book in countPublishedYear) {
                Console.WriteLine($"{book.PublishedYear}年 {book.Count}冊");
            }
        }

        private static void Exercise1_4() {
            var selected = Library.Books
                                .OrderByDescending(b=>b.PublishedYear)
                                .ThenByDescending(b=>b.Price)
                                .Join(Library.Categories,
                                book => book.CategoryId,
                                category => category.Id,
                                (book, category) => new { 
                                    Title = book.Title,
                                    Price = book.Price,
                                    Category = category.Name,
                                    PublishedYear = book.PublishedYear });
            foreach (var book in selected) {
                    Console.WriteLine($"{book.PublishedYear}年 {book.Price}円 {book.Title} ({book.Category})");
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
            var groups = Library.Categories
                                .OrderBy(c=>c.Name)
                                .GroupJoin(Library.Books,
                                 c => c.Id,
                                 b => b.CategoryId,
                                 (c, books) => new { Category = c.Name, Books = books });
            
            foreach (var g in groups) {
                Console.WriteLine($"#{g.Category}");
                foreach (var book in g.Books) {
                    Console.WriteLine($" {book.Title}");
                }
            }
        }

        private static void Exercise1_7() {
            var categoryId = Library.Categories.Single(c => c.Name == "Development").Id;
            var groups = Library.Books
                                .Where(b => b.CategoryId == categoryId)
                                .GroupBy(b => b.PublishedYear)
                                .OrderBy(b => b.Key);
            
            foreach (var g in groups) {
                Console.WriteLine($"#{g.Key}年");
                foreach (var book in g) {
                    Console.WriteLine($" {book.Title}");
                }
            }
        }

        private static void Exercise1_8() {
            var groups = Library.Categories
                                .GroupJoin(Library.Books,
                                 c => c.Id,
                                 b => b.CategoryId,
                                 (c, b) => new { CategoryName = c.Name, Count = b.Count() })
                                .Where(x => x.Count >= 4);
            
            foreach (var category in groups) {
                Console.WriteLine(category.CategoryName);
            }
        }
    }
}
