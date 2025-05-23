
using System.ComponentModel.DataAnnotations;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
    "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
    "JavaScript", "Swift", "Go",
];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        private static void Exercise1(List<string> langs) {
            //foreach文
            var obj = langs.Where(s => s.Contains('S')).ToArray();
            foreach (var lang in obj) {
                Console.WriteLine(lang);
            }
            Console.WriteLine("");
            //for文
            for (var i = 0; i < langs.Count; i++) {
                if (langs[i].Contains('S')) {
                    Console.WriteLine(langs[i]);

                }
                Console.WriteLine("");
            }
            //while文
            int s = 0;
            while (s < langs.Count) {
                if (langs[s].Contains('S')) {
                    Console.WriteLine(langs[s]);
                }
                s++;
            }


        }

        private static void Exercise2(List<string> langs) {
            var obj = langs.Where(s => s.Contains('S')).ToArray();
            foreach (var lang in obj) {
                Console.WriteLine(lang);
            }

        }

        private static void Exercise3(List<string> langs) {
            var find = langs.Find(s => s.Length == 10).ToList();
            if (find is null) {
                Console.Write("unknown");
            } else {
                Console.WriteLine(find);
            }
           
           
        }
    }
}
