using System.Security.Cryptography;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("***　変換アプリ　***");
            Console.WriteLine("1:インチからメートル");
            Console.WriteLine("2:メートルからインチ");
            Console.WriteLine("1か2を入力してください");
            int number = int.Parse(Console.ReadLine());
            

            Console.Write("はじめ：");
            int start = int.Parse(Console.ReadLine());
            Console.Write("おわり：");
            int end = int.Parse(Console.ReadLine());

            if( number == 1) {
                PrintInchToMeterList(start, end);
            } else if(number == 2) {
                PrintMeterToInchList(start, end);
            } else {
                Console.WriteLine("エラー");
            }
            

            

            //インチからメートルの1から１０のループ
            static void PrintInchToMeterList(int start,int end) {
                double inchToMeter = 0.0254;
                for (int inch = start; inch <= end; inch++) {
                    double meter = inch * inchToMeter;
                    Console.WriteLine($"{inch}インチ = {meter:0.0000}m");
                }
            }

            //メートルからインチの１から１０のループ
            static void PrintMeterToInchList(int start, int end) {
                double inchToMeter = 0.0254;
                for (int meter = start; meter <= end; meter++) {
                    double inch = meter / inchToMeter;
                    Console.WriteLine($"{meter}m = {inch:0.0000}インチ");
                }
            }
        }
    }
}
