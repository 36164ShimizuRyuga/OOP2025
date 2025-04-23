using System.Diagnostics.Metrics;

namespace YardConverter {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("***　変換アプリ　***");
            Console.WriteLine("1:ヤードからメートル");
            Console.WriteLine("2:メートルからヤード");
            Console.WriteLine("1か2を入力してください");
            int number = int.Parse(Console.ReadLine());

            if (number == 1) {
                Console.Write("返還前(ヤード:");
                int yard = int.Parse(Console.ReadLine());
                PrintYardToMeterList(yard);
            } else if (number == 2) {
                Console.Write("返還前(メートル):");
                int meter = int.Parse(Console.ReadLine());
                PrintMeterToYardList(meter);
            }

            static void PrintYardToMeterList(int yard) {
                double meter = yard * 0.9144;
                Console.Write($"変更後(メートル):{meter}m");
            }

            static void PrintMeterToYardList(int meter) {
                double yard = meter / 0.9144;
                Console.Write($"変換後(ヤード):{yard}ヤード");

            }






        }
    }
}
