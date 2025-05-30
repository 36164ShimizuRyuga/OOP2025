using System.Globalization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("str1:");
            var str1 = Console.ReadLine();
            Console.Write("str2:");
            var str2 = Console.ReadLine();

            var cultureInfo = new CultureInfo("ja-JP");
            if (String.Compare(str1, str2, cultureInfo, CompareOptions.IgnoreKanaType) == 0) {
                Console.WriteLine("一致しています");
            }
        }
    }
}
