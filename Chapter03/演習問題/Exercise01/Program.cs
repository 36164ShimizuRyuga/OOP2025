﻿
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            // 3.1.1
            Exercise1(numbers);
            Console.WriteLine("-----");

            // 3.1.2
            Exercise2(numbers);
            Console.WriteLine("-----");

            // 3.1.3
            Exercise3(numbers);
            Console.WriteLine("-----");

            // 3.1.4
            Exercise4(numbers);
        }

        private static void Exercise1(List<int> numbers) {
            bool exists = numbers.Exists(n => n % 8 == 0 || n % 9 == 0);

            if (exists) {
                Console.WriteLine("存在します。");
            } else {
                Console.WriteLine("存在しません。");
            }
        }


        private static void Exercise2(List<int> numbers) {
            numbers.ForEach(n => Console.WriteLine(n / 2));
            /*  別解
                var waru = numbers.Select(n => n / 2);
               foreach (var n in waru) {
                   Console.WriteLine(n);

               }
            */
        }

        private static void Exercise3(List<int> numbers) {
            numbers.Where(n => n > 50).ToList().ForEach(n => Console.WriteLine(n));
            /* 別解
               var izyou = numbers.Where(n => 50 <= n);
             foreach (var n in izyou) {
                 Console.WriteLine(n);

             }
            */
        }

        private static void Exercise4(List<int> numbers) {
            numbers.Select(n => n * 2).ToList().ForEach(Console.WriteLine);
            /* var bai = numbers.Select(n => n * 2).ToList();
             foreach (var n in bai) {
                 Console.WriteLine(n);
             }
            */
        }
    }
}

