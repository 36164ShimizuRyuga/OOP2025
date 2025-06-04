
using System.Text;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.99");
            Exercise6(text);

        }

        private static void Exercise6(string text) {
            var str = text.ToLower().Replace(" ","");
            
            var alphDicCount = Enumerable.Range('a', 26)
                                .ToDictionary(num => ((char)num).ToString(), num => 0);

            foreach (var alph in str) {
                alphDicCount[alph.ToString()]++;
            }

            foreach (var item in alphDicCount) {
                Console.WriteLine($"{item.Key}:{item.Value}");

            }

            Console.WriteLine();

            var array = Enumerable.Repeat(0, 26).ToArray();

            foreach (var alph in str) {
                array[alph - 'a']++;
            }
            for(char ch = 'a';ch <= 'z';ch++) {
                Console.WriteLine($"{ch}:{array[ch - 'a']}");
            }


          /*  var alphabetCount = text
                .Where(c => Char.IsLetter(c))         
                .Select(c => Char.ToLower(c))         
                .GroupBy(c => c)                      
                .ToDictionary(g => g.Key, g => g.Count()); 

           
            for (char letter = 'a'; letter <= 'z'; letter++) {
                int count = alphabetCount.ContainsKey(letter) ? alphabetCount[letter] : 0; 
                Console.WriteLine($"{letter}: {count}");
            }*/
        }



        private static void Exercise1(string text) {
            var count = text.Count(c => c == ' ');
            Console.WriteLine("空白数：" + count);
        }

        private static void Exercise2(string text) {
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3(string text) {
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();
            foreach (var word in words) {
                sb.Append(word + ' ');
            }
            Console.WriteLine(sb.ToString().Trim()+".");
        }

        private static void Exercise4(string text) {
            var words = text.Split( ' ', StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("単語数："+ words.Length);
        }

        private static void Exercise5(string text) {
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var num = words.Where(s =>s.Length <= 4);
            foreach (var item in num) {
                Console.WriteLine(item);

            }

        }
       

    }
}
