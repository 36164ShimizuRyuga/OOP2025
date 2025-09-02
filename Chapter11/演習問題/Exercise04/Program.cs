using System.Text.RegularExpressions;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {

            var lines = File.ReadAllLines("sample.txt");

            var pattern = @"version=""v4.0""";
            var replacement = @"version=""v5.0""";

           
            var newlines = lines.Select(line => Regex.Replace(line, pattern, replacement));


            File.WriteAllLines("sampleChange.txt",newlines);

            var text = File.ReadAllText("sampleChange.txt");
            Console.WriteLine(text);


        }
    }
}
