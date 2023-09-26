﻿using SampleEntityFrameWork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFrameWork {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("# 1.1");
            Exercise1_1();

            Console.WriteLine();
            Console.WriteLine("# 1.2");
            Exercise1_2();

            Console.WriteLine();
            Console.WriteLine("# 1.3");
            Exercise1_3();

            Console.WriteLine();
            Console.WriteLine("# 1.4");
            Exercise1_4();

            Console.WriteLine();
            Console.WriteLine("# 1.5");
            Exercise1_5();

            Console.ReadLine();

            //InsertBooks();
            //Console.Write("データを挿入しました。続けるにはEnterキーを押してください。");

            //AddAuthors();
            //AddBooks();
            //DisplayAllBooks();
            //UpdateBook();
            //DeleteBook();

            //foreach (var book in GetBooks()) {
            //    Console.WriteLine($"{book.Title}{book.Author.Name}");
            //}

            //using (var db = new BooksDbContext()) {

            //    db.Database.Log = sql => { Debug.Write(sql); };

            //    var count = db.Books.Count();
            //    Console.WriteLine(count);
            //}

            //Console.ReadLine();     //コンソール画面をすぐに消さないためにキー入力待ちにする
            //Console.WriteLine();
        }

        private static void Exercise1_1() {
            //AddAuthors();
            //AddBooks();
        }

        private static void Exercise1_2() {
            DisplayAllBooks();
        }

        private static void Exercise1_3() {
            using (var db = new BooksDbContext()) {
                var books = db.Books.Where(t => t.Title.Length == db.Books.Max(s => s.Title.Length))
                    .ToArray();
                foreach (var book in books) {
                    Console.WriteLine(book.Title);
                }
            };
        }

        private static void Exercise1_4() {
            using (var db = new BooksDbContext()) {
                var books = db.Books.OrderBy(b => b.PublishedYear).ToArray();
                for (int i = 0; i < 3; i++) {
                    Console.WriteLine($"{books[i].Title},{books[i].Author.Name}");
                }
            };
        }

        private static void Exercise1_5() {
            using (var db = new BooksDbContext()) {
                var authors = db.Authors.OrderByDescending(b => b.Birthday).ToArray();
                foreach (var author in authors) {
                Console.WriteLine($"{author.Name}");
                    foreach (var book in author.Books) {
                        Console.WriteLine($"{book.Title},{book.PublishedYear}");
                    }
                    Console.WriteLine();
                }
            }
        }

        // List 13-5
        static void InsertBooks() {
            using (var db = new BooksDbContext()) {
                var book1 = new Book {
                    Title = "坊ちゃん",
                    PublishedYear = 2003,
                    Author = new Author {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };
                db.Books.Add(book1);
                var book2 = new Book {
                    Title = "人間失格",
                    PublishedYear = 1990,
                    Author = new Author {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治",
                    }
                };
                db.Books.Add(book2);
                db.SaveChanges();   //データベースを更新
                Console.WriteLine($"{book1.Id}{book2.Id}");
            }
        }

        // List 13-7
        static IEnumerable<Book> GetBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books
                    .Where(book => book.PublishedYear > 1900)
                    .Include(nameof(Author))
                    .ToList();
            }
        }

        // List 13-8
        static void DisplayAllBooks() {
            var books = GetBooks();
            foreach (var book in books) {
                Console.WriteLine($"{book.Title},{book.PublishedYear},{book.Author.Name}");
            }
            Console.ReadLine(); //コンソール画面をすぐに消さないためにキー入力待ちにする
        }

        // List 13-9
        private static void AddAuthors() {
            using (var db = new BooksDbContext()) {
                var author1 = new Author {
                    Birthday = new DateTime(1888, 12, 26),
                    Gender = "M",
                    Name = "菊池寛",
                };
                db.Authors.Add(author1);
                var author2 = new Author {
                    Birthday = new DateTime(1899, 6, 14),
                    Gender = "M",
                    Name = "川端康成",
                };
                db.Authors.Add(author2);
                db.SaveChanges();
            }
        }

        // List 13-10
        private static void AddBooks() {
            using (var db = new BooksDbContext()) {
            var searchAuthor1 = db.Authors.Single(a => a.Name == "夏目漱石");
            var book1 = new Book {
                Title = "こころ",
                PublishedYear = 1991,
                Author = searchAuthor1,
            };
            db.Books.Add(book1);
            var searchAuthor2 = db.Authors.Single(a => a.Name == "川端康成");
            var book2 = new Book {
                Title = "伊豆の踊子",
                PublishedYear = 2003,
                Author = searchAuthor2,
            };
            db.Books.Add(book2);
            var searchAuthor3 = db.Authors.Single(a => a.Name == "菊池寛");
            var book3 = new Book {
                Title = "真珠夫人",
                PublishedYear = 2002,
                Author = searchAuthor3,
            };
            db.Books.Add(book3);
            var searchAuthor4 = db.Authors.Single(a => a.Name == "宮沢賢治");
            var book4 = new Book {
                Title = "注文の多い料理店",
                PublishedYear = 2000,
                Author = searchAuthor4,
            };
            db.Books.Add(book4);
            db.SaveChanges();
        }
        }

        // List 13-11
        private static void UpdateBook() {
            using (var db = new BooksDbContext()) {
                var book = db.Books.Single(x => x.Title == "銀河鉄道の夜");
                book.PublishedYear = 2016;
                db.SaveChanges();
            }
        }

        // List 13-12
        private static void DeleteBook() {
            using (var db = new BooksDbContext()) {
                var book = db.Books.SingleOrDefault(x => x.Id == 10);
                if (book != null) {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }
    }
}
