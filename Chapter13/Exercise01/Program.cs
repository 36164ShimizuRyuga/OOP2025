
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
                    Count =g.Count()
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
            
        }

        private static void Exercise1_6() {
            
        }

        private static void Exercise1_7() {
            
        }

        private static void Exercise1_8() {
            
        }
    }
}
