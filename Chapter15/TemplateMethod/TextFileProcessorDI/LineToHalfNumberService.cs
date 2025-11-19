using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    public class LineToHalfNumberService : ITextFileService {



        public void Initialize(string fileName) {

        }
        public void Execute(string line) {
            string result = new string(
                line.Select(c => ('０' <= c && c <= '９') ? (char)(c - '０' + '0') : c).ToArray());

            Console.WriteLine(result);
        }


        public void Terminate() {

        }
    }
}
