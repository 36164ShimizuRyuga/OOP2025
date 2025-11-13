using TextFileProcessor;
using static System.Collections.Specialized.BitVector32;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("ファイルパスを指定");
            string path = Console.ReadLine();
            TextProcessor.Run<LineCounterProcessor>(path);
        }
    }
}
