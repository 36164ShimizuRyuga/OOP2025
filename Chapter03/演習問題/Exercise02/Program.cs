﻿
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(cities);
            Console.WriteLine();

        }

         static void Exercise2_1(List<string> names) {
            while (true) {
                Console.WriteLine("都市名を入力。");
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) {
                    break;
                } else {
                    int index = names.FindIndex(s => s == name);
                    Console.WriteLine(index);
                }
            }
        }

        private static void Exercise2_2(List<string> names) {
            var count = names.Count(s => s.Contains('o'));
            Console.WriteLine(count);
        }

        private static void Exercise2_3(List<string> names) {
            var list = names.Where(s => s.Contains('o')).ToArray();
            foreach (var name in list) {
                Console.WriteLine(name);
            }
           
        }

        private static void Exercise2_4(List<string> names) {
            var obj = names.Where(s => s.StartsWith('B'))
                                .Select(s => new {s,s.Length});

            foreach (var count in obj) {
                Console.WriteLine(count);

            }
        }
    }
}
