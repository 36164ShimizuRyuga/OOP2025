using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    public class LineOutputService : ITextFileService {
        private int _count;
        private const int MaxLines = 20; 

       
        public void Initialize(string fname) {
            _count = 0;
            Console.WriteLine($"Processing file: {fname}");
        }

        // 各行をコンソールに出力（最大20行まで）
        public void Execute(string line) {
            if (_count < MaxLines) {
                _count++;
                Console.WriteLine(line);  // 行を表示
            }
        }

       
        public void Terminate() {
            Console.WriteLine($"Processed {_count} lines.");
           

        }
    }
}
