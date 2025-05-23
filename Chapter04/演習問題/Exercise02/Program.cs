using System;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1();
            Console.WriteLine("---");
            Exercise2();
            Console.WriteLine("---");
            Exercise3();
        }

        private static void Exercise1() {
            var line = Console.ReadLine();
            var num = int.Parse(line);
            if (num < 0) {
                Console.WriteLine(num);
            } else if(num>=0&&num<100) {
                Console.WriteLine(num * 2);
            }else if (num >= 100 && num < 500) {
                Console.WriteLine(num * 3);
            } else {
                Console.WriteLine(num);
            }

        }

        private static void Exercise2() {
            
        }

        private static void Exercise3() {
            
        }
    }
}
