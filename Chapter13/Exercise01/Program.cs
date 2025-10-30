
using System.Linq;

namespace Exercise01 {
    internal class Program {
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
            Console.WriteLine("(2)");
            var book = Library.Books.MaxBy(b => b.Price);
            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
            Console.WriteLine("(3)");
            var year = Library.Books
                .GroupBy(b => b.PublishedYear)
                .Select(g => new {
                    Year = g.Key,
                    Count = g.Count()
                })
                .OrderBy(b => b.Year);

            foreach (var item in year) {
                Console.WriteLine($"{item.Year}年:{item.Count}");
            }
        }

        private static void Exercise1_4() {
            var book = Library.Books
                .OrderByDescending(b => b.PublishedYear)
                .ThenByDescending(b => b.Price);

            foreach (var item in book) {
                Console.WriteLine($"{item.PublishedYear}年 {item.Price}円 {item.Title}");
            }
        }

        private static void Exercise1_5() {
            var bookyear = Library.Books
                .Where(b => b.PublishedYear == 2022)
                .Join(Library.Categories
                                 , book => book.CategoryId
                                 , Category => Category.Id
                                 , (book, category) => category.Name);
            foreach (var item in bookyear) {
                Console.WriteLine(item);

            }




        }

        private static void Exercise1_6() {
            var groupedBooks = Library.Books
                            .Join(Library.Categories,
                                b => b.CategoryId,
                                c => c.Id,
                                (b, c) => new {
                                    CategoryName = c.Name,
                                    b.Title
                                }
                            )
                            .GroupBy(x => x.CategoryName)
                            .OrderBy(x => x.Key);
            foreach (var group in groupedBooks) {
                Console.WriteLine($"#{group.Key}");
                foreach (var book in group) {
                    Console.WriteLine($"　{book.Title}");

                }
            }
        }

        private static void Exercise1_7() {
            var categoryYear = Library.Categories
                .Where(x => x.Name.Equals("Development"))
                .Join(Library.Books,
                                c => c.Id,
                                b => b.CategoryId,
                                (c, b) => new {
                                    b.Title,
                                    b.PublishedYear

                                })
                .GroupBy(b => b.PublishedYear)
                .OrderBy(g => g.Key);

            foreach (var item in categoryYear) {
                Console.WriteLine($"#{item.Key}年");
                foreach (var book in item) {
                    Console.WriteLine($"  {book.Title}");
                }
            }
        }

        private static void Exercise1_8() {
            var categoryNames = Library.Categories
                        .GroupJoin(Library.Books,
                        c => c.Id,
                        b => b.CategoryId,
                        (c, books) => new {
                            Category = c.Name,
                            BookCount = books.Count(),
                        })
                        .Where(x => x.BookCount >= 4);
            foreach (var item in categoryNames) {
                Console.WriteLine(item);
            }


        }
    }
}
