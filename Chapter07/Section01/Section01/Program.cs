namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var books = Books.GetBooks();

            //1本の平均価格
            Console.WriteLine(books.Average(x => x.Price));
            Console.WriteLine("");

            //2本のページ合計表示
            Console.WriteLine(books.Sum(n => n.Pages));
            Console.WriteLine("");

            //3金額の安い書籍名と金額
            var mbook = books.Where(x => x.Price == books.Min(b => b.Price));
            foreach (var item in mbook) {
                Console.WriteLine(item.Price + " , " + item.Title);
            }
            Console.WriteLine("");

            //4ページが多い書籍名とページ数
            var mPages = books.Where(x => x.Pages == books.Max(b => b.Pages));
            foreach (var item in mPages) {
                Console.WriteLine(item.Pages + " , " + item.Title);
            }
            Console.WriteLine("");


            //5タイトルに「物語」が含まれる書籍名をすべて表示
            var tales = books.Where(b => b.Title.Contains("物語"));
            foreach (var book in tales) {
                Console.WriteLine(book.Title);

            }

        }
    }
}
