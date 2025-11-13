using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    internal class LineCounterProcessor : TextProcessor{
        private int _count = 0;
        private string _word = "";

        protected override void Initialize(string fname) {
            _count = 0;
            Console.WriteLine("単語を入力");
            _word = Console.ReadLine();
        }
        protected override void Execute(string line) {
            foreach (var item in line.Split(' ')) {
                if (item.Contains(_word)) {
                    _count++;
                }
            }
        }

        protected override void Terminate() => Console.WriteLine("{0}は{1}回出現しました", _word,_count);
          
        
    }
}
