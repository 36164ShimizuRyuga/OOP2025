
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);

        }

        private static void Exercise1(string text) {
            //1 ディクショナリインスタンスの生成
            var dict = new Dictionary<char, int>();
            //2 一文字取り出す, 3 大文字に変化
            foreach (var c in text.ToUpper()) {
                //4 アルファベットならディクショナリ登録
               
                    if ('A' <= c && c <= 'Z') {
                    if (dict.ContainsKey(c)) {
                        dict[c]++;
                    } else {
                        dict[c] = 1;
                    }
                }
            }
            //　登録済み：valueをインクリメント
            //未登録：valueに１を設定
            //5 2にもどる　
            foreach (var pair in dict.OrderBy(p => p.Key)) {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

        }

        private static void Exercise2(string text) {
            
        }
    }
}
