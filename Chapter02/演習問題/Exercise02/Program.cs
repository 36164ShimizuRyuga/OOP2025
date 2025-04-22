using System.Security.Cryptography;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            double inchToMeter = 0.0254;

            //1から１０のループ
            for (int inch = 1; inch <= 10; inch++) {
                double meter = inch * inchToMeter;
                Console.WriteLine($"{inch}インチ = {meter:0.0000}m");
            }
        }
    }
}
